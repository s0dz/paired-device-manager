using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PairedDeviceManager.Contract.Requests.Dwellings;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Dwellings;
using PairedDeviceManager.Services;

namespace PairedDeviceManager.Api.Controllers
{
    /// <summary>
    /// API Endpoints for Dwellings
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DwellingsController : ControllerBase
    {
        private readonly IDwellingsService _dwellingService;

        public DwellingsController(IDwellingsService dwellingService)
        {
            _dwellingService = dwellingService;
        }

        /// <inheritdoc cref="IDwellingsService.UpdateStatus"/>
        [HttpPut]
        [Route("update-status")]
        public async Task<BaseResponse> UpdateDwellingStatus([FromBody] UpdateDwellingStatusRequest request)
        {
            return await _dwellingService.UpdateStatus(request);
        }

        /// <inheritdoc cref="IDwellingsService.InstallHub"/>
        [HttpPut]
        [Route("install-hub")]
        public async Task<BaseResponse> InstallHub([FromBody] InstallHubRequest request)
        {
            return await _dwellingService.InstallHub(request);
        }

        /// <inheritdoc cref="IDwellingsService.ListDwellings"/>
        [HttpGet]
        [Route("list")]
        public async Task<ListDwellingsResponse> ListDwellings()
        {
            return await _dwellingService.ListDwellings();
        }
    }
}
