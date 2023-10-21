using System.ComponentModel.DataAnnotations.Schema;

namespace MTEFDataAccess.Entities
{
    public class Song : BaseEntity
    {
        [Column("songID")]
        public int SongId { get; set; }

        [Column("albumID")]
        public int AlbumId { get; set; }

        [Column("artistID")]
        public int ArtistId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("bpm")]
        public decimal BPM { get; set; }

        [Column("timeSignature")]
        public string TimeSignature { get; set; }

        [Column("multitracks")]
        public bool Multitracks { get; set; }

        [Column("customMix")]
        public bool CustomMix { get; set; }

        [Column("chart")]
        public bool Chart { get; set; }

        [Column("rehearsalMix")]
        public bool RehearsalMix { get; set; }

        [Column("patches")]
        public bool Patches { get; set; }

        [Column("songSpecificPatches")]
        public bool SongSpecificPatches { get; set; }

        [Column("proPresenter")]
        public bool ProPresenter { get; set; }
    }
}
