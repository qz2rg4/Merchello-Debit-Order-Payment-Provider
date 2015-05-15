namespace Merchello.Plugin.Payment.PurchaseOrder.Bazaar.Controllers
{
    using System.Web.Mvc;

    using Merchello.Bazaar.Controllers;
    using Merchello.Bazaar.Models;
    using Merchello.Core.Gateways.Payment;
    using Merchello.Core.Models;
    using Merchello.Core.Sales;

    /// <summary>
    /// A controller to render and capture payment for a purchase order in a Merchello.Bazaar starter.
    /// </summary>
    public class PurchaseOrderController : BazaarPaymentMethodFormControllerBase
    {
        /// <summary>
        /// The view path.
        /// </summary>
        private const string ViewPath = "~/App_Plugins/Merchello.PurchaseOrder/Views/Partials/";

        public override ActionResult RenderForm(CheckoutConfirmationForm model)
        {
            throw new System.NotImplementedException();
        }

        protected override IPaymentResult PerformProcessPayment(SalePreparationBase preparation, IPaymentMethod paymentMethod)
        {
            throw new System.NotImplementedException();
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