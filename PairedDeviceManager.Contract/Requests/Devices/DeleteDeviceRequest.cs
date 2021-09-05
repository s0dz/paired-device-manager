using Newtonsoft.Json;

namespace PairedDeviceManager.Contract.Requests.Devices
{
    /// <summary>
    /// Delete device request.
    /// </summary>
    [JsonObject]
    public class DeleteDeviceRequest
    {
        [JsonProperty(PropertyName = "deviceId", Required = Required.Always)]
        private long DeviceId { get; set; }
    }
}
