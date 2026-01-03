using Azure.Messaging.EventHubs.Producer;
using EventHubImplementation.Models;

namespace EventHubImplementation
{
    public class EventHubCustomClass
    {
        private string _connectionString;

        public EventHubCustomClass(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task SendEvents(List<Device> devices)
        {
            EventHubProducerClient producerClient = new EventHubProducerClient(_connectionString);
            using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
            {

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "{Your Event Hub Connection String}";
            List<Device> devices = new List<Device>()
            {
                new Device() { Id = 1, Temperature = "22.5" },
                new Device() { Id = 2, Temperature = "23.0" },
                new Device() { Id = 3, Temperature = "21.8" }
            };
        }
    }
}
