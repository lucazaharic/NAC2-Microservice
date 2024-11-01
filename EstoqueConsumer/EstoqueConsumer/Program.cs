using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class EstoqueConsumer
{
    static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        const string fila = "produto_cadastrado";

        // Declara a fila
        channel.QueueDeclare(queue: fila, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, args) =>
        {
            var body = args.Body.ToArray();
            var mensagemJson = Encoding.UTF8.GetString(body);

            // Simula o processamento da mensagem no estoque
            Console.WriteLine($"Produto cadastrado recebido: {mensagemJson}");

            // Aqui você pode adicionar a lógica de atualização de inventário
            // Exemplo: deserializar a mensagem e salvar no banco de dados de estoque
        };

        channel.BasicConsume(queue: fila, autoAck: true, consumer: consumer);

        Console.WriteLine("Aguardando mensagens de produtos cadastrados...");
        Console.ReadLine();
    }
}
