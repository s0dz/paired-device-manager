using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PairedDeviceManager.Api.Models;
using PairedDeviceManager.Api.Services;

namespace PairedDeviceManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : BaseApiController
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService, ILogger logger) : base(logger)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public Task<Device> GetDevice(long deviceId)
        {
            return _deviceService.GetDevice(deviceId);
        }

        [HttpGet]
        public Task<IReadOnlyCollection<Device>> GetDevices()
        {
            return _deviceService.GetDevices();
        }

        [HttpPost]
        public Task<Device> CreateDevice(Device device)
        {
            return _deviceService.CreateDevice(device);
        }

        [HttpPut]
        public Task<Device> UpdateDevice(Device device)
        {
            return _deviceService.UpdateDevice(device);
        }

        [HttpDelete]
        public Task DeleteDevice(long deviceId)
        {
            return _deviceService.DeleteDevice(deviceId);
        }
    }
}
