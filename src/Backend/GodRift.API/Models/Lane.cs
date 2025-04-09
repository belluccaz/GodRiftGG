using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Lanes")]
    public class Lane
    {
        [Key]
        public int LaneId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LaneName { get; set; }

        public Lane()
        {
            if (LaneName == null)
            {
                LaneName = LaneId.ToString();
            }
        }

        public ICollection<ChampionsOnLane>? ChampionsOnLanes { get; set; }
    }
}