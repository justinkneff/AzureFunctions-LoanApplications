using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Newtonsoft.Json;
using Loans;

namespace LoanApplications
{
    public static class EventHubBridge
    {
        [FunctionName("EventHubBridge")]
        public static void Run(
            [EventHubTrigger("loan-applications", Connection = "AzureWebJobsLoanApplicationsEventHub")]
            string applicationJson,
            [Queue("loan-applications")] out LoanApplication application,
            TraceWriter log)
        {
            log.Info($"C# Event Hub trigger function processed a message: {applicationJson}");

            application = JsonConvert.DeserializeObject<LoanApplication>(applicationJson);
        }
    }
}
