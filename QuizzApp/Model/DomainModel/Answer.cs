namespace QuizzApp.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
