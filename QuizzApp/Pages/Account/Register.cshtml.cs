using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserAccountVM UserAccountViewModel { get; set; }

        [BindProperty]
        public NewUserCredentialVM UserCredentialViewModel { get; set; }

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (_db.UserCredential.Any(uc => uc.Username == UserCredentialViewModel.Username))
                {
                    ModelState.AddModelError("UserCredentialViewModel.Username", "Given user name already exists");
                }
                if (_db.UserAccount.Any(ua => ua.Email == UserAccountViewModel.Email))
                {
                    ModelState.AddModelError("UserAccountViewModel.Email", "Given email already exists");
                }
                if(!ModelState.IsValid)
                {
                    return Page();
                }

                UserAccount userAccount = new UserAccount();

                var newUserAccout = _db.Add(userAccount);
				var newUserCredential = _db.Add(new UserCredential() { UserAccount = userAccount });

				newUserAccout.CurrentValues.SetValues(UserAccountViewModel);
				newUserCredential.CurrentValues.SetValues(UserCredentialViewModel);

				await _db.SaveChangesAsync();
                return RedirectToPage("/Account/Login");
            }
            return Page();
        }
    }
}
