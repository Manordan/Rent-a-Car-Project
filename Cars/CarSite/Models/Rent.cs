using System;
using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [StringLength(9)]
        public string UserId { get; set; }
        public int CarId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime EndtDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }


    }
}
