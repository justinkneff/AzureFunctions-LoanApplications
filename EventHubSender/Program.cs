using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using Loans;

namespace EventHubSender
{
    class Program
    {               
        static async Task Main(string[] args)
        {
            EventHubClient client = CreateEventHubClient();

            var message = new LoanApplication
            {
                Name = "SarahEventHubTest",
                Age = 20
            };

            Console.WriteLine("Press enter to send");
            Console.ReadLine();

            await client.SendAsync(
                new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message))));

            Console.WriteLine("Message sent");

            await client.CloseAsync();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }


        private static EventHubClient CreateEventHubClient()
        {
            const string ConnectionString =
                "( ͡° ͜ʖ ͡°)";

            var connectionStringBuilder = 
                new EventHubsConnectionStringBuilder(ConnectionString);

            return EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }
    }
}
