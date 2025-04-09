using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Matches")]
    public class Match
    {
        public long MatchId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [MaxLength(50)]
        public string? GameMode { get; set; }

        public int? Duration { get; set; } // Em segundos?

        public ICollection<MatchPlayer>? MatchPlayers { get; set; }
    }


}