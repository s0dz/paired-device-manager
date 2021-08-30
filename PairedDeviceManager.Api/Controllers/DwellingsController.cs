using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PairedDeviceManager.Api.Models;
using PairedDeviceManager.Api.Services;

namespace PairedDeviceManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DwellingsController : BaseApiController
    {
        private readonly IDwellingService _dwellingService;

        public DwellingsController(IDwellingService dwellingService, ILogger logger) : base(logger)
        {
            _dwellingService = dwellingService;
        }

        [HttpPut]
        [Route("update-status")]
        public Dwelling UpdateDwellingStatus(long dwellingId, DwellingStatus dwellingStatus)
        {
            return _dwellingService.UpdateDwellingStatus(dwellingId, dwellingStatus);
        }

        [HttpPut]
        [Route("install-hub")]
        public bool InstallHub(long dwellingId, long hubId)
        {
            return _dwellingService.InstallHub(dwellingId, hubId);
        }

        [HttpGet]
        public List<Dwelling> ListDwellings()
        {
            return _dwellingService.ListDwellings();
        }
    }
}
