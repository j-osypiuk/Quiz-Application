using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuizzApp.Model
{
    public class UserCredentialVM
    {
        [DisplayName("User Name")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
