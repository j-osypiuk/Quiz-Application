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
			if (ModelState.IsValid)
			{
				var userAccount = _db.UserAccount.SingleOrDefault(ua => ua.Id == int.Parse(HttpContext.User.FindFirstValue("UserId")));
				if (userAccount != null)
				{
					Quiz userQuiz = new();
					userQuiz.SetQuizCode(_db);
					List<Question> userQuizQuestions = new List<Question>();

					for (int i = 0; i < Questions.Count; i++)
					{
						List<Answer> userQuizQuestionAnswers = new List<Answer>();
						userQuizQuestions.Add(new Question()
						{
							QuestionContent = Questions[i].QuestionContent,
							Quiz = userQuiz
						});

						for (int j = 0; j < Questions[i].Answers.Count; j++)
						{
							userQuizQuestionAnswers.Add(new Answer()
							{
								AnswerContent = Questions[i].Answers[j].AnswersContent,
								IsCorrect = Questions[i].Answers[j].IsCorrect,
								Question = userQuizQuestions[i]
							});
							_db.Answer.Add(userQuizQuestionAnswers[j]);
						}

						userQuizQuestions[i].Answers = userQuizQuestionAnswers;
						_db.Question.Add(userQuizQuestions[i]);
					}

					userQuiz.Title = QuizViewModel.QuizTitle;
					userQuiz.Threshold = QuizViewModel.QuizThreshold;
					userQuiz.Questions = userQuizQuestions;
					userQuiz.User = userAccount;

					userAccount.Quizzes.Add(userQuiz);

					_db.Quiz.Add(userQuiz);

					await _db.SaveChangesAsync();

					return RedirectToPage("/Index");
				}
			}

			return Page();
		}
	}
}
