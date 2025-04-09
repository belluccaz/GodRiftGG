using GodRift.API.Models;
using GodRiftGG.Models;

public class Build
{
    public long BuildId { get; set; }
    public string Name { get; set; } = null!;
    public long? ChampionId { get; set; }
    public Champion? Champion { get; set; } = null!;

    public ICollection<Items>? Item { get; set; }
}
