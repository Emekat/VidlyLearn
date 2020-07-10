using System.ComponentModel.DataAnnotations;

namespace VidlyLearn.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}