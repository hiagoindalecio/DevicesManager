using DevicesManager.Application.DTO.DTO;
using DevicesManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevicesManager.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController(IDeviceApplicationService deviceApplicationService) : ControllerBase
    {

        private readonly IDeviceApplicationService _deviceApplicationService = deviceApplicationService;

        [HttpGet]
        public ActionResult<IEnumerable<DeviceDTO>?> Get()
        {
            var devices = _deviceApplicationService.GetAll(out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok(devices);
            else
                return BadRequest(ErrorMessage);
        }

        [HttpGet("{id}")]
        public ActionResult<DeviceDTO?> Get(int id)
        {
            var device = _deviceApplicationService.GetById(id, out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok(device);
            else
                return BadRequest(ErrorMessage);
        }

        [HttpGet("get-by-brand/{brand}")]
        public ActionResult<DeviceDTO?> GetByBrand(string brand)
        {
            var device = _deviceApplicationService.GetByBrand(brand, out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok(device);
            else
                return BadRequest(ErrorMessage);
        }

        [HttpPost]
        public ActionResult Post([FromBody] DeviceCreationDTO deviceCreationDTO)
        {
            if (deviceCreationDTO == null)
                return BadRequest("The device properties must be filled in!");

            _deviceApplicationService.Add(deviceCreationDTO, out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok("The device has been created successfully!");
            else
                return BadRequest(ErrorMessage);
        }

        [HttpPut]
        public ActionResult Put([FromBody] DeviceDTO deviceDTO)
        {
            if (deviceDTO == null)
                return BadRequest("The device properties must be filled in!");

            _deviceApplicationService.Update(deviceDTO, out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok("The device has been updated successfully!");
            else
                return BadRequest(ErrorMessage);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _deviceApplicationService.Delete(id, out string ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
                return Ok("The device has been deleted successfully!");
            else
                return BadRequest(ErrorMessage);
        }
    }
}
