using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MTEFDataAccess.Entities;
using MTEFDataAccess.Infrastructure.Interfaces;
using MTEFDataAccess.Model;
using MTEFDataAccess.Repository;
using static MTEFDataAccess.Model.Records;

namespace MTEFDataAccess.Infrastructure.Implementation
{
    public class ArtistService : IArtistService
    {
        private readonly IGenericRepository<Artist> _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IGenericRepository<Artist> artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateArtist(CreateArtistRequest createArtistRequest, CancellationToken cancellationToken = default)
        {
            if (_artistRepository.TableNoTracking.Any(a => a.Title == createArtistRequest.Title))
                return Response<int>.Fail($"Artist with Title {createArtistRequest.Title} already exists");

            var artist = _mapper.Map<Artist>(createArtistRequest);

            await _artistRepository.InsertAsync(artist);

            await _artistRepository.SaveAsync(cancellationToken);

            return Response<int>.Success("Artist Created Successfully", artist.ArtistId);
        }

        public async Task<Response<IList<GetArtistResponse>>> SearchArtist(string artistName)
        {
            var artists = await _artistRepository.TableNoTracking
                .Where(a => EF.Functions.Like(a.Title, $"%{artistName}%"))
                .OrderByDescending(a => a.DateCreation)
                .ToListAsync();

            var response = _mapper.Map<IList<GetArtistResponse>>(artists);

            return Response<IList<GetArtistResponse>>.Success("Successful", response);
        }
    }
}
