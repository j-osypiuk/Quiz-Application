using System.ComponentModel;

namespace QuizzApp.Model.ViewModel
{
    public class UserAccountViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }
    }
}
