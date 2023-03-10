using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yatzy.Server.Models;

[Table("game")]
public class Game
{
    public Game()
    {
        Results = new HashSet<Result>();
    }

    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("played")]
    public DateOnly Played { get; set; }

    [InverseProperty(nameof(Result.GameNavigation))]
    public ICollection<Result> Results { get; set; }
}
