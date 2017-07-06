using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        [Display(Name = "Brench Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "Must be Between 4-40 characters")]
        public string Address { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }

        public City City { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
