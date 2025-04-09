using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodRiftGG.Models
{
    [Table("Builds")]
    public class Builds
    {
        [Key]
        public long BuildId { get; set; }
        public string Name { get; set; }
        public int ChampionId { get; set; }

        public Builds()
        {
            if (Name == null)
            {
                Name = ChampionId.ToString();
            }
        }
    }
}