using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PairedDeviceManager.Contract.Models;
using PairedDeviceManager.Services;

namespace PairedDeviceManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HubsController : BaseApiController
    {
        private readonly IHubService _hubService;

        public HubsController(IHubService hubService, ILogger logger) : base(logger)
        {
            _hubService = hubService;
        }

        /// <summary>
        /// Pair a previously created device.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("pair-device")]
        public Task<Hub> PairDevice(long deviceId)
        {
            return _hubService.PairDevice(deviceId);
        }


        // TODO: Get Device State - Get information about a device as


        /// <summary>
        /// Get a list of devices paired to a hub
        /// </summary>
        /// <param name="hubId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("devices")]
        public Task<IEnumerable<Device>> GetDevices(long hubId)
        {
            return _hubService.GetDevices(hubId);
        }

        /// <summary>
        /// Unpair a device from a hub.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("remove-device")]
        public Task RemoveDevice(long deviceId)
        {
            return _hubService.RemoveDevice(deviceId);
        }
    }
}
