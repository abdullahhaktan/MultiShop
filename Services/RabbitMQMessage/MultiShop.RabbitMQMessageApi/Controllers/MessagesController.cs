using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ConnectionFactory _connectionFactory;

        public MessagesController()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync("Kuyruk2", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var result = await channel.BasicGetAsync("Kuyruk2", autoAck: true);

            if (result == null)
            {
                return NotFound("Kuyrukta okunacak mesaj bulunamadı.");
            }

            var message = Encoding.UTF8.GetString(result.Body.ToArray());

            return Ok(new
            {
                Message = message,
                MessageCountRemaining = result.MessageCount // Kuyrukta kalan mesaj sayısı
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] string? customMessage)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync("Kuyruk2", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var messageContent = string.IsNullOrEmpty(customMessage)
                ? "Merhaba bu bir rabbitmq kuyruk test mesajıdır"
                : customMessage;

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "Kuyruk2",
                mandatory: true,
                basicProperties: new BasicProperties(),
                body: byteMessageContent);

            return Ok("Mesajınız kuyruğa başarıyla eklendi.");
        }
    }
}