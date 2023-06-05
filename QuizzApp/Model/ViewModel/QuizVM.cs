using System.ComponentModel;

namespace QuizzApp.Model
{
	public class QuizVM
	{
		[DisplayName("Quiz title")]
        public string Title { get; set; }

		[DisplayName("Quiz threshold [%]")]
		public int Threshold { get; set; }
	}
}
