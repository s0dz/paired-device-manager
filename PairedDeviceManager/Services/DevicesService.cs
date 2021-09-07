using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Contract.Requests.Devices;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Devices;
using PairedDeviceManager.Data;

namespace PairedDeviceManager.Services
{
    public interface IDevicesService
    {
        /// <summary>
        /// Retrieve the current state of a device
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDeviceResponse> GetDevice(GetDeviceRequest request);

        /// <summary>
        /// List all devices.
        /// </summary>
        /// <returns></returns>
        Task<GetDevicesResponse> GetDevices();

        /// <summary>
        /// Create a new device.
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse> CreateDevice(CreateDeviceRequest request);

        /// <summary>
        /// Change the state of the device.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UpdateDevice(UpdateDeviceRequest request);

        /// <summary>
        /// Delete a device that is not currently paired
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> DeleteDevice(DeleteDeviceRequest request);
    }

    public class DevicesService : IDevicesService
    {
        /// <inheritdoc />
        public async Task<GetDeviceResponse> GetDevice(GetDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var device = await context.Devices.FirstOrDefaultAsync(d => d.Id == request.DeviceId);
                if (device != null)
                {
                    return new GetDeviceResponse {Device = device};
                }
                else
                {
                    return new GetDeviceResponse
                    {
                        Success = false,
                        Message = "Device not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new GetDeviceResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<GetDevicesResponse> GetDevices()
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var devices = await context.Devices.ToListAsync();

                if (devices.Count > 0)
                {
                    return new GetDevicesResponse { Devices = devices };
                }
                else
                {
                    return new GetDevicesResponse
                    {
                        Success = false,
                        Message = "Devices not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new GetDevicesResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResponse> CreateDevice(CreateDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                await context.Devices.AddAsync(request.Device);

                await context.SaveChangesAsync();

                return new BaseResponse { Success = true };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                while (e.InnerException != null) e = e.InnerException;
                
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResponse> UpdateDevice(UpdateDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var device = await context.Devices.FirstOrDefaultAsync(d => d.Id == request.Device.Id);

                if (device != null)
                {
                    device.DeviceType = request.Device.DeviceType;
                    device.Name = request.Device.Name;

                    context.Devices.Update(device);

                    await context.SaveChangesAsync();

                    return new BaseResponse { Success = true};
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Device not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new BaseResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResponse> DeleteDevice(DeleteDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var device = await context.Devices.FirstOrDefaultAsync(d => d.Id == request.DeviceId);

                if (device != null)
                {
                    context.Devices.Remove(device);

                    await context.SaveChangesAsync();

                    return new BaseResponse {Success = true};
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Device not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new BaseResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }
    }
}
