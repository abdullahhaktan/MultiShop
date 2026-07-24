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
        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using var connection = await connectionFactory.CreateConnectionAsync(); // using eklendi
            using var channel = await connection.CreateChannelAsync(); // using eklendi

            await channel.QueueDeclareAsync("Kuyruk2",false,false,false,arguments:null);

            var messageContent = "Merhaba bu bir rabbitmq kuyruk test mesajıdır";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            await channel.BasicPublishAsync(exchange: "", routingKey: "Kuyruk2", mandatory:true, basicProperties: new BasicProperties(), body: byteMessageContent);

            return Ok("Mesajınız kuyruğa alınmıştır");
        }
    }
}