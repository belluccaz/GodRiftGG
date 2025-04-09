using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GodRiftGG.Models;

namespace GodRift.API.Models
{
    [Table("MatchPlayers")]
    public class MatchPlayer
    {
        [Key]
        public long PlayersMatchId { get; set; }
        public long? MatchId { get; set; }
        public Match? Match { get; set; }
        public long? PlayerId { get; set; }
        public Player? Player { get; set; }
        public int? ChampionId { get; set; }
        public Champion? Champion { get; set; }
        public string? Result { get; set; }
        public string? Lane { get; set; }

        public MatchPlayer()
        {
            if (Result == null)
            {
                Result = "";
            }
            if (Lane == null)
            {
                Lane = "";
            }
        }
        public ICollection<PlayersMatchItem>? Items { get; set; }
    }
}