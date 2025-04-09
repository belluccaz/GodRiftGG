using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRift.API.Models
{
    [Table("Items")]

    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Type { get; set; }

        public Items()
        {
            if (ItemName == null)
            {
                ItemName = "";
            }
            if (Description == null)
            {
                Description = "";
            }
            if (Type == null)
            {
                Type = "";
            }
        }

        public ICollection<PlayersMatchItem>? PlayersMatchItems { get; set; }
    }
    public class ReadItemDTO
    {
        public int ItemId { get; set; }
        public required string ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Type { get; set; }
    }

    public class CreateItemDTO
    {
        public required string ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Type { get; set; }
    }


}

