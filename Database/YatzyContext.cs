using Microsoft.EntityFrameworkCore;

using Yatzy.Server.Models;

namespace Yatzy.Server.Database;

public class YatzyContext : DbContext
{
    public YatzyContext()
    {
    }

    public YatzyContext(DbContextOptions<YatzyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; } = null!;
    public virtual DbSet<Player> Players { get; set; } = null!;
    public virtual DbSet<Result> Results { get; set; } = null!;
    public virtual DbSet<Highscore> Highscores { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasOne(d => d.GameNavigation)
                .WithMany(p => p.Results)
                .HasForeignKey(d => d.Game)
                .HasConstraintName("fk_result_game");

            entity.HasOne(d => d.PlayerNavigation)
                .WithMany(p => p.Results)
                .HasForeignKey(d => d.Player)
                .HasConstraintName("fk_result_player");
        });

        modelBuilder.Entity<Highscore>().HasNoKey();
    }
}
