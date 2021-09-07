using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Contract.Requests.Dwellings
{
    public class UpdateDwellingStatusRequest
    {
        public long DwellingId { get; set; }

        public DwellingStatus DwellingStatus { get; set; }
    }
}
