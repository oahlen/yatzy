namespace Yatzy.Server.Dto;

public class HighscoreDto
{
    public string PlayerName { get; set; }

    public int Games { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Record { get; set; }

    public int Yatzy { get; set; }

    public HighscoreDto(string playerName, int games, int wins, int losses, int record, int yatzy)
    {
        PlayerName = playerName;
        Games = games;
        Wins = wins;
        Losses = losses;
        Record = record;
        Yatzy = yatzy;
    }
}
