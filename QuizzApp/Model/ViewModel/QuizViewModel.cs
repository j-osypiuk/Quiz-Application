using System.ComponentModel;

namespace QuizzApp.Model.ViewModel
{
	public class QuizViewModel
	{
		[DisplayName("Quiz title")]
        public string QuizTitle { get; set; }

		[DisplayName("Quiz threshold")]
		public int QuizThreshold { get; set; }
	}
}
