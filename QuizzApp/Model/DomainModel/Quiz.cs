using QuizzApp.Data;

namespace QuizzApp.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public int QuizCode { get; set; }
        public string Title { get; set; }
        public int Threshold { get; set; }
        public UserAccount User { get; set; }
        public int UserId { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
        public List<Question> Questions { get; set; } = new List<Question>();

        public void SetQuizCode(ApplicationDbContext _db)
        {
            Random rand = new Random();
            int quizCode = rand.Next(100000, 1000000);
            while (_db.Quiz.Any(q => q.QuizCode == quizCode))
            {
                quizCode = rand.Next(100000, 1000000);
            }
            QuizCode = quizCode;
        }
    }
}
