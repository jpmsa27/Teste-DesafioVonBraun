using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.DTOs.Device;
using DesafioBackEndVonBraun.Service.Interfaces.Device;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEndVonBraun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class DeviceController(IDeviceService deviceService):ControllerBase
    {
        private readonly IDeviceService _deviceService = deviceService;


        [HttpPost("create-test-device")]
        public async Task<IActionResult> CreateDeviceAsync([FromBody] DeviceDTO userDTO)
        {
            await _deviceService.CreateDevice(userDTO);
            return Ok();
        }

        [HttpGet("get-test-device/{deviceId}")]
        public IActionResult GetDevice(string deviceId)
        {
            var device= _deviceService.GetDevice(deviceId);
            return Ok(device);
        }

        [HttpGet("get-test-devices")]
        public async Task<IActionResult> GetDevicesAsync()
        {
            DeviceDTO[] devices = await _deviceService.GetDevices();
            return Ok(devices);
        }

    }
}
