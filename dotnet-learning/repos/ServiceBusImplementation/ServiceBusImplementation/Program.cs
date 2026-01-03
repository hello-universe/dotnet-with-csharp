using Azure.Messaging.ServiceBus;
using ServiceBusImplementation.Models;
using System.Text.Json;

namespace ServiceBusImplementation
{
    public class ServiceBusCustomImplementation
    {
        private readonly string _queueName;
        private readonly string _connectionString;

        public ServiceBusCustomImplementation(string queueName, string connectionString)
        {
            _queueName = queueName;
            _connectionString = connectionString;
        }

        public async Task SendMessageAsync(List<Order> orders)
        {
            ServiceBusClient client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            {
                foreach (var order in orders)
                {
                    ServiceBusMessage serviceBusMessage = new ServiceBusMessage(JsonSerializer.Serialize(order));
                    serviceBusMessage.ContentType = "application/json";
                    serviceBusMessage.ApplicationProperties.Add("Month", "October"); //Application properties are key-value pairs that you can use to add custom metadata to the message.
                    if (!messageBatch.TryAddMessage(serviceBusMessage))
                    {
                        throw new Exception($"The message {order.Id} is too large to fit in the batch.");
                    }
                }
            }
            await sender.SendMessagesAsync(messageBatch);
            Console.WriteLine($"A batch of {orders.Count} orders has been published to the queue.");
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }

        public async Task PeekMessages(int maxMessages)
        {
            ServiceBusClient client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.PeekMessagesAsync(maxMessages);
            foreach (var message in receivedMessages)
            {
                string body = message.Body.ToString();
                Order? order = JsonSerializer.Deserialize<Order>(body);
                if (order != null)
                {
                    Console.WriteLine($"Order Id: {order.Id}, Product Name: {order.ProductName}, Quantity: {order.Quantity}");
                    Console.WriteLine($"Month: {message.ApplicationProperties["Month"]}");  //Printing custom application property
                }
            }
            await receiver.DisposeAsync();
            await client.DisposeAsync();
        }

        public async Task ReceiveMessages(int maxMessages)
        {
            ServiceBusClient client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName, new ServiceBusReceiverOptions { ReceiveMode=ServiceBusReceiveMode.ReceiveAndDelete});
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages);
            foreach (var message in receivedMessages)
            {
                string body = message.Body.ToString();
                Order? order = JsonSerializer.Deserialize<Order>(body);
                if (order != null)
                {
                    Console.WriteLine($"Order Id: {order.Id}, Product Name: {order.ProductName}, Quantity: {order.Quantity}");
                }
                //await receiver.CompleteMessageAsync(message); //CompleteMessageAsync() is only valid in PeekLock mode, where you manually complete (or abandon/defer/dead-letter) messages.
            }
            await receiver.DisposeAsync();
            await client.DisposeAsync();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string queueName = "{Your Service Bus Queue Name}";
            string connectionString = "{Your Service Bus Connection String}";

            List<Order> orders = new List<Order>
            {
                new Order { Id = 1, ProductName = "Laptop", Quantity = 2 },
                new Order { Id = 2, ProductName = "Smartphone", Quantity = 5 },
                new Order { Id = 3, ProductName = "Tablet", Quantity = 3 }
            };

            ServiceBusCustomImplementation sb = new ServiceBusCustomImplementation(queueName, connectionString);
            //sb.SendMessageAsync(orders).GetAwaiter().GetResult();
            sb.PeekMessages(2).GetAwaiter().GetResult();
            //sb.ReceiveMessages(2).GetAwaiter().GetResult();
        }
    }
}
