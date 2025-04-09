using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Players")]
    public class Player
    {
        public long PlayerId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nick { get; set; }

        [MaxLength(10)]
        public string? Tag { get; set; }

        [MaxLength(50)]
        public string? Server { get; set; }

        [MaxLength(50)]
        public string? Rank { get; set; }

        public int MatchesWon { get; set; } = 0;
        public int MatchesLost { get; set; } = 0;

        public ICollection<MatchPlayer> MatchPlayer { get; set; } = null!;
    }
}
