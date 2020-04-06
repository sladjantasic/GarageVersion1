namespace GarageVersion1.VehicleTypes
{
    internal class Motorcycle : Vehicle
    {
        public string BikeType { get; set; }

        internal Motorcycle(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string bikeType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            BikeType = bikeType;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of motorcycle: {BikeType}";
        }
    }
}
