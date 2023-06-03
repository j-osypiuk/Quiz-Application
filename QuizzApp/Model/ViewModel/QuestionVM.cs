using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Model
{
	public class QuestionVM
	{
		[DisplayName("Question")]
		public string QuestionContent { get; set; }
		public List<AnswerVM> Answers { get; set; }
    }
}
