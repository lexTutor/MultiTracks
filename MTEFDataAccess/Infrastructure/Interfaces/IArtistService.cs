using MTEFDataAccess.Model;
using static MTEFDataAccess.Model.Records;

namespace MTEFDataAccess.Infrastructure.Interfaces
{
    public interface IArtistService
    {
        Task<Response<int>> CreateArtist(CreateArtistRequest createArtistRequest, CancellationToken cancellationToken = default);
        
        Task<Response<IList<GetArtistResponse>>> SearchArtist(string artistName);
    }
}
