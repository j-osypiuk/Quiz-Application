using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Quizzes
{
    public class EditQuizModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Quiz? Quiz { get; set; }

        [BindProperty]
        public List<Question> Questions { get; set; }

        [BindProperty]
        public List<Answer>[] Answers { get; set; }

        public EditQuizModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            int quizId = Convert.ToInt32(TempData["SelectedQuizId"]);
            Quiz = _db.Quiz.SingleOrDefault(q => q.Id == quizId);
            Questions = _db.Question.Where(q => q.QuizId == Quiz.Id).ToList();
            Answers = new List<Answer>[Questions.Count];
            for(int i = 0; i < Questions.Count; i++) 
            {
                Answers[i] = _db.Answer.Where(a => a.QuestionId == Questions[i].Id).ToList();
            }
        }
    }
}
