using Microsoft.AspNetCore.Mvc;

using Yatzy.Server.Dto;
using Yatzy.Server.Services;

namespace Yatzy.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HighscoreController : ControllerBase
{
    private readonly HighscoreService _highscoreService;

    private readonly ILogger<HighscoreController> _logger;

    public HighscoreController(HighscoreService highscoreService, ILogger<HighscoreController> logger)
    {
        _highscoreService = highscoreService;
        _logger = logger;
    }

    [HttpGet]
    public Task<List<HighscoreDto>> Get(CancellationToken cancellationToken)
    {
        return _highscoreService.GetHighscoresAsync(cancellationToken);
    }
}
