using System;

namespace VehicleRentalSystem
{
    public class Reservation
    {
        public int VehicleId { get; set; }
        public string Customer { get; set; }
        public DateTime ReservationDate { get; set; }

        public Reservation(int vehicleId, string customer)
        {
            VehicleId = vehicleId;
            Customer = customer;
            ReservationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"VehicleId: {VehicleId}, Customer: {Customer}, Date: {ReservationDate}";
        }
    }
}