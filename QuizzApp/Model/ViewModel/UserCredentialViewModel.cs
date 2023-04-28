using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuizzApp.Model.ViewModel
{
    public class UserCredentialViewModel
    {
        [DisplayName("User Name")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
