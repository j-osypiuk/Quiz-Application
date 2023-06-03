using System.ComponentModel;

namespace QuizzApp.Model
{
	public class QuizVM
	{
		[DisplayName("Quiz title")]
        public string QuizTitle { get; set; }

		[DisplayName("Quiz threshold [%]")]
		public int QuizThreshold { get; set; }
	}
}
