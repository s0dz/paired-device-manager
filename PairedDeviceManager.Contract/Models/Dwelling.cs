using System.Collections.Generic;

namespace PairedDeviceManager.Contract.Models
{
    /// <summary>
    /// A living space where hubs and devices can be installed.
    /// </summary>
    public class Dwelling
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DwellingStatus DwellingStatus{ get; set; }


        // Navigation property
        public ICollection<Hub> Hubs { get; set; }
    }
}
