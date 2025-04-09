using System;

namespace GodRiftGG.API.DTOs;

public class ReadPlayersMatchItemDTO
{
    public long PlayersMatchId { get; set; }
    public int ItemId { get; set; }
    public int? Slot { get; set; }
    public string? SlotCategory { get; set; }
}

public class CreatePlayersMatchItemDTO
{
    public long PlayersMatchId { get; set; }
    public int ItemId { get; set; }
    public int? Slot { get; set; }
    public string? SlotCategory { get; set; }
}
