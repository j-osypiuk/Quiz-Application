namespace QuizzApp.Model
{
	public class Result
	{
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
        public DateTime CreateDate { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
    }
}
