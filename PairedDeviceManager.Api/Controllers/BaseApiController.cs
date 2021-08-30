using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PairedDeviceManager.Api.Controllers
{
    /// <summary>
    /// Base API controller for shared behavior.
    /// </summary>
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Logger for debugging.
        /// </summary>
        protected ILogger Logger { get; }

        public BaseApiController(ILogger logger)
        {
            Logger = logger;
        }
    }
}
