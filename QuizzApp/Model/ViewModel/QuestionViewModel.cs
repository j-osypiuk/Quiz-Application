using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Model.ViewModel
{
	public class QuestionViewModel
	{
		[DisplayName("Question")]
		public string QuestionContent { get; set; }
		public List<AnswerViewModel> Answers { get; set; }
    }
}
