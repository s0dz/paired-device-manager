namespace PairedDeviceManager.Contract.Requests.Hubs
{
    public class PairDeviceRequest
    {
        public long DeviceId { get; set; }

        public long HubId { get; set; }
    }
}
