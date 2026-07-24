using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            return Ok("Mesajınız kuyruğa alınmıştır");
        }
    }
}
