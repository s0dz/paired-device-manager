using Newtonsoft.Json;

namespace PairedDeviceManager.Contract.Requests.Devices
{
    /// <summary>
    /// Create device request.
    /// </summary>
    [JsonObject]
    public class CreateDeviceRequest
    {
        [JsonProperty(PropertyName = "deviceId", Required = Required.Always)]
        private long DeviceId { get; set; }
    }
}
