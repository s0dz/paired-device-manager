using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Contract.Models;
using PairedDeviceManager.Data;

namespace PairedDeviceManager.Services
{
    public interface IDwellingService
    {
        /// <summary>
        /// Update dwelling status:
        /// A new resident has moved into the dwelling. <see cref="DwellingStatus.Occupied"/>
        /// A resident no longer resides in the dwelling. <see cref="DwellingStatus.Vacant"/>
        /// </summary>
        /// <param name="dwellingId"></param>
        /// <param name="dwellingStatus"></param>
        /// <returns></returns>
        Dwelling UpdateStatus(long dwellingId, DwellingStatus dwellingStatus);

        /// <summary>
        /// Associate a hub with a dwelling.
        /// </summary>
        /// <param name="dwellingId"></param>
        /// <param name="hubId"></param>
        /// <returns></returns>
        bool InstallHub(long dwellingId, long hubId);

        /// <summary>
        /// Get a list of all dwellings.
        /// </summary>
        /// <returns></returns>
        List<Dwelling> ListDwellings();
    }

    public class DwellingsService : IDwellingService
    {
        public Dwelling UpdateStatus(long dwellingId, DwellingStatus dwellingStatus)
        {
            using (var context = new PairedDeviceManagerContext())
            {
                var dwelling = context.Dwellings.FirstOrDefaultAsync(d => d.Id == dwellingId).Result;

                if (dwelling != null)
                {
                    dwelling.DwellingStatus = dwellingStatus;
                    context.SaveChangesAsync();

                    return dwelling;
                }
                else
                {
                    // TODO: Handle case where no dwelling with dwellingId is found.
                    return null;
                }
            }
        }

        public bool InstallHub(long dwellingId, long hubId)
        {
            using (var context = new PairedDeviceManagerContext())
            {
                var dwelling = context.Dwellings.FirstOrDefaultAsync(d => d.Id == dwellingId).Result;
                var hub = context.Hubs.FirstOrDefaultAsync(h => h.Id == hubId).Result;

                if (dwelling != null && hub != null)
                {
                    dwelling.Hubs.Add(hub);
                    context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Dwelling> ListDwellings()
        {
            using (var context = new PairedDeviceManagerContext())
            {
                var dwellings = context.Dwellings.ToList();

                return dwellings;
            }
        }
    }
}
