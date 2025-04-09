using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("PlayersMatchItems")]
    public class PlayersMatchItem
    {
        [Key]
        public long PlayersMatchId { get; set; }
        public MatchPlayer? MatchPlayer { get; set; }
        public int ItemId { get; set; }
        public Items? Item { get; set; } = null!;
        public int? Slot { get; set; }
        public string? SlotCategory { get; set; }
    }
}