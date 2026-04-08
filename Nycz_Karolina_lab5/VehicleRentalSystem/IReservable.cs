namespace VehicleRentalSystem
{
    public interface IReservable
    {
        void Reserve(string customer);
        void CancelReservation();
        bool IsAvailableMethod();
    }
}