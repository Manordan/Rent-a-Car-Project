using System.ComponentModel.DataAnnotations;

namespace CarSite.ViewModel
{
    public class CarManufacturerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be Between 2-20 characters")]
        public string Name { get; set; }
    }
}
