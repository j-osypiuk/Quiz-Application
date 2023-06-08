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
        public int QuizId { get; set; }

        [BindProperty]
        public List<bool> ToDelete { get; set; } = new List<bool>();

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
            QuizId = quizId;
            Results = _db.Result.Where(r => r.QuizId == QuizId).ToList();
            Title = title;
            foreach (var result in Results)
            {
                ToDelete.Add(false);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var results = _db.Result.Where(r => r.QuizId == QuizId).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                if (ToDelete[i])
                {
                    _db.Result.Remove(results[i]);
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToPage("/Quizzes/QuizResults", new {QuizId, Title});
        }
    }
}
