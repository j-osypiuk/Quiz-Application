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
        public UserCredentials UserCredentials { get; set; }
        public List<Test> Test { get; set; } = new List<Test>();
    }
}
