using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("MatchPlayers")]
    public class MatchPlayers
    {
        [Key]
        public long PlayersMatchId { get; set; }
        public long MatchId { get; set; }
        public long PlayerId { get; set; }
        public int ChampionId { get; set; }
        public string Result { get; set; }
        public string Lane { get; set; }

        public MatchPlayers()
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
    }
}