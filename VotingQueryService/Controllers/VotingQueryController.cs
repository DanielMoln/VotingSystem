using Microsoft.AspNetCore.Mvc;

namespace VotingQueryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingQueryController : ControllerBase
    {
        private static readonly string[] USA_Presidents = new[]
        {
            "George Washington", "Abraham Lincoln", "Franklin D. Roosevelt", "John F. Kennedy", "Ronald Reagan", "Barack Obama"
        };

        private static readonly string[] USA_ModelGirlNames = new[]
        {
            "Cindy Crawford", "Tyra Banks", "Gigi Hadid", "Bella Hadid", "Kendall Jenner", "Christie Brinkley"
        };
        public VotingQueryController()
        {
        }

        [HttpGet("usa-presidents")]
        public ActionResult<List<string>> GetUP()
        {
            return USA_Presidents.ToList();
        }

        [HttpGet("usa-model-girl-names")]
        public ActionResult<List<string>> GetMGN()
        {
            return USA_ModelGirlNames.ToList();
        }
    }
}
