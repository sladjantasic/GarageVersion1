namespace GarageVersion1.VehicleTypes
{
    internal class Boat : Vehicle
    {
        public int Length { get; set; }

        internal Boat(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int length) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            Length = length;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Length: {Length}m";
        }
    }
}
