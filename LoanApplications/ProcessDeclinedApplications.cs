using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Loans;

namespace LoanApplications
{
    public static class ProcessDeclinedApplications
    {
        [FunctionName("ProcessDeclinedApplications")]
        public static void Run(
            [BlobTrigger("declined-applications/{name}", Connection = "")]string applicationJson, 
            string name, 
            TraceWriter log)
        {
            LoanApplication application =
                JsonConvert.DeserializeObject<LoanApplication>(applicationJson);

            log.Info($"ProcessDeclinedApplications Blob trigger for \n Name:{application.Name} \n Age: {application.Age} ");
        }
    }
}
