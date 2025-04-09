using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Matches")]
    public class Matches
    {
        [Key]
        public long MatchId { get; set; }
        public DateTime MatchDate { get; set; }

        public string GameMode { get; set; }

        public int Duration { get; set; }

        public Matches()
        {
            if (GameMode == null)
            {
                GameMode = "";
            }
        }
    }

}