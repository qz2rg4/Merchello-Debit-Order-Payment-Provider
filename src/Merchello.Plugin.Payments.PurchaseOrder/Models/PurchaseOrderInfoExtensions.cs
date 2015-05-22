namespace Merchello.Plugin.Payments.PurchaseOrder.Models
{
    using Merchello.Core.Gateways.Payment;

    /// <summary>
    /// The purchase order info extensions.
    /// </summary>
    public static class PurchaseOrderInfoExtensions
    {
        private const string PurchaseOrderKey = "purchaseOrderNumber";

        /// <summary>
        /// Maps the <see cref="PurchaseOrderFormData"/> to a <see cref="ProcessorArgumentCollection"/>
        /// </summary>
        /// <param name="purchaseOrder">
        /// The purchase order.
        /// </param>
        /// <returns>
        /// The <see cref="ProcessorArgumentCollection"/>.
        /// </returns>
        public static ProcessorArgumentCollection AsProcessorArgumentCollection(this PurchaseOrderFormData purchaseOrder)
        {
            return new ProcessorArgumentCollection()
            {
                { "purchaseOrderNumber", purchaseOrder.PurchaseOrderNumber }
            };
        }

        /// <summary>
        /// Maps the <see cref="ProcessorArgumentCollection"/> to a <see cref="PurchaseOrderFormData"/>
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="PurchaseOrderFormData"/>.
        /// </returns>
        public static PurchaseOrderFormData AsPurchaseOrderFormData(this ProcessorArgumentCollection args)
        {
            return new PurchaseOrderFormData()
            {
                PurchaseOrderNumber = args.ArgValue("purchaseOrderNumber")
            };
        }

        /// <summary>
        /// The set purchase order number.
        /// </summary>
        /// <param name="args">
        /// The <see cref="ProcessorArgumentCollection"/>
        /// </param>
        /// <param name="purchaseOrderNumber">
        /// The Purchase Order Number.
        /// </param>
        public static void SetPurchaseOrderNumber(this ProcessorArgumentCollection args, string purchaseOrderNumber)
        {
            if (args.ContainsKey(PurchaseOrderKey))
            {
                args[PurchaseOrderKey] = purchaseOrderNumber;
                return;
            }

            args.Add(PurchaseOrderKey, purchaseOrderNumber);
        }

        /// <summary>
        /// Utility method to check for the existence of a key in the <see cref="ProcessorArgumentCollection"/>
        /// </summary>
        /// <param name="args">
        /// The <see cref="ProcessorArgumentCollection"/>.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string ArgValue(this ProcessorArgumentCollection args, string key)
        {
            return args.ContainsKey(key) ? args[key] : string.Empty;
        }

    }
}