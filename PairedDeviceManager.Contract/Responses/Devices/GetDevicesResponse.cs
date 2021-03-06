using System.Collections.Generic;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Contract.Responses.Devices
{
    public class GetDevicesResponse : BaseResponse
    {
        public ICollection<Device> Devices { get; set; }
    }
}
