using DevicesManager.Application.DTO.DTO;
using DevicesManager.Application.Interfaces;
using DevicesManager.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DevicesManager.Presentation.Test
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class TestDeviceController(IDeviceApplicationService deviceApplicationService)
    {
        private readonly DeviceController _controller = new(deviceApplicationService);

        private List<DeviceCreationDTO> InitialTestDevices { get; set; } =
            [
                new("Redmi Note 13", "Xiaomi"),
                new("Galaxy S23", "Samsung"),
                new("Galaxy A15", "Samsung"),
                new("Galaxy A35", "Samsung")
            ];

        private List<DeviceDTO> CreatedTestDevices { get; set; } =
            [
                new() { Id = 1, Brand = "Xiaomi", Name = "Redmi Note 13" },
                new() { Id = 2, Brand = "Samsung", Name = "Galaxy S23" },
                new() { Id = 2, Brand = "Samsung", Name = "Galaxy A15" },
                new() { Id = 4, Brand = "Samsung", Name = "Galaxy A35" }
            ];

        [Test, Order(1)]
        public void PostAll_ShouldCreateAllDevices()
        {
            List<ObjectResult> results = [];
            foreach (var newDevice in InitialTestDevices)
                results.Add((ObjectResult)_controller.Post(newDevice));

            foreach (var result in results)
                Assert.That(result.StatusCode == 200, Is.True, result?.Value?.ToString());
        }

        [Test, Order(2)]
        public void Get_ShouldReturnAllDevices()
        {
            var foundDevices = _controller.Get();
            var result = (IEnumerable<DeviceDTO>?)((ObjectResult?)foundDevices.Result)?.Value;

            Assert.That(result == null, Is.False, "No devices has been found");

            if (result != null)
            {
                var notFound = InitialTestDevices.Any(x => !result.ToList().Any(y => y.Name == x.Name));

                Assert.That(notFound, Is.False, "Not all devices has been found");

                if (!notFound && result != null)
                    foreach (var createdItem in result)
                    {
                        var device = CreatedTestDevices.FirstOrDefault(dev => dev.Name == createdItem.Name && dev.Brand == createdItem.Brand);
                        if (device != null)
                        {
                            device.Id = createdItem.Id; // Keep the new created identifier
                            device.CreationDate = createdItem.CreationDate; // Keep the creation date
                        }
                    }
            }
        }

        [Test, Order(3)]
        public void Put_ShouldUpdateADevice()
        {
            var deviceToUpdate = CreatedTestDevices.First();
            deviceToUpdate.Name = "Moto G84";
            deviceToUpdate.Brand = "Motorola";
            var result = (ObjectResult)_controller.Put(deviceToUpdate);
            Assert.That(result.StatusCode == 200, Is.True, result?.Value?.ToString());
        }

        [Test, Order(4)]
        public void Delete_ShouldDeleteADevice()
        {
            var deviceToDelete = CreatedTestDevices.First();
            var result = (ObjectResult)_controller.Delete(deviceToDelete.Id);
            var done = result.StatusCode == 200;
            if (done)
                CreatedTestDevices.Remove(deviceToDelete);
            Assert.That(done, Is.True, result?.Value?.ToString());
        }

        [Test, Order(5)]
        public void GetByBrand_ShouldReturnAllDevicesForSpecificBrand()
        {
            var foundDevices = _controller.GetByBrand("Samsung");
            var result = (IEnumerable<DeviceDTO>?)((ObjectResult?)foundDevices.Result)?.Value;
            var allFound = result?.Count() == CreatedTestDevices.Where(x => x.Brand == "Samsung").Count();

            Assert.That(allFound, Is.True, "Not all devices has been found by brand");
        }

        [Test, Order(6)]
        public void GetById_ShouldReturnAllDevicesForSpecificIdentifier()
        {
            var device = CreatedTestDevices.First();
            var foundDevice = _controller.Get(device.Id);
            var result = (DeviceDTO?)((ObjectResult?)foundDevice.Result)?.Value;
            var found = result?.Name == device.Name && result?.Brand == device.Brand && result?.CreationDate == device.CreationDate;

            Assert.That(found, Is.True, "The device was not found by identifier");
        }

        [Test, Order(7)]
        public void Delete_ShouldDeleteAllCreatedDevices()
        {
            CreatedTestDevices.ForEach(deviceToDelete =>
            {
                var result = (ObjectResult)_controller.Delete(deviceToDelete.Id);
                var done = result.StatusCode == 200;
                Assert.That(done, Is.True, result?.Value?.ToString());
            });
        }
    }
}