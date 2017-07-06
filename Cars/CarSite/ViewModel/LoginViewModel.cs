using System.ComponentModel.DataAnnotations;

namespace CarSite.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "User Name")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
 
    }
}
