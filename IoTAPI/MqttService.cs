using System.Text;
using System.Text.Json;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace IoTAPI
{

    public class MqttService
    {
        private readonly IServiceProvider _serviceProvider; // Para acessar outros serviços, como o de banco de dados
        private IMqttClient _mqttClient;

        public MqttService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithClientId("estoque-client")
                .WithTcpServer("broker.hivemq.com") // Substitua pelo endereço do seu broker HiveMQ
                .WithCleanSession()
                .Build();

            _mqttClient.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Conectado ao broker HiveMQ!");

                // Subscrever aos tópicos necessários
                await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("estoque/atualizar").Build());
            });

            _mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"Mensagem recebida no tópico {e.ApplicationMessage.Topic}: {payload}");

                // Processar a mensagem (exemplo: salvar no banco de dados)
                ProcessarMensagem(payload);
            });

            await _mqttClient.ConnectAsync(options);
        }

        private void ProcessarMensagem(string mensagem)
        {
            // Aqui você pode processar os dados recebidos do tópico
            // Por exemplo: deserializar JSON e salvar no banco
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SeuDbContext>(); // Exemplo com Entity Framework

            var dados = JsonSerializer.Deserialize<DadosEstoque>(mensagem); // Substitua por seu modelo
            dbContext.Add(dados);
            dbContext.SaveChanges();
        }

        public async Task StopAsync()
        {
            if (_mqttClient != null)
            {
                await _mqttClient.DisconnectAsync();
            }
        }
    }

    // Exemplo de classe para deserializar os dados do estoque
    public class DadosEstoque
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
    }

}
