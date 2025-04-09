using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GodRift.API.Models;
using Microsoft.Identity.Client;

namespace GodRiftGG.Models;


[Table("Champions")]
public class Champion
{
    public int ChampionId { get; set; }

    [Required]
    [MaxLength(100)]
    public string ChampionName { get; set; }

    public string? Description { get; set; }

    [MaxLength(50)]
    public string? Difficulty { get; set; }

    public ICollection<ChampionsOnLane>? ChampionsOnLanes { get; set; }

    public ICollection<Build> Builds { get; set; }
    public ICollection<MatchPlayer> MatchPlayers { get; set; }

    public Champion()
    {
        Builds = new List<Build>();
        MatchPlayers = new List<MatchPlayer>();

        if (ChampionName == null)
        {
            ChampionName = ChampionId.ToString();
        }
    }
}
