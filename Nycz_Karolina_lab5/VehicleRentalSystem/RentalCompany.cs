using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalSystem
{
    public class RentalCompany
    {
        private readonly List<Vehicle> vehicles = new();
        private readonly List<Reservation> reservations = new();

        public event Action<string>? OnNewReservation;

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return vehicles;
        }

        public List<Reservation> GetAllReservations()
        {
            return reservations;
        }

        public void ReserveVehicle(int vehicleId, string customer)
        {
            Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                throw new Exception("Nie znaleziono pojazdu.");

            if (vehicle is not IReservable reservable)
                throw new Exception("Tego pojazdu nie można rezerwować.");

            reservable.Reserve(customer);

            reservations.Add(new Reservation(vehicleId, customer));

            OnNewReservation?.Invoke($"Nowa rezerwacja: {customer} zarezerwował pojazd ID {vehicleId}");
        }

        public void CancelReservation(int vehicleId)
        {
            Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
                throw new Exception("Nie znaleziono pojazdu.");

            if (vehicle is not IReservable reservable)
                throw new Exception("Tego pojazdu nie można anulować.");

            reservable.CancelReservation();

            Reservation? reservation = reservations.FirstOrDefault(r => r.VehicleId == vehicleId);
            if (reservation != null)
            {
                reservations.Remove(reservation);
            }
        }

        public List<Vehicle> FindAvailableVehicles()
        {
            return vehicles.Where(v => v.IsAvailable).ToList();
        }

        public Reservation? FindReservationByVehicleId(int vehicleId)
        {
            return reservations.FirstOrDefault(r => r.VehicleId == vehicleId);
        }

        public void ListAvailableVehicles()
        {
            var availableVehicles = vehicles.GetAvailableVehicles();

            if (availableVehicles.Count == 0)
            {
                Console.WriteLine("Brak dostępnych pojazdów.");
                return;
            }

            foreach (var vehicle in availableVehicles)
            {
                vehicle.DisplayInfo();
            }
        }

        public void ListAllReservations()
        {
            if (reservations.Count == 0)
            {
                Console.WriteLine("Brak rezerwacji.");
                return;
            }

            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}