using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PairedDeviceManager.Api.Services;

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


    }
}
