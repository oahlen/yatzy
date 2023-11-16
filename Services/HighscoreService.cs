using Microsoft.EntityFrameworkCore;

using Yatzy.Server.Database;
using Yatzy.Server.Dto;

namespace Yatzy.Server.Services;

public class HighscoreService
{
    private readonly YatzyContext _context;

    public HighscoreService(YatzyContext context)
    {
        _context = context;
    }

    public Task<List<HighscoreDto>> GetHighscoresAsync(CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT
            p.name AS PlayerName,
            COUNT(r.id) AS Games,
            COUNT(CASE WHEN r.position = 1 THEN 1 END) AS Wins,
            COUNT(CASE WHEN r.position > 1 THEN 1 END) AS Losses,
            MAX(score) AS Record,
            COUNT(CASE WHEN r.yatzy = 1 THEN 1 END) AS Yatzy
            FROM result r
            JOIN player p ON p.id = r.player
            GROUP BY p.id
            ORDER BY wins DESC
            LIMIT 5";

        return _context.Highscores.FromSqlRaw(sql)
            .Select(x => new HighscoreDto(x.PlayerName, x.Games, x.Wins, x.Losses, x.Record, x.Yatzy))
            .ToListAsync(cancellationToken);
    }
}
