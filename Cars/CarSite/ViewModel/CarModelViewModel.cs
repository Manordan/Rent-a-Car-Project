using CarSite.Models;
using System.Collections.Generic;

namespace CarSite.ViewModel
{
    public class CarModelViewModel
    {
  
        public CarModel CarModel { get; set; }
        public ICollection<CarManufacturer> CarManufacturers { get; set; }
    }
}
