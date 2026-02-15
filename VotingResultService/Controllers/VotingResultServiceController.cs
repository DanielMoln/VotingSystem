using Microsoft.AspNetCore.Mvc;

namespace VotingResultService.Controllers
{
    public class Results
    {
        public Dictionary<string, int> SummedResults { get; set; } = new();
    }


    [ApiController]
    [Route("[controller]")]
    public class VotingResultService : ControllerBase
    {
        private readonly List<Results> Results = new List<Results>();

        public VotingResultService()
        {
            var summedResults = new Dictionary<string, int>();
            summedResults.Add("e4232c", 12_325);

            Results.Add(new Results
            {
                SummedResults = summedResults
            });
        }

        [HttpGet("display-results")]
        public ActionResult<List<Results>> DisplayResults()
        {
            return StatusCode(200, Results);
        }
    }
}
