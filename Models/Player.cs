using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yatzy.Server.Models;

[Table("player")]
public class Player
{
    public Player()
    {
        Results = new HashSet<Result>();
    }

    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty(nameof(Result.PlayerNavigation))]
    public ICollection<Result> Results { get; set; }
}
