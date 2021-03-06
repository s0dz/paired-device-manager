using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PairedDeviceManager.Contract.Models
{
    /// <summary>
    /// Device type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeviceType
    {
        /// <summary>
        /// An unknown device.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// A device that can be turned on and off.
        /// </summary>
        [EnumMember(Value = "Switch")]
        Switch = 1,

        /// <summary>
        /// A device that provides variable lighting.
        /// </summary>
        [EnumMember(Value = "Dimmer")]
        Dimmer = 2,

        /// <summary>
        /// A door lock that can be open/shut and can have a pin code to enter.
        /// </summary>
        [EnumMember(Value = "Lock")]
        Lock = 3,

        /// <summary>
        /// A device for controlling the heat/cool levels of the dwelling.
        /// </summary>
        [EnumMember(Value = "Thermostat")]
        Thermostat = 4
    }
}