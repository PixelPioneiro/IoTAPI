using IoTAPI.Data;
using IoTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using HiveMQtt.Client;

namespace IoTAPI.Controllers
{
    public class PubSubController : Controller
    {
        private readonly IoTAPIDbContext? _context;
        public PubSubController(IoTAPIDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Subscribe()
        {
            var pubSub = new PubSub("db9018babe9b4ed6b86b0baa7361c13c.s1.eu.hivemq.cloud", 8883, "device-001", "4eklçfjcpZOSI3!!!@", "balanca/feijao/peso");
            var clientOptions = new HiveMQClientOptionsBuilder()
                .WithClientId("PesoFeijao")
                .WithBroker(pubSub.Host)
                .WithPort((int)pubSub.Port)
                .WithUserName(pubSub.User)
                .WithPassword(pubSub.Password)
                .Build();

            var client = new HiveMQClient(clientOptions);

            client.OnMessageReceived += (sender, args) =>
            {
                // Handle Message in args.PublishMessage
                Console.WriteLine($"Message Received: {args.PublishMessage.PayloadAsString}");
            };

            await client.ConnectAsync().ConfigureAwait(false);
            await client.SubscribeAsync(pubSub.Topic).ConfigureAwait(false);

            return Ok("Subscrição no tópico realizado com sucesso.");
        }
    }
}