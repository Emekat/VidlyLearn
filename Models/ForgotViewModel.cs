using System.ComponentModel.DataAnnotations;

namespace VidlyLearn.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}