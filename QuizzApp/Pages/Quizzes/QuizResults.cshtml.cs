using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Quizzes
{
    public class QuizResultsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public List<Result> Results { get; set; }

        [BindProperty]
        public string Title { get; set; }

        public QuizResultsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int quizId, string title)
        {
            Results = _db.Result.Where(r => r.QuizId == quizId).ToList();
            Title = title;
        }
    }
}
