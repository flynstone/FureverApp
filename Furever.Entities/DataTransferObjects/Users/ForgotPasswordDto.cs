using System.ComponentModel.DataAnnotations;

namespace Furever.Entities.DataTransferObjects.Users
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ClientURI { get; set; }
    }
}
