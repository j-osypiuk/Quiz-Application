using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Quizzes
{
    [Authorize]
    public class EditQuizModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public int QuizId { get; set; }

		[BindProperty]
		public QuizVM Quiz { get; set; } = new QuizVM();

		[BindProperty]
		public List<QuestionVM> Questions { get; set; } = new List<QuestionVM>();

		public EditQuizModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int quizId)
        {
            QuizId = quizId;
            var userQuiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.Id == QuizId);

            Quiz.Title = userQuiz.Title;
            Quiz.Threshold = userQuiz.Threshold;

            for(int i = 0; i < userQuiz.Questions.Count; i++) 
            {
                Questions.Add(new QuestionVM { QuestionContent = userQuiz.Questions[i].QuestionContent });
                for(int j = 0; j < userQuiz.Questions[i].Answers.Count; j++)
                {
                    Questions[i].Answers.Add(new AnswerVM
                    {
                        AnswerContent = userQuiz.Questions[i].Answers[j].AnswerContent,
                        IsCorrect = userQuiz.Questions[i].Answers[j].IsCorrect
                    });
                }
            }

			return Page();
		}

        public async Task<IActionResult> OnPostAsync()
        {

			var userQuiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.Id == QuizId);

			userQuiz.Title = Quiz.Title;
			userQuiz.Threshold = Quiz.Threshold;
			List<Question> quizQuestions = new List<Question>();

			foreach (var question in Questions)
			{
				List<Answer> questionAnswers = new List<Answer>();
				foreach (var answer in question.Answers)
				{
					if (answer.AnswerContent != null)
					{
						questionAnswers.Add(new Answer { AnswerContent = answer.AnswerContent, IsCorrect = answer.IsCorrect });
					}
				}
				if (question.QuestionContent != null)
				{
					quizQuestions.Add(new Question { QuestionContent = question.QuestionContent, Answers = questionAnswers });
				}
			}
			userQuiz.Questions = quizQuestions;

			_db.Update(userQuiz);
			await _db.SaveChangesAsync();


			return RedirectToPage("/Quizzes/UserQuizzes");
        }
    }
}
