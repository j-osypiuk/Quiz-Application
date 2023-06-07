using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		private readonly ApplicationDbContext _db;

		[BindProperty]
        [DisplayName("Quiz code")]
        [Required]
        public string QuizCode { get; set; }
        
        [BindProperty]
        [DisplayName("First name")]
        [Required]
		public string FirstName { get; set; }
        
        [BindProperty]
        [DisplayName("Last name")]
        [Required]
        public string LastName { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext db)
		{
			_logger = logger;
			_db = db;
		}

		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPostAsync()
		{	
			if (ModelState.IsValid)
			{
				if(int.TryParse(QuizCode, out int number))
				{
                    bool exists = await _db.Quiz.AnyAsync(q => q.QuizCode == int.Parse(QuizCode));
                    if (!exists)
                    {
                        ModelState.AddModelError("QuizCode", "Quiz with this quiz code doesn't exist.");
                        return Page();
                    }
                } else
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