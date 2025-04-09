using System;

namespace GodRift.API.DTOs
{
    public class PlayerDTO
    {
        public long PlayerId { get; set; }
        public string Nick { get; set; } = null!;
        public string Tag { get; set; } = null!;
        public string Server { get; set; } = null!;
        public string Rank { get; set; } = "Unranked";
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesPlayed => MatchesWon + MatchesLost;
        public long? UserId { get; set; }
    }
    public class CreatePlayerDTO
    {
        public required string Nick { get; set; }
        public required string Tag { get; set; }
        public required string Server { get; set; }
        public required string Rank { get; set; }
    }
}
