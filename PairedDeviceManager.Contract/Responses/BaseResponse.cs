namespace PairedDeviceManager.Contract.Responses
{
    /// <summary>
    /// Base response.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Whether the request resulted in a successful operation.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional message related to the Status.
        /// </summary>
        public string Message { get; set; }
    }
}
