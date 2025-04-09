using System;

namespace GodRiftGG.API.DTOs;

public class ReadLaneDTO
{
    public int LaneId { get; set; }
    public required string LaneName { get; set; }
}

public class CreateLaneDTO
{
    public required string LaneName { get; set; }
}

