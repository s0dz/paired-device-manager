namespace PairedDeviceManager.Contract.Requests.Dwellings
{
    public class InstallHubRequest
    {
        public long DwellingId { get; set; }

        public long HubId { get; set; }
    }
}
