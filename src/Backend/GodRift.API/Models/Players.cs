using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Players")]
    public class Players
    {
        [Key]
        public long PlayerId { get; set; }
        public string Nick { get; set; }
        public string Tag { get; set; } = null!;
        public string Server { get; set; } = null!;
        public string Rank { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }

        [NotMapped]
        public int MatchesPlayed => MatchesWon + MatchesLost;

        //FK And Navigation
        public long? UserId { get; set; }
        public Users? User { get; set; }
        public Players()
        {
            if (Nick == null)
            {
                Nick = Tag;
            }
            if (Server == null)
            {
                Server = "";
            }
            if (Rank == null)
            {
                Rank = "Unranked";
            }
        }

        public ICollection<MatchPlayers>? MatchPlayers { get; set; }
    }
}