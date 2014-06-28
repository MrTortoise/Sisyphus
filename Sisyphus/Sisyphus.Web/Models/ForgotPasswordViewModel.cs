using System.ComponentModel.DataAnnotations;

namespace Sisyphus.Web.Models
{
#pragma warning disable 1591

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    #pragma warning restore 1591
}
