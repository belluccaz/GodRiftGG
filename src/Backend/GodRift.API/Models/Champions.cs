using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GodRift.API.Models;
using Microsoft.Identity.Client;

namespace GodRiftGG.Models

{
    [Table("Champions")]
    public class Champions
    {
        [Key]
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }

        public Champions()
        {
            if (ChampionName == null)
            {
                ChampionName = ChampionId.ToString();
            }
            if (Description == null)
            {
                Description = "";
            }
            if (Difficulty == null)
            {
                Difficulty = "";
            }
        }
        public ICollection<ChampionsOnLane>? ChampionsOnLane { get; set; }
        public ICollection<Builds>? Builds { get; set; }
        public ICollection<MatchPlayers>? MatchPlayers { get; set; }
    }
}
