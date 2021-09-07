using System.Text.Json.Serialization;

namespace PairedDeviceManager.Contract.Models
{
    /// <summary>
    /// Devices can be of the following types:
    ///     Switch - A device that can be turned on and off.
    ///     Dimmer - A device that provides variable lighting.
    ///     Lock - A door lock that can be open/shut and can have a pin code to enter.
    ///     Thermostat - A device for controlling the heat/cool levels of the dwelling.
    /// </summary>
    public class Device
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DeviceType DeviceType { get; set; }


        // Navigation property
        [JsonIgnore]
        public Hub Hub { get; set; }
    }
}
