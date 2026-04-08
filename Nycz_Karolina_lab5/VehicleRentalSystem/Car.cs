using System;

namespace VehicleRentalSystem
{
    public class Car : Vehicle, IReservable
    {
        public string BodyType { get; set; }
        public string? ReservedBy { get; private set; }

        public Car(int id, string brand, string model, int year, string bodyType)
            : base(id, brand, model, year)
        {
            BodyType = bodyType;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Car] Id: {Id}, {Brand} {Model}, Year: {Year}, Body: {BodyType}, Available: {IsAvailable}");
        }

        public void Reserve(string customer)
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Pojazd jest już zarezerwowany.");

            IsAvailable = false;
            ReservedBy = customer;
        }

        public void CancelReservation()
        {
            if (IsAvailable)
                throw new InvalidOperationException("Pojazd nie ma aktywnej rezerwacji.");

            IsAvailable = true;
            ReservedBy = null;
        }

        public bool IsAvailableMethod()
        {
            return IsAvailable;
        }
    }
}