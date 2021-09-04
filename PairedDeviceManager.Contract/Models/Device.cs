using Newtonsoft.Json;

namespace PairedDeviceManager.Contract.Models
{
    [JsonObject]
    public class Device
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("deviceType")]
        public DeviceType DeviceType { get; set; }

        
        // Navigation property
        public Hub Hub { get; set; }
    }
}
