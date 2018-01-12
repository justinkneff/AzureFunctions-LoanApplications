using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Loans;

namespace LoanApplications
{
    public static class ScoreApplication
    {
        [FunctionName("ScoreApplication")]
        public static void Run(
            [QueueTrigger("loan-applications", Connection = "")]LoanApplication application,
            [Blob("accepted-applications/{rand-guid}")] out string acceptedApplication,
            [Blob("declined-applications/{rand-guid}")] out string declinedApplication,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {application.Name}");

            var scorer = new LoanScorer();

            bool isAccepted = scorer.LoanAccepted(application);

            if (isAccepted)
            {
                // Write to accepted blob container
                acceptedApplication = JsonConvert.SerializeObject(application);
                declinedApplication = null;
            }
            else
            {
                // Write to declined blob container
                declinedApplication = JsonConvert.SerializeObject(application);
                acceptedApplication = null;
            }
        }
    }
}
