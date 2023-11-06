using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private IHubContext<MessageHub> _hubContext;
        public MessageController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Send(string message, string destino)
        {
            await _hubContext.Clients.All.SendAsync(destino, message);

            return Ok();
        }

    }
}
