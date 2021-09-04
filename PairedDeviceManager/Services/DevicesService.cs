using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Services
{
    public interface IDeviceService
    {
        /// <summary>
        /// Retrieve the current state of a device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task<Device> GetDevice(long deviceId);

        /// <summary>
        /// List all devices.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Device>> GetDevices();

        /// <summary>
        /// Create a new device.
        /// </summary>
        /// <returns></returns>
        Task<Device> CreateDevice(Device device);

        /// <summary>
        /// Change the state of the device.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        Task<Device> UpdateDevice(Device device);

        /// <summary>
        /// Delete a device that is not currently paired
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task DeleteDevice(long deviceId);
    }

    public class DevicesService : IDeviceService
    {
        /// <inheritdoc />
        public Task<Device> GetDevice(long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Device>> GetDevices()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Device> CreateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Device> UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task DeleteDevice(long deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
