using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GodRiftGG.Models;

namespace GodRift.API.Models
{
    [Table("ChampionsOnLane")]
    public class ChampionsOnLane
    {
        public int ChampionId { get; set; }
        public Champion? Champion { get; set; }

        public int LaneId { get; set; }
        public Lane? Lane { get; set; }

        public double? PickRate { get; set; }
        public double? BanRate { get; set; }
    }



}