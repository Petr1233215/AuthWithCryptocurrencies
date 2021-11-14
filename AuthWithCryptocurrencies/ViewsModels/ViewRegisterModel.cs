using System.ComponentModel.DataAnnotations;

namespace AuthWithCryptocurrencies.ViewsModels
{
    public class ViewRegisterModel
    {
        [Required]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password missmatch")]
        public string ConfirmPassword { get; set; }
    }
}
