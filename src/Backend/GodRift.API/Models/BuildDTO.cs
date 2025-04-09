using System;

namespace GodRiftGG.API.Models;

public class ReadBuildDTO
{
    public long BuildId { get; set; }
    public string? Name { get; set; }
    public int? ChampionId { get; set; }
}

public class CreateBuildDTO
{
    public string? Name { get; set; }
    public int? ChampionId { get; set; }
}

