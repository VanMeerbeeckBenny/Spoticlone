using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Web.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "Not a valid E-mail")]
        public string Email { get; set; }
        public bool IsRegistered { get; set; }
    }
}
