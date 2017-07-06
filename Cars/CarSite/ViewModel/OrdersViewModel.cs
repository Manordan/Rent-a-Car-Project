using System;
using System.ComponentModel.DataAnnotations;

namespace CarSite.ViewModel
{
    public class OrdersViewModel
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get
            {
                return  string.Format("{0} {1}", FirstName, LastName);
            }
        }
        [Display(Name = "Order Number id")]
        public int OrderId { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string CarManufacturer { get; set; }
        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Car")]
        public string Car { get {
                return string.Format("{0} {1}", CarManufacturer, CarModel);

            }
        }
        [Display(Name = "Car number id")]
        public int CarId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Day Cost")]
        public int DailyCost { get; set; }
        [Display(Name = "Cost of day delay")]
        public int DailyCostDelay { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Actual return date")]
        public DateTime? ReturnDate { get; set; }
        [Display(Name = "Number of Days")]
        public int SumRentDaysEnd { get {

                return (int)(EndDate - StartDate).TotalDays;
            } }

        [Display(Name = "Number of days delay")]
        public int SumRentDaysReturnDate
        {
            get
            {
                if (ReturnDate.HasValue)
                {
                    return (int) (ReturnDate.Value - EndDate).TotalDays;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "Order summary")]
        public string CloseOrder
        {
            get
            {
               if(ReturnDate==null)
                {
                    return "Open Order";
                }
               else
                {
                    int sumRentDays1 = (int)(EndDate - StartDate).TotalDays;
                    int sumRentDays2 = (int)(ReturnDate.Value - EndDate).TotalDays;
                    int totalPrice = (DailyCost * sumRentDays1)+ (DailyCostDelay * sumRentDays2);

                    return totalPrice.ToString();


    }

            }
        }
    }
}
