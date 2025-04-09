using System;

namespace GodRiftGG.API.DTOs;

public class ChampionDTO
{
    public class ReadChampionDTO
    {
        public int ChampionId { get; set; }
        public required string ChampionName { get; set; }
        public string? Description { get; set; }
        public string? Difficulty { get; set; }
    }

    public class CreateChampionDTO
    {
        public required string ChampionName { get; set; }
        public string? Description { get; set; }
        public string? Difficulty { get; set; }
    }


}
