using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Loans;

namespace LoanApplications
{
    public static class MakeApplication
    {
        [FunctionName("MakeApplication")]
        [return: Queue("loan-applications")]
        public static async Task<LoanApplication> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequestMessage req,
            //[Queue("loan-applications")] out string message,
            //[Queue("loan-applications")] IAsyncCollector<LoanApplication> messageQueue,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            LoanApplication application = await req.Content.ReadAsAsync<LoanApplication>();

            log.Info($"Application received: {application.Name} {application.Age}");

            // TODO: write to queue
            //await messageQueue.AddAsync(application);
            return application;

            //return req.CreateResponse(HttpStatusCode.OK, 
            //                          $"Loan application submitted for {application.Name}");
        }
    }
}
