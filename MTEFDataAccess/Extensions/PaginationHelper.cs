using AutoMapper;
using MTEFDataAccess.Model;

namespace MTEFDataAccess.Extensions
{
    public static class PaginationHelper
    {
        public static SearchResponse<TRes> Paginate<TReq, TRes>(this IQueryable<TReq> request, IMapper mapper, int page,
            int pageSize, long total)
        {
            page = page <= 1 ? 1 : page;
            var (skip, take) = SkipTake(pageSize, page);

            var result = new SearchResponse<TRes>
            {
                Data = mapper.Map<IList<TRes>>(request.Skip(skip)).Take(take).ToList(),
                Page = page,
                PageSize = take,
                TotalCount = total,
                PageCount = PageCount(total, take)
            };

            return result;
        }

        public static (int, int) SkipTake(int pageSize, int page)
        {
            int take = pageSize > 0 ? pageSize : 10;
            int skip = page == 0 ? 0 : (page - 1) * take;

            return (skip, take);
        }

        public static long PageCount(long total, int take) => total % take == 0 ? total / take : (total / take) + 1;
    }
}
