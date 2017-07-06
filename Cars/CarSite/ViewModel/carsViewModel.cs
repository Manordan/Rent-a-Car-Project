namespace CarSite.ViewModel
{
    public class CarsViewModel
    {
        public CarsViewModel()
        {
            TransmissionType = Transmission == 1 ? "Manual" : "Automatic";


        }

        public int Id { get; set; }
        public int Transmission { get; set; }
        public string CarManufacturer { get; set; }
        public string Model { get; set; }
        public string Picture { get; set; }
        public int DailyCost { get; set; }
        public string TransmissionType { get; private set; }



    }
 
}
