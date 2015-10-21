namespace Merchello.Plugin.Payments.DebitOrder
{
    using Merchello.Core.Models;
    using Merchello.Plugin.Payments.DebitOrder.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// Extended data utiltity extensions
    /// </summary>
    public static class ExtendedDataExtensions
    {
        /// <summary>
        /// Saves the processor settings to an extended data collection
        /// </summary>
        /// <param name="extendedData">The <see cref="ExtendedDataCollection"/></param>
        /// <param name="processorSettings">The <see cref="DebitOrderProcessorSettings"/> to be serialized and saved</param>
        public static void SaveProcessorSettings(this ExtendedDataCollection extendedData, DebitOrderProcessorSettings processorSettings)
        {
            var settingsJson = JsonConvert.SerializeObject(processorSettings);

            extendedData.SetValue(Constants.ExtendedDataKeys.ProcessorSettings, settingsJson);
        }

        /// <summary>
        /// Get teh processor settings from the extended data collection
        /// </summary>
        /// <param name="extendedData">The <see cref="ExtendedDataCollection"/></param>
        /// <returns>The deserialized <see cref="DebitOrderProcessorSettings"/></returns>
        public static DebitOrderProcessorSettings GetProcessorSettings(this ExtendedDataCollection extendedData)
        {
            if (!extendedData.ContainsKey(Constants.ExtendedDataKeys.ProcessorSettings)) return new DebitOrderProcessorSettings();

            return
                JsonConvert.DeserializeObject<DebitOrderProcessorSettings>(
                    extendedData.GetValue(Constants.ExtendedDataKeys.ProcessorSettings));
        }
    }
}