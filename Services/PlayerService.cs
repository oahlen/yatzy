using Microsoft.EntityFrameworkCore;

using Yatzy.Server.Database;
using Yatzy.Server.Dto;
using Yatzy.Server.Models;

namespace Yatzy.Server.Services;

public class PlayerService
{
    private readonly YatzyContext _context;

    public PlayerService(YatzyContext context)
    {
        _context = context;
    }

    public Task<List<PlayerDto>> GetPlayersAsync(CancellationToken cancellationToken)
    {
        return _context.Players
            .Where(x => x.Active)
            .OrderBy(x => x.Id)
            .Take(10)
            .Select(x => new PlayerDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<PlayerDto>> PutPlayersAsync(List<string> names, CancellationToken cancellationToken)
    {
        var result = new List<Player>();

        foreach (var name in names)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Name == name);

            if (player == null)
            {
                player = new Player { Name = name };
                _context.Players.Add(player);
            }

            result.Add(player);
        }

        await _context.SaveChangesAsync(true, cancellationToken);
        return result.Select(x => new PlayerDto(x.Id, x.Name)).ToList();
    }
}
