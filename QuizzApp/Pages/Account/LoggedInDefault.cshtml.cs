using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;

namespace QuizzApp.Pages.Account
{
    public class LoggedInDefaultModel : PageModel
    {
		private readonly ApplicationDbContext _db;

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string QuizCode { get; set; }

		public LoggedInDefaultModel(ApplicationDbContext db)
		{
			_db = db;
		}

		public void OnGet(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				if (int.TryParse(QuizCode, out int number))
				{
					bool exists = await _db.Quiz.AnyAsync(q => q.QuizCode == int.Parse(QuizCode));
					if (!exists)
					{
						ModelState.AddModelError("QuizCode", "Quiz with this quiz code doesn't exist.");
						return Page();
					}
				}
				else
				{
					ModelState.AddModelError("QuizCode", "Quiz code must contain only numbers.");
					return Page();
				}
				return RedirectToPage("/Quizzes/SolveQuiz", new { FirstName, LastName, QuizCode });
			}
			return Page();
		}
	}
}
