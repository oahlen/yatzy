using Yatzy.Server.Database;
using Yatzy.Server.Dto;
using Yatzy.Server.Models;

namespace Yatzy.Server.Services;

public class ResultService
{
    private readonly YatzyContext _context;

    public ResultService(YatzyContext context)
    {
        _context = context;
    }

    public Task StoreResultsAsync(IEnumerable<ResultDto> results, CancellationToken cancellationToken)
    {
        var game = new Game { Played = DateOnly.FromDateTime(DateTime.UtcNow) };

        foreach (var result in results.Select(x => (Result)x))
        {
            game.Results.Add(result);
        }

        _context.Games.Add(game);
        return _context.SaveChangesAsync(true, cancellationToken);
    }
}
