namespace QuizzApp.Model
{
	public class Result
	{
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
        public DateTime CreateDate { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
