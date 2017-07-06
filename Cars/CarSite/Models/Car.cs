using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{
    public class Car
    {
        public Car()
        {
            Rents = new HashSet<Rent>();
        }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Car number id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Model")]
        public int CarModelId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Kilometrage")]
        public int CurrentKilometers { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Model Year")]
        public int YearOfManufacture { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "transmission")]
        public int Transmission { get; set; }
        [Display(Name = "Image")]
        public string Picture { get; set; }
        [Display(Name = "Is proper for rent")]
        public bool IsRightForRent { get; set; }
        [Display(Name = "Is Available for rent")]
        public bool IsAvailableForRent { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Brench")]
        public int BranchId { get; set; }

        [Display(Name = "Model")]
        public CarModel CarModel { get; set; }
        [Display(Name = "Brench")]
        public Branch Branch { get; set; }
        public ICollection<Rent> Rents { get; set; }


    }
}
