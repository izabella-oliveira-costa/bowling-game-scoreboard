using BowlingGameScoreboard.Models;
using BowlingGameScoreboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGameScoreboard.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlingController : ControllerBase
{
    private readonly BowlingService _service;

    public BowlingController(BowlingService service)
    {
        _service = service;
    }

    [HttpPost("score")]
    public ActionResult<ScoreResponse> Calculate(
        ScoreRequest request)
    {
        var score = _service.Calculate(request.Rolls);

        return Ok(new ScoreResponse
        {
            Score = score
        });
    }
}