namespace GarageVersion1.VehicleTypes
{
    class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int length) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            Length = length;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Length: {Length}m";
        }
    }
}
