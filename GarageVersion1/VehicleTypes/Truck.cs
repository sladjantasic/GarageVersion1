namespace GarageVersion1.VehicleTypes
{
    internal class Truck : Vehicle
    {
        public int CargoCapacity { get; set; }

        internal Truck(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int cargoCapacity) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            CargoCapacity = cargoCapacity;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Cargo capacity: {CargoCapacity}kg";
        }
    }
}
