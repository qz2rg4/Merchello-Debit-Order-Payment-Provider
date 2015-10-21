namespace Merchello.Plugin.Payments.DebitOrder
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The extended data keys.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]
        public static class ExtendedDataKeys
        {
            /// <summary>
            /// The processor settings.
            /// </summary>
            public static string ProcessorSettings = "DebitOrderProcessorSettings";

            /// <summary>
            /// The purchase order number prefix.
            /// </summary>
            public static string DebitOrderNumber = "DebitOrderNumber"; 

            /// <summary>
            /// The purchase order number prefix.
            /// </summary>
            public static string DebitOrderNumberPrefix = "DebitOrderNumberPrefix";

            /// <summary>
            /// The authorization result.
            /// </summary>
            public static string AuthorizationTransactionResult = "purcahseOrderAuthorizeTransactionResult";       
            
            /// <summary>
            /// The capture transaction result.
            /// </summary>
            public static string CaptureTransactionResult = "DebitOrderCaptureTransactionResult";
        }
    }
}