namespace Yatzy.Server.Models;

public class Highscore
{
    public string PlayerName { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Games { get; set; }

    public int Record { get; set; }

    public int Yatzy { get; set; }

    public Highscore(string playerName, int wins, int losses, int games, int record, int yatzy)
    {
        PlayerName = playerName;
        Wins = wins;
        Losses = losses;
        Record = record;
    }
}
