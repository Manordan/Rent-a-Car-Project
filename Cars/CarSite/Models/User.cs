using CarSite.ValdatianHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{

    public class User
    {
        public User()
        {
            Rents = new HashSet<Rent>();
            Roles = new HashSet<Role>();
        }
        [ValdatianTz]
        [Required(ErrorMessage = "Required field")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Must be Corect ID Number")]
        [Display(Name = "ID Number")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "First Name")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="Must be Between 2-20 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Must be Between 2-12 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Must be Between 4-12 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Required field")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Image")]
        public string Picture { get; set; }
   

        public ICollection<Rent> Rents { get; set; }
        public ICollection<Role> Roles { get; set; }


    }
}
