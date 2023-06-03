namespace QuizzApp.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
