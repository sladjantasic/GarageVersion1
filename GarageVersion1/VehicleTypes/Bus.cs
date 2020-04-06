namespace GarageVersion1.VehicleTypes
{
    internal class Bus : Vehicle
    {
        public string TransitType { get; set; }

        internal Bus(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string transitType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            TransitType = transitType;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of bus: {TransitType}";
        }
    }
}
