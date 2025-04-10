using System;
using GodRift.API.Models;

namespace GodRiftGG.API.DTOs;

public class ReadMatchDTO
{
    public long MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public string? GameMode { get; set; }
    public int? Duration { get; set; }
    public ICollection<MatchPlayer>? Players { get; set; }
}


