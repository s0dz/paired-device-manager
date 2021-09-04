using System.Collections.Generic;

namespace PairedDeviceManager.Contract.Models
{
    /// <summary>
    /// A hardware piece that interacts with devices.
    /// </summary>
    public class Hub
    {
        public long Id { get; set; }

        public string Name { get; set; }


        // Navigation property
        public ICollection<Device> Devices { get; set; }
    }
}
