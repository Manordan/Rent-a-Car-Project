using System.Collections.Generic;

namespace CarSite.ViewModel
{
    public class CarManufacturerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarModelDto> Model { get; set; }
        


    }
}
