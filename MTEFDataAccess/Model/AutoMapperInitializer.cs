using AutoMapper;
using MTEFDataAccess.Entities;
using static MTEFDataAccess.Model.Records;

namespace MTEFDataAccess.Model
{
    public class AutoMapperInitializer : Profile
    {
        public AutoMapperInitializer()
        {
            CreateMap<Artist, GetArtistResponse>()
                .ForCtorParam(nameof(GetArtistResponse.HeroURL), opt => opt.MapFrom(src => src.HeroURL))
                .ForCtorParam(nameof(GetArtistResponse.ImageURL), opt => opt.MapFrom(src => src.ImageURL))
                .ForCtorParam(nameof(GetArtistResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(GetArtistResponse.Biography), opt => opt.MapFrom(src => src.Biography))
                .ForCtorParam(nameof(GetArtistResponse.DateCreation), opt => opt.MapFrom(src => src.DateCreation))
                .ForCtorParam(nameof(GetArtistResponse.ArtistId), opt => opt.MapFrom(src => src.ArtistId));

            CreateMap<CreateArtistRequest, Artist>();

            CreateMap<Song, GetSongResponse>()
                .ForCtorParam(nameof(GetSongResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(GetSongResponse.SongId), opt => opt.MapFrom(src => src.SongId))
                .ForCtorParam(nameof(GetSongResponse.AlbumId), opt => opt.MapFrom(src => src.AlbumId))
                .ForCtorParam(nameof(GetSongResponse.ArtistId), opt => opt.MapFrom(src => src.ArtistId))
                .ForCtorParam(nameof(GetSongResponse.BPM), opt => opt.MapFrom(src => src.BPM))
                .ForCtorParam(nameof(GetSongResponse.TimeSignature), opt => opt.MapFrom(src => src.TimeSignature))
                .ForCtorParam(nameof(GetSongResponse.Multitracks), opt => opt.MapFrom(src => src.Multitracks))
                .ForCtorParam(nameof(GetSongResponse.CustomMix), opt => opt.MapFrom(src => src.CustomMix))
                .ForCtorParam(nameof(GetSongResponse.Chart), opt => opt.MapFrom(src => src.Chart))
                .ForCtorParam(nameof(GetSongResponse.RehearsalMix), opt => opt.MapFrom(src => src.RehearsalMix))
                .ForCtorParam(nameof(GetSongResponse.Patches), opt => opt.MapFrom(src => src.Patches))
                .ForCtorParam(nameof(GetSongResponse.SongSpecificPatches), opt => opt.MapFrom(src => src.SongSpecificPatches))
                .ForCtorParam(nameof(GetSongResponse.ProPresenter), opt => opt.MapFrom(src => src.ProPresenter));

        }
    }
}
