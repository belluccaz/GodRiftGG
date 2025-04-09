using System;

namespace GodRiftGG.API.DTOs;

public class ReadChampionsOnLaneDTO
{
    public int ChampionId { get; set; }
    public int LaneId { get; set; }
    public double? PickRate { get; set; }
    public double? BanRate { get; set; }
}

public class CreateChampionsOnLaneDTO
{
    public int ChampionId { get; set; }
    public int LaneId { get; set; }
    public double? PickRate { get; set; }
    public double? BanRate { get; set; }
}
