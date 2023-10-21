using AutoMapper;
using MTEFDataAccess.Entities;
using MTEFDataAccess.Extensions;
using MTEFDataAccess.Infrastructure.Interfaces;
using MTEFDataAccess.Model;
using MTEFDataAccess.Repository;
using static MTEFDataAccess.Model.Records;

namespace MTEFDataAccess.Infrastructure.Implementation
{
    public class SongService : ISongService
    {
        private readonly IGenericRepository<Song> _songRepository;
        private readonly IMapper _mapper;

        public SongService(IGenericRepository<Song> songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public SearchResponse<GetSongResponse> ListSongs(SearchRequest searchModel)
        {
            var query = _songRepository.TableNoTracking.OrderByDescending(s => s.DateCreation);
            var totalCount = query.Count();

            return query.Paginate<Song, GetSongResponse>(_mapper, searchModel.Page, searchModel.PageSize, totalCount);
        }
    }
}
