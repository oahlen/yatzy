namespace Yatzy.Server.Dto;

public class HighscoreDto
{
    public string PlayerName { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Games { get; set; }

    public int Record { get; set; }

    public int Yatzy { get; set; }

    public HighscoreDto(string playerName, int wins, int losses, int games, int record, int yatzy)
    {
        PlayerName = playerName;
        Wins = wins;
        Losses = losses;
        Games = games;
        Record = record;
        Yatzy = yatzy;
    }
}
