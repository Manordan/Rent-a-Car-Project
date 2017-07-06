using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{


    public class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        public string Name { get; set; }

        public ICollection<Branch> Branches { get; set; }

    }


    public class City2
    {
      
        public int Id { get; set; }
       
       
        public string Name { get; set; }

      

    }
}
