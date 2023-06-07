using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizzApp.Pages.Quizzes
{
    public class FinishedQuizModel : PageModel
    {
        [BindProperty]
        public int Score { get; set; }

        public void OnGet(int score)
        {
            Score = score;
        }
    }
}
