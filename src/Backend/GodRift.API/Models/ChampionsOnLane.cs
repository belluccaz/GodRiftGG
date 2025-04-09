using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("ChampionsOnLane")]
    public class ChampionsOnLane
    {
        [Key]
        public int ChampionId { get; set; }
        public int LaneId { get; set; }
        public float PickRate { get; set; }
        public float BanRate { get; set; }
    }


}