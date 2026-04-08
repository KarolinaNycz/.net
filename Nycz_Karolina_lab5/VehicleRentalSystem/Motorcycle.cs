using System;

namespace VehicleRentalSystem
{
    public class Motorcycle : Vehicle, IReservable
    {
        public int EngineCapacity { get; set; }
        public string? ReservedBy { get; private set; }

        public Motorcycle(int id, string brand, string model, int year, int engineCapacity)
            : base(id, brand, model, year)
        {
            EngineCapacity = engineCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Motorcycle] Id: {Id}, {Brand} {Model}, Year: {Year}, Engine: {EngineCapacity}cc, Available: {IsAvailable}");
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