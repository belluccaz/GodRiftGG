using GodRiftGG.Models;

public class Builds
{
    public long BuildId { get; set; }
    public string Name { get; set; } = null!;
    public long ChampionId { get; set; }
    public Champions Champion { get; set; } = null!;
}
