using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Yatzy.Server.Dto;

namespace Yatzy.Server.Models;

[Table("result")]
[Index(nameof(Game), Name = "fk_result_game")]
[Index(nameof(Player), Name = "fk_result_player")]
public class Result
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("game", TypeName = "int(11)")] public int? Game { get; set; }

    [Column("player", TypeName = "int(11)")]
    public int? Player { get; set; }

    [Column("position", TypeName = "int(11)")]
    public int Position { get; set; }

    [Column("score", TypeName = "int(11)")]
    public int Score { get; set; }

    [Column("yatzy")] public bool Yatzy { get; set; }

    [ForeignKey(nameof(Game))]
    [InverseProperty("Results")]
    public virtual Game? GameNavigation { get; set; }

    [ForeignKey(nameof(Player))]
    [InverseProperty("Results")]
    public virtual Player? PlayerNavigation { get; set; }

    public static explicit operator Result(ResultDto resultDto)
    {
        return new Result
        {
            Player = resultDto.Player,
            Position = resultDto.Position,
            Score = resultDto.Score,
            Yatzy = resultDto.Yatzy
        };
    }
}
