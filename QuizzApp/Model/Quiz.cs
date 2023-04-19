namespace QuizzApp.Model
{
	public class Quiz
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public int Threshold { get; set; }
        public UserAccount User { get; set; }
        public int UserId { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
