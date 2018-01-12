using System;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Loans;

namespace ServiceBusQueueSender
{
    class Program
    {
        static void Main(string[] args)
        {         
            var connectionString = "( ͡° ͜ʖ ͡°)";
            var queueName = "loan-applications";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);            

            var application = new LoanApplication { Name = "SarahServiceBusTest", Age = 17 };

            var message = new BrokeredMessage(JsonConvert.SerializeObject(application));

            Console.WriteLine("Press enter to send");
            Console.ReadLine();

            client.Send(message);
            
            Console.WriteLine("Message sent");

            client.Close();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
