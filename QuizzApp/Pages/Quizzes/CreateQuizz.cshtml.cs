using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Model.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Pages.Quizzes
{
    public class CreateQuizzModel : PageModel
    {
        [BindProperty]
        public QuizViewModel QuizViewModel { get; set; }
		[BindProperty]
        public List<QuestionViewModel> Questions { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {   
            if(!ModelState.IsValid)
            {
            }

            return Page();
        }
    }
}
