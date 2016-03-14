using BruPark.Apps.WPF.ViewModels;
using BruPark.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BruPark.Apps.WPF.Tests.ViewModels
{
    [TestClass]
    public class ParkingViewModelTests
    {

        private static ParkingRO CreateModel()
        {
            ParkingRO model = new ParkingRO();

            model.AddressFR = "Bonjour";
            model.AddressNL = "Hallo";

            model.Disabled = false;

            model.Distance = 123;
            model.Duration = 123;

            model.Id = 1;

            model.Spaces = 1234;

            model.SuccessRate = 100;

            return model;
        }

        [TestMethod]
        public void TestConstructor()
        {
            ParkingRO model = CreateModel();

            ParkingViewModel vm = new ParkingViewModel(model);

            Assert.AreEqual(model.AddressFR, vm.AddressFR);
            Assert.AreEqual(model.AddressNL, vm.AddressNL);
            Assert.AreEqual(model.Disabled, vm.Disabled);
            Assert.AreEqual(model.Distance, vm.Distance);
            Assert.AreEqual(model.Duration, vm.Duration);
            Assert.AreEqual(model.Id, vm.Id);
            Assert.AreEqual(model.Spaces, vm.Spaces);
            Assert.AreEqual(model.SuccessRate, vm.SuccessRate);
        }

        [TestMethod]
        public void TestSuccessRate()
        {
            ParkingViewModel vm = new ParkingViewModel(CreateModel());

            Assert.AreEqual(100, vm.SuccessRate);

            vm.SuccessRate = 50;

            Assert.AreEqual(50, vm.SuccessRate);
        }

    }
}
