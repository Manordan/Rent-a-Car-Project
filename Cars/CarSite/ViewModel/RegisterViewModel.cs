using CarSite.ValdatianHelper;
using System.ComponentModel.DataAnnotations;

namespace CarSite.ViewModel
{
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "Required field")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Must be corect ID number")]
        [ValdatianTz]
        [Display(Name = "ID Number")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        

        [Required(ErrorMessage = "Required field")]
        [EmailAddress (ErrorMessage = "Inviled Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Must be Between 2-12 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
