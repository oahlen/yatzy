using Microsoft.AspNetCore.Mvc;

using Yatzy.Server.Dto;
using Yatzy.Server.Services;

namespace Yatzy.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;

    private readonly ILogger<PlayerController> _logger;

    public PlayerController(PlayerService playerService, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _logger = logger;
    }

    [HttpGet]
    public Task<List<PlayerDto>> Get(CancellationToken cancellationToken)
    {
        return _playerService.GetPlayersAsync(cancellationToken);
    }

    [HttpPut]
    public Task<List<PlayerDto>> Put(List<string> names, CancellationToken cancellationToken)
    {
        return _playerService.PutPlayersAsync(names, cancellationToken);
    }
}
