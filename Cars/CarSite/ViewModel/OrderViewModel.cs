using System;
using System.ComponentModel.DataAnnotations;

namespace CarSite.ViewModel
{
    public class OrderViewModel : CarsViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public int SumRentDays { get { return (int)(EndDate - StartDate).TotalDays; } }
        public int TotalPrice { get { return DailyCost * SumRentDays; } }
    }
}
