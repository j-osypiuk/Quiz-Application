using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UserAccount UserAccount { get; set; }
        public UserCredentials UserCredentials { get; set; }
        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
    }
}
