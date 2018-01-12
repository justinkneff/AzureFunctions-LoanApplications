using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Loans;

namespace LoanApplications
{
    public static class ProcessAcceptedApplications
    {
        [FunctionName("ProcessAcceptedApplications")]
        public static void Run(
            [BlobTrigger("accepted-applications/{name}", Connection = "")]string applicationJson, 
            string name, 
            TraceWriter log)
        {
            LoanApplication application = 
                JsonConvert.DeserializeObject<LoanApplication>(applicationJson);

            log.Info($"ProcessAcceptedApplications Blob trigger for \n Name:{application.Name} \n Age: {application.Age} ");
        }
    }
}
