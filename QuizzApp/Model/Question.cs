namespace QuizzApp.Model
{
	public class Question
	{
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
