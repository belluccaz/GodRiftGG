using System;

namespace GodRiftGG.API.DTOs;

public class CreatePlayerDTO
{
    public string Nick { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string Server { get; set; } = null!;
    public string Rank { get; set; } = "Unranked";
    public int MatchesWon { get; set; }
    public int MatchesLost { get; set; }
    public long? UserId { get; set; }
}
