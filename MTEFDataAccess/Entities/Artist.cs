using System.ComponentModel.DataAnnotations.Schema;

namespace MTEFDataAccess.Entities
{
    public class Artist : BaseEntity
    {
        [Column("artistID")]
        public int ArtistId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("biography")]
        public string Biography { get; set; }

        [Column("imageURL")]
        public string ImageURL { get; set; }

        [Column("heroURL")]
        public string HeroURL { get; set; }
    }
}
