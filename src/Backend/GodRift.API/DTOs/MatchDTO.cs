using System;

namespace GodRiftGG.API.DTOs;

public class ReadMatchDTO
{
    public long MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public string? GameMode { get; set; }
    public int? Duration { get; set; }
}

public class CreateMatchDTO
{
    public DateTime MatchDate { get; set; }
    public string? GameMode { get; set; }
    public int? Duration { get; set; }
}

