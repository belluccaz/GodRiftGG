using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("PlayersMatchItems")]
    public class PlayersMatchItems
    {
        [Key]
        public long PlayersMatchId { get; set; }
        public MatchPlayers? MatchPlayer { get; set; }
        public int ItemId { get; set; }
        public Items? Item { get; set; } = null!;
        public int? Slot { get; set; }
        public string? SlotCategory { get; set; }
    }
}