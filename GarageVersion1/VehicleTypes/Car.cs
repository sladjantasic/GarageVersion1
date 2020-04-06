namespace GarageVersion1.VehicleTypes
{
    internal class Car : Vehicle
    {
        public string FuelType { get; set; }

        internal Car(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string fuelType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            FuelType = fuelType;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of fuel: {FuelType}";
        }
    }
}
