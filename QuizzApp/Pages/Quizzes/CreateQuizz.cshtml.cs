using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;
using QuizzApp.Model.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace QuizzApp.Pages.Quizzes
{
    public class CreateQuizzModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public QuizViewModel QuizViewModel { get; set; }

		[BindProperty]
        public List<QuestionViewModel> Questions { get; set; }

        public CreateQuizzModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {   
/*            if(ModelState.IsValid)
            {   
                List<Question> questions = new List<Question>();

                foreach(var question in Questions)
                {   
                    List<Answer> answers = new List<Answer>();
                
                    foreach(var answer in  question.Answers)
                    {
                        answers.Add(new Answer()
                        {
                            AnswerContent = answer.AnswersContent,
                            IsCorrect = answer.IsCorrect ? 1 : 0,
                        }) ;
                    }
                    questions.Add(new Question()
                    {
                        QuestionContent = question.QuestionContent,
                        Answers = answers
                    }) ;
                }

                Quiz newQuiz = new()
                {   
                    Title = QuizViewModel.QuizTitle,
                    Threshold = QuizViewModel.QuizThreshold,
                    Questions = questions,
                };

                _db.Tests.Add(newQuiz);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Index");
            }*/

            return Page();
        }
    }
}
