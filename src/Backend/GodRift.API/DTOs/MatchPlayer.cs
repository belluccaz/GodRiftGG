using System;

namespace GodRiftGG.API.DTOs;

public class ReadMatchPlayerDTO
{
    public long PlayersMatchId { get; set; }
    public long? MatchId { get; set; }
    public int? PlayerId { get; set; }
    public int? ChampionId { get; set; }
    public string? Result { get; set; }
    public string? Lane { get; set; }
}

public class CreateMatchPlayerDTO
{
    public long? MatchId { get; set; }
    public int? PlayerId { get; set; }
    public int? ChampionId { get; set; }
    public string? Result { get; set; }
    public string? Lane { get; set; }
}
