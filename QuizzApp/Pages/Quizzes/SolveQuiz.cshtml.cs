using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Quizzes
{
	public class SolveQuizModel : PageModel
    {
        private readonly ApplicationDbContext _db;
		
		[BindProperty]
		public int QuizId { get; set; }

		[BindProperty]
		public Quiz Quiz { get; set; }

		[BindProperty]
		public List<Boolean> IsAnswerCorrect { get; set; }

		public SolveQuizModel(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> OnGetAsync(int quizId)
        {
			QuizId = 26;
			Quiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.Id == QuizId);


			return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {	
			var questions = _db.Question.Include(q => q.Answers).Where(q => q.QuizId == Quiz.Id).ToList();

			int correctAnswers = 0;
			int j = 0;
			foreach (var question in questions) 
			{
				for (int i = 0; i < question.Answers.Count; i++, j++)
				{
					if (question.Answers[i].IsCorrect == IsAnswerCorrect[j]) correctAnswers++;
				}
			}

			double score = (double)correctAnswers / (double)IsAnswerCorrect.Count;

            return RedirectToPage("/Index");
        }
    }
}
