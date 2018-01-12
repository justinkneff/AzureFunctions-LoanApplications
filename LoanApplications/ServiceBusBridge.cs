using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Loans;

namespace LoanApplications
{
    public static class ServiceBusBridge
    {
        [FunctionName("ServiceBusBridge")]
        public static void Run(
            [ServiceBusTrigger("loan-applications", AccessRights.Listen, Connection = "")]
            string applicationJson,
            [Queue("loan-applications")] out LoanApplication application,            
            TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {applicationJson}");

            application = JsonConvert.DeserializeObject<LoanApplication>(applicationJson);
        }
    }
}
