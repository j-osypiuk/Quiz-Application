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
		public string FirstName { get; set; }

		[BindProperty]
		public string LastName { get; set; }

		[BindProperty]
		public Quiz Quiz { get; set; }

		[BindProperty]
		public List<Boolean> IsAnswerCorrect { get; set; }

		public SolveQuizModel(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> OnGetAsync(string? firstName, string? lastName, int? quizCode)
        {
			Quiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.QuizCode == quizCode);

			if (Quiz != null)
			{
				FirstName = firstName;
				LastName = lastName;
			}

			return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {	
			Quiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.Id == Quiz.Id);

			int correctAnswers = 0;
			int j = 0;
			foreach (var question in Quiz.Questions) 
			{
				for (int i = 0; i < question.Answers.Count; i++, j++)
				{
					if (question.Answers[i].IsCorrect == IsAnswerCorrect[j]) correctAnswers++;
				}
			}
			double score = (double)correctAnswers / (double)IsAnswerCorrect.Count * 100;

			_db.Result.Add(new Result
			{
				FirstName = FirstName,
				LastName = LastName,
				Score = (int)Math.Round(score),
				CreateDate = DateTime.Now,
				Quiz = Quiz
			});

			await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
