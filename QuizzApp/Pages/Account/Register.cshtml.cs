using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;
using QuizzApp.Model.ViewModel;

namespace QuizzApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UserAccountViewModel UserAccountViewModel { get; set; }

        [BindProperty]
        public UserCredentialsViewModel UserCredentialViewModel { get; set; }

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
                if (_db.UserCredentials.Any(uc => uc.Username == UserCredentialViewModel.Username))
                {
                    ModelState.AddModelError("UserCredentialViewModel.Username", "Given user name already exists");
                }
                if (_db.UsersAccounts.Any(ua => ua.Email == UserAccountViewModel.Email))
                {
                    ModelState.AddModelError("UserAccountViewModel.Email", "Given email already exists");
                }
                if(!ModelState.IsValid)
                {
                    return Page();
                }

                var userCredential = new UserCredentials
                {
                    Password = UserCredentialViewModel.Password,
                    Username = UserCredentialViewModel.Username,
                };

                var userAccount = new UserAccount
                {
                    FirstName = UserAccountViewModel.FirstName,
                    LastName = UserAccountViewModel.LastName,
                    Email = UserAccountViewModel.Email,
                };

                userCredential.UserAccount = userAccount;
                userAccount.UserCredentials = userCredential;

                _db.UsersAccounts.Add(userAccount);
                _db.UserCredentials.Add(userCredential);

                await _db.SaveChangesAsync();
                return RedirectToPage("/Account/Login");
            }
            return Page();
        }
    }
}
