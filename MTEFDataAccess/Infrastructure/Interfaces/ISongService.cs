using MTEFDataAccess.Model;
using static MTEFDataAccess.Model.Records;

namespace MTEFDataAccess.Infrastructure.Interfaces
{
    public interface ISongService
    {
        SearchResponse<GetSongResponse> ListSongs(SearchRequest searchModel);
    }
}
