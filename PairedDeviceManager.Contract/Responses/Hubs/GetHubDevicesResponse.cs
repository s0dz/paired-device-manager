using System.Collections.Generic;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Contract.Responses.Hubs
{
    public class GetHubDevicesResponse : BaseResponse
    {
        public ICollection<Device> Devices { get; set; }
    }
}
