using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace QuizzApp.Pages.Quizzes
{
    public class UserQuizzesModel : PageModel
    {
        public ApplicationDbContext _db { get; set; }

        [BindProperty]
        public List<Quiz> UserQuizzes { get; set; }

        [BindProperty]
        public int SelectedQuizId { get; set; }

        public UserQuizzesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            UserQuizzes = _db.Quiz.Where(q => q.UserId == int.Parse(HttpContext.User.FindFirstValue("UserId"))).ToList();
        }

        public IActionResult OnPost() {

            TempData["SelectedQuizId"] = SelectedQuizId;
            return RedirectToPage("/Quizzes/EditQuiz");
        }
    }
}
