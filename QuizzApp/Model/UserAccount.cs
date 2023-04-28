using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizzApp.Model
{
    [Index(nameof(Email), IsUnique = true)]   
    
	public class UserAccount
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserCredential UserCredential { get; set; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
