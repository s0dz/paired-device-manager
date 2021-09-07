using System.Collections.Generic;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Contract.Responses.Dwellings
{
    public class ListDwellingsResponse : BaseResponse
    {
        public IReadOnlyCollection<Dwelling> Dwellings { get; set; }
    }
}
