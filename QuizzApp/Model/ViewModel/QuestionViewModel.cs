using System.ComponentModel;

namespace QuizzApp.Model.ViewModel
{
	public class QuestionViewModel
	{
		[DisplayName("Question")]
		public string QuestionContent { get; set; }
	}
}
