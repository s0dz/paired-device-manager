using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PairedDeviceManager.Contract.Models
{
    /// <summary>
    /// Dwelling status.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DwellingStatus
    {
        /// <summary>
        /// An unknown status.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// Dwelling is occupied.
        /// </summary>
        [EnumMember(Value = "Occupied")]
        Occupied = 1,

        /// <summary>
        /// Dwelling is vacant.
        /// </summary>
        [EnumMember(Value = "Vacant")]
        Vacant = 2
    }
}