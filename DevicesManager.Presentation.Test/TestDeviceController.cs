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

        private List<DeviceDTO> UpdatedTestDevices { get; set; } =
            [
                new() { Id = 1, Brand = "Xiaomi", Name = "Redmi Note 13" },
                new() { Id = 2, Brand = "Samsung", Name = "Galaxy S23" },
                new() { Id = 3, Brand = "Motorola", Name = "Moto G84" },
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
            Assert.That(foundDevices, !Is.Null);
            Assert.That((foundDevices?.Value?.ToList() ?? []).Count == InitialTestDevices.Count, Is.True, "Not all devices has been found");
        }

        //[Test, Order(3)]
        //public void Put_ShouldUpdateADevice()
        //{
        //
        //}
        //
        //[Test, Order(4)]
        //public void Delete_ShouldDeleteADevice()
        //{
        //
        //}            
    }
}