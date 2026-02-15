using Microsoft.AspNetCore.Mvc;

namespace VotingService.Controllers
{
    public class VoteDTO
    {
        public string VotedName { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {
        public VotingController()
        {
        }

        [HttpPost("vote")]
        public async Task<IActionResult> VoteTo([FromBody] VoteDTO body)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Whoops! Wrong body format!");
            }

            return StatusCode(200, body);
        }
    }
}
