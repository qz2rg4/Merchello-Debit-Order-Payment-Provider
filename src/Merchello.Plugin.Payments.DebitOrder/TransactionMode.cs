namespace Merchello.Plugin.Payments.DebitOrder
{
    /// <summary>
    /// Indicates what sort of transaction should be processed
    /// </summary>
    public enum TransactionMode
    {
        /// <summary>
        /// An Authorize transaction
        /// </summary>
        Authorize,

        /// <summary>
        /// An Authorize and Capture transaction
        /// </summary>
        AuthorizeAndCapture
    }
}