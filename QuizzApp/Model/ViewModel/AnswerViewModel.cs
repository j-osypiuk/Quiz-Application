using System.ComponentModel;

namespace QuizzApp.Model.ViewModel
{
	public class AnswerViewModel
	{
		[DisplayName("Answer")]	
		public string AnswerContent { get; set; }

		[DisplayName("Correct")]
		public int IsCorrect { get; set; }
	}
}
