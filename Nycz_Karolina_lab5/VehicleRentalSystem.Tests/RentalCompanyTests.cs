using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VehicleRentalSystem;

namespace VehicleRentalSystem.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        [TestMethod]
        public void Car_ShouldBeCreated_WithCorrectAttributes()
        {
            var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");

            Assert.AreEqual(1, car.Id);
            Assert.AreEqual("Toyota", car.Brand);
            Assert.AreEqual("Corolla", car.Model);
            Assert.AreEqual(2020, car.Year);
            Assert.AreEqual("Sedan", car.BodyType);
            Assert.IsTrue(car.IsAvailable);
        }

        [TestMethod]
        public void Motorcycle_ShouldBeCreated_WithCorrectAttributes()
        {
            var moto = new Motorcycle(2, "Yamaha", "MT-07", 2021, 689);

            Assert.AreEqual(2, moto.Id);
            Assert.AreEqual("Yamaha", moto.Brand);
            Assert.AreEqual("MT-07", moto.Model);
            Assert.AreEqual(2021, moto.Year);
            Assert.AreEqual(689, moto.EngineCapacity);
            Assert.IsTrue(moto.IsAvailable);
        }

        [TestMethod]
        public void ReserveVehicle_ShouldChangeAvailability_AndCreateReservation()
        {
            var company = new RentalCompany();
            var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");

            company.AddVehicle(car);
            company.ReserveVehicle(1, "John Doe");

            Assert.IsFalse(car.IsAvailable);
            Assert.IsNotNull(company.FindReservationByVehicleId(1));
        }

        [TestMethod]
        public void CancelReservation_ShouldRestoreAvailability_AndRemoveReservation()
        {
            var company = new RentalCompany();
            var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");

            company.AddVehicle(car);
            company.ReserveVehicle(1, "John Doe");
            company.CancelReservation(1);

            Assert.IsTrue(car.IsAvailable);
            Assert.IsNull(company.FindReservationByVehicleId(1));
        }

        [TestMethod]
        public void GetAvailableVehicles_ExtensionMethod_ShouldReturnOnlyAvailableVehicles()
        {
            var car1 = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            var car2 = new Car(2, "BMW", "X5", 2022, "SUV");
            car2.Reserve("Anna");

            var vehicles = new List<Vehicle> { car1, car2 };

            var available = vehicles.GetAvailableVehicles();

            Assert.AreEqual(1, available.Count);
            Assert.AreEqual(1, available[0].Id);
        }

        [TestMethod]
        public void OnNewReservation_Event_ShouldBeRaised()
        {
            var company = new RentalCompany();
            var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            company.AddVehicle(car);

            string? receivedMessage = null;
            company.OnNewReservation += message => receivedMessage = message;

            company.ReserveVehicle(1, "John Doe");

            Assert.IsNotNull(receivedMessage);
            Assert.IsTrue(receivedMessage.Contains("John Doe"));
            Assert.IsTrue(receivedMessage.Contains("1"));
        }
    }
}