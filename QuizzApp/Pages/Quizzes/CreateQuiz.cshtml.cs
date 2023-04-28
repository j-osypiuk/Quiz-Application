using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;
using QuizzApp.Model.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Security.Claims;

namespace QuizzApp.Pages.Quizzes
{
    [Authorize (Policy = "MustBeLoggedInUser")]
    public class CreateQuizzModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public QuizViewModel QuizViewModel { get; set; }

		[BindProperty]
        public List<QuestionViewModel> QuestionsViewModel { get; set; }

        public CreateQuizzModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var userAccount = _db.UsersAccounts.SingleOrDefault(ua => ua.Id == int.Parse(HttpContext.User.FindFirstValue("UserId")));
                if (userAccount != null)
                {
                    Quiz userQuiz = new();
                    List<Question> userQuizQuestions = new List<Question>();

                    for(int i = 0; i < QuestionsViewModel.Count; i++)
                    {
                        List<Answer> userQuizQuestionAnswers = new List<Answer>();
                        userQuizQuestions.Add(new Question()
                        {
                            QuestionContent = QuestionsViewModel[0].QuestionContent,
                            Test = userQuiz
                        });

                        foreach (var answerViewModel in QuestionsViewModel[0].Answers)
                        {
                            userQuizQuestionAnswers.Add(new Answer()
                            {
                                AnswerContent = answerViewModel.AnswersContent,
                                IsCorrect = answerViewModel.IsCorrect ? 1 : 0,
                                Question = userQuizQuestions[i]
                            });
                            _db.Answers.Add(userQuizQuestionAnswers[userQuizQuestionAnswers.Count - 1]);
                        }

                        userQuizQuestions[i].Answers = userQuizQuestionAnswers;
                        _db.Questions.Add(userQuizQuestions[i]);
                    }

                    userQuiz.Title = QuizViewModel.QuizTitle;
                    userQuiz.Threshold = QuizViewModel.QuizThreshold;
                    userQuiz.Questions = userQuizQuestions;
                    userQuiz.User = userAccount;

                    userAccount.Test.Add(userQuiz);

                    _db.Tests.Add(userQuiz);

                    await _db.SaveChangesAsync();

                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
