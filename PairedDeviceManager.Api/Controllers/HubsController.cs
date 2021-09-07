using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PairedDeviceManager.Contract.Requests.Hubs;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Hubs;
using PairedDeviceManager.Services;

namespace PairedDeviceManager.Api.Controllers
{
    /// <summary>
    /// API Endpoints for Hubs
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HubsController : ControllerBase
    {
        private readonly IHubsService _hubService;

        public HubsController(IHubsService hubService)
        {
            _hubService = hubService;
        }

        /// <inheritdoc cref="IHubsService.PairDevice"/>
        [HttpPut]
        [Route("pair-device")]
        public async Task<BaseResponse> PairDevice([FromBody] PairDeviceRequest request)
        {
            return await _hubService.PairDevice(request);
        }


        // TODO: Get Device State - Get information about a device as
        // Need Clarification on this requirement.


        /// <inheritdoc cref="IHubsService.GetHubDevices"/>
        [HttpGet]
        [Route("devices")]
        public async Task<GetHubDevicesResponse> GetDevices([FromQuery] GetHubDevicesRequest request)
        {
            return await _hubService.GetHubDevices(request);
        }

        /// <inheritdoc cref="IHubsService.RemoveDevice"/>
        [HttpDelete]
        [Route("remove-device")]
        public async Task<BaseResponse> RemoveDevice([FromQuery] RemoveDeviceRequest request)
        {
            return await _hubService.RemoveDevice(request);
        }
    }
}
