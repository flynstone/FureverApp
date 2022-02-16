using System.ComponentModel.DataAnnotations;

namespace WebApp.Identity.Models.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
