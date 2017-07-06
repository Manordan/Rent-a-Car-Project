using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarSite.Models
{

    public class CarManufacturer
    {

        public CarManufacturer()
        {
            CarModels = new HashSet<CarModel>();
            
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }
        
        public ICollection<CarModel> CarModels { get; set; }

    }
}
