using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PairedDeviceManager.Contract.Requests.Devices;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Devices;
using PairedDeviceManager.Services;

namespace PairedDeviceManager.Api.Controllers
{
    /// <summary>
    /// API Endpoints for Devices
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _devicesService;

        public DevicesController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

        /// <inheritdoc cref="IDevicesService.GetDevice"/>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<GetDeviceResponse> GetDevice([FromQuery] GetDeviceRequest request)
        {
            return await _devicesService.GetDevice(request);
        }

        /// <inheritdoc cref="IDevicesService.GetDevices"/>
        [HttpGet]
        [Route("list")]
        public async Task<GetDevicesResponse> GetDevices()
        {
            return await _devicesService.GetDevices();
        }

        /// <inheritdoc cref="IDevicesService.CreateDevice"/>
        [HttpPost]
        [Route("create")]
        public async Task<BaseResponse> CreateDevice([FromBody] CreateDeviceRequest request)
        {
            return await _devicesService.CreateDevice(request);
        }

        /// <inheritdoc cref="IDevicesService.UpdateDevice"/>
        [HttpPut]
        [Route("update")]
        public async Task<BaseResponse> UpdateDevice([FromBody] UpdateDeviceRequest request)
        {
            return await _devicesService.UpdateDevice(request);
        }

        /// <inheritdoc cref="IDevicesService.DeleteDevice"/>
        [HttpDelete]
        [Route("delete")]
        public async Task<BaseResponse> DeleteDevice([FromBody] DeleteDeviceRequest request)
        {
            return await _devicesService.DeleteDevice(request);
        }
    }
}
