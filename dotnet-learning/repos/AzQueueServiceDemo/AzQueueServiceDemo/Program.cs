using AzQueueServiceDemo.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Text.Json;
using System.Threading.Tasks;



//for (int i = 0; i < 5; i++)
//{
//    await SendMessageToQueue($"Test Message {i + 1}");
//}
//async Task SendMessageToQueue(string message)
//{
//    QueueClient queueClient = new QueueClient(connectionString, queueName);
//    await queueClient.SendMessageAsync(message);
//    Console.WriteLine($"Sent message: {message}");
//}

public class AzureQueueService
{
    QueueClient queueClient;
    public AzureQueueService(string connectionString, string queueName)
    {
        //queueClient = new QueueClient(connectionString, queueName);  //This also works fine but the message will be in plain text
        queueClient = new QueueClient(connectionString, queueName, 
            new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64
            });
    }
    public async Task SendMessageAsync(string message)
    {
        await queueClient.SendMessageAsync(message);
        Console.WriteLine($"Sent message: {message}");
    }

    public async Task GetQueueMessagesAsync(int messageCount)
    {
        PeekedMessage[] messages = await queueClient.PeekMessagesAsync(maxMessages: messageCount);

        foreach(var msg in messages)
        {
            Console.WriteLine($"MessageId: {msg.MessageId}, MessageBody: {msg.Body}");
        }
    }

    public async Task ReceiveMessages(int messageCount)
    {
        QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: messageCount);
        foreach(var msg in messages)
        {
            Console.WriteLine($"MessageId: {msg.MessageId}, MessageBody: {msg.Body}");
            //await queueClient.DeleteMessageAsync(msg.MessageId, msg.PopReceipt);
        }
    }

    public async Task DeleteMessageAsync(int messageCount)
    {
        QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: messageCount);
        foreach(var msg in messages)
        {
            await queueClient.DeleteMessageAsync(msg.MessageId, msg.PopReceipt);
            Console.WriteLine($"Deleted MessageId: {msg.MessageId})");
        }
    }

    public void GetQueueProperties()
    {
        QueueProperties properties = queueClient.GetProperties();
        Console.WriteLine(properties.ApproximateMessagesCount);
        //Console.WriteLine($"ApproximateMessagesCount: {properties.ApproximateMessagesCount}");
    }

    public static async Task Main(string[] args)
    {
        string queueName = "{your-queue-name}";
        string connectionString = "{Your Azure Storage Connection String}";
        AzureQueueService queueService = new AzureQueueService(connectionString, queueName);
        //queueService.SendMessageAsync("Hello, Azure Queue!").GetAwaiter().GetResult();
        //queueService.GetQueueMessagesAsync(3).GetAwaiter().GetResult();
        //queueService.GetQueueProperties();
        //queueService.ReceiveMessages(3).GetAwaiter().GetResult();
        //queueService.DeleteMessageAsync(3).GetAwaiter().GetResult();

        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Gaming Laptop", Description = "A powerful gaming laptop" },
            new Product { Id = 2, Name = "Mobile Phone", Description = "Latest Smart Phone" },
            new Product { Id = 3, Name = "Headphones", Description = "Good sound quality" }
        };

        foreach(var product in products)
        {
            string message = JsonSerializer.Serialize(product);
            queueService.SendMessageAsync(message).GetAwaiter().GetResult();
            Console.WriteLine($"Sent product message: {message}");
        }
    }
}

