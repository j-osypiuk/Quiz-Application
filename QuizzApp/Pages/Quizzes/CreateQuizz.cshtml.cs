using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Model.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Pages.Quizzes
{
    public class CreateQuizzModel : PageModel
    {
        public bool EnableClientValidation { get; set; } = true;

		[BindProperty]
        public List<QuestionViewModel> Questions { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {   
            return Page();
        }
    }
}
