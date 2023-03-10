namespace Yatzy.Server.Dto;

public class PlayerDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public PlayerDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
