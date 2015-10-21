namespace Merchello.Plugin.Payment.DebitOrder.Bazaar.Controllers
{
    using System;
    using System.IO;
    using System.Web.Mvc;

    using Merchello.Bazaar.Controllers;
    using Merchello.Bazaar.Models;
    using Merchello.Core.Gateways;
    using Merchello.Core.Gateways.Payment;
    using Merchello.Core.Models;
    using Merchello.Core.Sales;
    using Merchello.Plugin.Payments.DebitOrder.Models;

    using Umbraco.Core;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// A controller to render and capture payment for a purchase order in a Merchello.Bazaar starter.
    /// </summary>
    [GatewayMethodUi("DebitOrder.DebitOrder")]
    [PluginController("Bazaar")]
    public class DebitOrderController : BazaarPaymentMethodFormControllerBase
    {
        /// <summary>
        /// The view path.
        /// </summary>
        private const string ViewPath = "~/App_Plugins/Merchello.DebitOrder/Views/Partials/";

        /// <summary>
        /// Responsible for rendering the purchase order form in the Bazaar.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public override ActionResult RenderForm(CheckoutConfirmationForm model)
        {
            return this.PartialView(this.GetPartialPath("DebitOrderPaymentMethodForm"), model);
        }

        protected override IPaymentResult PerformProcessPayment(SalePreparationBase preparation, IPaymentMethod paymentMethod)
        {
            // We have to use the CheckoutConfirmationModel in this implementation.  If this were to be used
            // outside of a demo, you could consider writing your own base controller that inherits directly from
            // Merchello.Web.Mvc.PaymentMethodUiController<TModel> and complete the transaction there in which case the 
            // BazaarPaymentMethodFormControllerBase would be a good example.

            var form = UmbracoContext.HttpContext.Request.Form;
            var DebitOrderNumber = form.Get("DebitOrderNumber");

            if (string.IsNullOrEmpty(DebitOrderNumber))
            {
                var invalidData = new InvalidDataException("The Purchase Order Number cannot be an empty string");
                return new PaymentResult(Attempt<IPayment>.Fail(invalidData), null, false);
            }

            // You need a ProcessorArgumentCollection for this transaction to store the payment method nonce
            // The braintree package includes an extension method off of the ProcessorArgumentCollection - SetPaymentMethodNonce([nonce]);
            var args = new ProcessorArgumentCollection();
            args.SetDebitOrderNumber(DebitOrderNumber);

            // We will want this to be an Authorize(paymentMethod.Key, args);
            // -- Also in a real world situation you would want to validate the PO number somehow.
            return preparation.AuthorizePayment(paymentMethod.Key, args);
        }

        /// <summary>
        /// Helper method to construct the path to the MVC Partial view for this plugin.
        /// </summary>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <returns>
        /// The virtual path to the partial view.
        /// </returns>
        private string GetPartialPath(string viewName)
        {
            viewName = viewName.EndsWith(".cshtml") ? viewName : viewName + ".cshtml";
            return string.Format("{0}{1}", ViewPath, viewName);
        }
    }
}