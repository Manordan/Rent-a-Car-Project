using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{
    public enum Transmission
    {
        Regular=1,
        Automatic
    }
    
    public class CarModel
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        [Display(Name = "Manufacturer")]
        public int CarManufacturerId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Day Cost")]
        public int DailyCost { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Cost of day delay")]
        public int DailyCostDelay { get; set; }


        public ICollection<Car> Cars { get; set; }
        public CarManufacturer CarManufacturer { get; set; }


    }
}
