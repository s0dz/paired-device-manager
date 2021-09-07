using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Contract.Models;
using PairedDeviceManager.Contract.Requests.Dwellings;
using PairedDeviceManager.Contract.Responses;
using PairedDeviceManager.Contract.Responses.Dwellings;
using PairedDeviceManager.Data;

namespace PairedDeviceManager.Services
{
    public interface IDwellingsService
    {
        /// <summary>
        /// Update dwelling status:
        /// A new resident has moved into the dwelling. <see cref="DwellingStatus.Occupied"/>
        /// A resident no longer resides in the dwelling. <see cref="DwellingStatus.Vacant"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UpdateStatus(UpdateDwellingStatusRequest request);

        /// <summary>
        /// Associate a hub with a dwelling.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> InstallHub(InstallHubRequest request);

        /// <summary>
        /// Get a list of all dwellings.
        /// </summary>
        /// <returns></returns>
        Task<ListDwellingsResponse> ListDwellings();
    }

    public class DwellingsService : IDwellingsService
    {
        /// <inheritdoc />
        public async Task<BaseResponse> UpdateStatus(UpdateDwellingStatusRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var dwelling = await context.Dwellings.FirstOrDefaultAsync(d => d.Id == request.DwellingId);

                if (dwelling != null)
                {
                    dwelling.DwellingStatus = request.DwellingStatus;
                    await context.SaveChangesAsync();

                    return new BaseResponse { Success = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Dwelling not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new ListDwellingsResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<BaseResponse> InstallHub(InstallHubRequest request)
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var dwelling = await context.Dwellings.FirstOrDefaultAsync(d => d.Id == request.DwellingId);
                var hub = await context.Hubs.FirstOrDefaultAsync(h => h.Id == request.HubId);

                if (dwelling != null && hub != null)
                {
                    dwelling.Hubs.Add(hub);
                    await context.SaveChangesAsync();

                    return new BaseResponse { Success = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Dwelling and/or hub not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new ListDwellingsResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }

        /// <inheritdoc />
        public async Task<ListDwellingsResponse> ListDwellings()
        {
            try
            {
                await using var context = new PairedDeviceManagerContext();

                var dwellings = await context.Dwellings.ToListAsync();

                if (dwellings.Count > 0)
                {
                    return new ListDwellingsResponse { Dwellings = dwellings };
                }
                else
                {
                    return new ListDwellingsResponse
                    {
                        Success = false,
                        Message = "Dwellings not found."
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                while (e.InnerException != null) e = e.InnerException;

                return new ListDwellingsResponse
                {
                    Success = false,
                    Message = $"Exception: {e.Message}"
                };
            }
        }
    }
}
