using System.Collections.Generic;
using System.Threading.Tasks;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Services
{
    public interface IHubService
    {
        /// <summary>
        /// Pair a previously created device.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task<Hub> PairDevice(long deviceId);


        // TODO: Get Device State - Get information about a device as


        /// <summary>
        /// Get a list of devices paired to a hub
        /// </summary>
        /// <param name="hubId"></param>
        /// <returns></returns>
        Task<IEnumerable<Device>> GetDevices(long hubId);

        /// <summary>
        /// Unpair a device from a hub.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task RemoveDevice(long deviceId);
    }

    public class HubsService : IHubService
    {
        public Task<Hub> PairDevice(long deviceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Device>> GetDevices(long hubId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveDevice(long deviceId)
        {
            throw new System.NotImplementedException();
        }
    }
}
