using Microsoft.AspNetCore.Mvc;
using SharedData;

namespace EventBusService.Controllers
{
    public class EventPacketDTO
    {
        public EventPacketType EventPacketType { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class EventBusController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public EventBusController()
        {
        }

        [HttpPost("packet-handler")]
        public async Task<IActionResult> HandleIncomingPackets([FromBody] EventPacketDTO body)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Hiba! Rossz formátumú adat!");
            }

            return StatusCode(200, "Ok");
        }
    }
}
