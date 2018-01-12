using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace LoanApplications
{
    public static class HouseKeeping
    {
        [Disable]
        [FunctionName("HouseKeeping")]
        public static void Run(
            [TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, 
            TraceWriter log)
        {
            log.Info($"C# Timer trigger housekeeping function executed at: {DateTime.Now}");
        }
    }
}
