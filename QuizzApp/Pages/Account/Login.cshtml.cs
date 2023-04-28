using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;
using QuizzApp.Model.ViewModel;
using System.Security.Claims;

namespace QuizzApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserCredentialViewModel UserCredential { get; set; }
        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() { 
        
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Provided username or password are incorrect.");
            }

            var userCredential = _db.UserCredentials.SingleOrDefault(uc => uc.Username == UserCredential.Username && uc.Password == UserCredential.Password);
            if (userCredential != null)
            {
                var userAccount = _db.UsersAccounts.SingleOrDefault(ua => ua.Id == userCredential.Id);
                if (userAccount != null)
                {
                    var claims = new List<Claim> {
                            new Claim("UserId", userAccount.Id.ToString()),
                            new Claim(ClaimTypes.Name, "UserLoggedIn"),
                            new Claim(ClaimTypes.Email, userAccount.Email),
                        };
                    var identity = new ClaimsIdentity(claims, "AuthCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("AuthCookie", claimsPrincipal);

                    return RedirectToPage("/Index");
                }

            }
            return Page();
        }
    }
}
