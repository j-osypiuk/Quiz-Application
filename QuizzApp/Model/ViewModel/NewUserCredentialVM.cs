using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizzApp.Model
{
    public class NewUserCredentialVM
    {
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Compare(nameof(ConfirmedPassword), ErrorMessage = "Entered password is inconsistent")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Entered password is inconsistent")]
        public string ConfirmedPassword { get; set; }
    }
}
