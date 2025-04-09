using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Lanes")]
    public class Lanes
    {
        [Key]
        public int LaneId { get; set; }
        public string LaneName { get; set; }

        public Lanes()
        {
            if (LaneName == null)
            {
                LaneName = LaneId.ToString();
            }
        }
    }
}