using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Contract.Responses.Devices
{
    public class GetDeviceResponse : BaseResponse
    {
        public Device Device { get; set; }
    }
}
