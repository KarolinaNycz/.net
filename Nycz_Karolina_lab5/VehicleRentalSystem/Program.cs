using System;
using VehicleRentalSystem;

class Program
{
    static void Main()
    {
        var rentalCompany = new RentalCompany();

        rentalCompany.OnNewReservation += message => Console.WriteLine(message);

        rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
        rentalCompany.AddVehicle(new Motorcycle(2, "Yamaha", "MT-07", 2021, 689));
        rentalCompany.AddVehicle(new Car(3, "BMW", "X5", 2022, "SUV"));

        Console.WriteLine("=== Wszystkie dostępne pojazdy ===");
        rentalCompany.ListAvailableVehicles();

        Console.WriteLine("\n=== Rezerwacja pojazdu ID 1 ===");
        rentalCompany.ReserveVehicle(1, "John Doe");

        Console.WriteLine("\n=== Dostępne pojazdy po rezerwacji ===");
        rentalCompany.ListAvailableVehicles();

        Console.WriteLine("\n=== Lista rezerwacji ===");
        rentalCompany.ListAllReservations();

        Console.WriteLine("\n=== Anulowanie rezerwacji pojazdu ID 1 ===");
        rentalCompany.CancelReservation(1);

        Console.WriteLine("\n=== Dostępne pojazdy po anulowaniu ===");
        rentalCompany.ListAvailableVehicles();
    }
}