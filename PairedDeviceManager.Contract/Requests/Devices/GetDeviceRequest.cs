using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PairedDeviceManager.Contract.Requests.Devices
{
    /// <summary>
    /// Get device request.
    /// </summary>
    [JsonObject]
    public class GetDeviceRequest
    {
        [JsonProperty(PropertyName = "deviceId", Required = Required.Always)]
        private long DeviceId { get; set; }
    }
}
