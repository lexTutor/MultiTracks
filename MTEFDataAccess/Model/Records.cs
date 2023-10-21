using System.ComponentModel.DataAnnotations;

namespace MTEFDataAccess.Model
{
    public class Records
    {
        public record CreateArtistRequest ([Required] string Title, [Required] string Biography,
            [Required] string ImageUrl, [Required] string HeroUrl);

        public record GetSongResponse(int SongId, int AlbumId, int ArtistId, string Title, decimal BPM,
            string TimeSignature, bool Multitracks, bool CustomMix,  bool Chart, bool RehearsalMix,
            bool Patches, bool SongSpecificPatches, bool ProPresenter, DateTime DateCreation);

        public record GetArtistResponse(int ArtistId, string Title,
            string Biography, string ImageURL, string HeroURL, DateTime DateCreation);
    }
}
