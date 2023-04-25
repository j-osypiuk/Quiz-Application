using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Model.ViewModel
{
	public class AnswerViewModel
	{
		[DisplayName("Answer")]
		public string AnswersContent { get; set; }

		[DisplayName("Correct")]
		public bool IsCorrect { get; set; }
	}
}
