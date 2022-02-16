using System.ComponentModel.DataAnnotations;

namespace WebApp.Identity.Models.ViewModels
{
    public class TwoStepModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string TwoFactorCode { get; set; }
        public bool RememberLogin { get; set; }
    }
}
