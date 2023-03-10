using Microsoft.AspNetCore.Mvc;

using Yatzy.Server.Dto;
using Yatzy.Server.Services;

namespace Yatzy.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultController : ControllerBase
{
    private readonly ResultService _resultService;

    private readonly ILogger<ResultService> _logger;

    public ResultController(ResultService resultService, ILogger<ResultService> logger)
    {
        _resultService = resultService;
        _logger = logger;
    }

    [HttpPost]
    public Task PostResults(List<ResultDto> results, CancellationToken cancellationToken)
    {
        return _resultService.StoreResultsAsync(results, cancellationToken);
    }
}
