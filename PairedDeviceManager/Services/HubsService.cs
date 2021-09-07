using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Contract.Requests.Hubs;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Hubs;
using PairedDeviceManager.Data;

namespace PairedDeviceManager.Services
{
    public interface IHubsService
    {
        /// <summary>
        /// Pair a previously created device.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> PairDevice(PairDeviceRequest request);


        // TODO: Get Device State - Get information about a device as
        // Need Clarification on this requirement.


        /// <summary>
        /// Get a list of devices paired to a hub
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetHubDevicesResponse> GetHubDevices(GetHubDevicesRequest request);

        /// <summary>
        /// Unpair a device from a hub.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RemoveDevice(RemoveDeviceRequest request);
    }

    public class HubsService : IHubsService
    {
        /// <inheritdoc />
        public async Task<BaseResponse> PairDevice(PairDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var device = await context.Devices.FirstOrDefaultAsync();
                var hub = await context.Hubs.FirstOrDefaultAsync();

                if (device != null && hub != null)
                {
                    device.Hub = hub;

                    context.Devices.Update(device);

                    await context.SaveChangesAsync();

                    return new BaseResponse { Success = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Device and/or hub not found."
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
        public async Task<GetHubDevicesResponse> GetHubDevices(GetHubDevicesRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var hub = await context.Hubs.Include(h => h.Devices).FirstOrDefaultAsync(h => h.Id == request.HubId);

                if (hub != null)
                {
                    return new GetHubDevicesResponse { Devices = hub.Devices };
                }
                else
                {
                    return new GetHubDevicesResponse
                    {
                        Success = false,
                        Message = "Hub not found."
                    };

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new GetHubDevicesResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResponse> RemoveDevice(RemoveDeviceRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var device = await context.Devices.FirstOrDefaultAsync();
                var hub = await context.Hubs.FirstOrDefaultAsync();

                if (device != null && hub != null)
                {
                    device.Hub = null;

                    context.Devices.Update(device);

                    await context.SaveChangesAsync();

                    return new BaseResponse { Success = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Device and/or hub not found."
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
