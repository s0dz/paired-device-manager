using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PairedDeviceManager.Api.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
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