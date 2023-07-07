using MediatR;
using MySecrets.Dtos;

namespace MySecrets.Queries
{
    public class GetPageQuery : IRequest<List<TajneDto>>
    {
        public int page { get; }
        public int pageSize { get; }
        public int id { get; }

        public GetPageQuery(int Page, int PageSize, int Id)
        {
            page = Page;
            pageSize = PageSize;
            id = Id;
        }
    }
}
