using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace Content.Pipeline.CacheBuster.AzureFunction
{
    public class CacheBusterFunctions
    {
        [FunctionName("CacheBusterFunction")]
        [return: ServiceBus("notifier-topic", Connection = "Servicebus:ServicebusConnectionString")]
        public async Task<string> Run(
        [ServiceBusTrigger("cachebuster-topic","CacheBusterSubscription", Connection = "Servicebus:ServicebusConnectionString")]
        string message,
        Int32 deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {message}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");

            return message;
        }
    }
}
