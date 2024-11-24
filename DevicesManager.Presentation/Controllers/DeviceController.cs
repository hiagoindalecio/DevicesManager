using DevicesManager.Application.DTO.DTO;
using DevicesManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevicesManager.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceApplicationService _deviceApplicationService;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(ILogger<DeviceController> logger, IDeviceApplicationService deviceApplicationService)
        {
            _logger = logger;
            _deviceApplicationService = deviceApplicationService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_deviceApplicationService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_deviceApplicationService.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] DeviceDTO deviceDTO)
        {
            try
            {
                if (deviceDTO == null)
                    return NotFound();

                _deviceApplicationService.Add(deviceDTO);
                return Ok("The device has been created successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] DeviceDTO deviceDTO)
        {
            try
            {
                if (deviceDTO == null)
                    return NotFound();

                _deviceApplicationService.Update(deviceDTO);
                return Ok("The device has been updated successfully!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] DeviceDTO deviceDTO)
        {
            try
            {
                if (deviceDTO == null)
                    return NotFound();

                _deviceApplicationService.Delete(deviceDTO);
                return Ok("The device has been deleted successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
