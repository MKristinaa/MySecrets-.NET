using MediatR;
using MySecrets.Dtos;

namespace MySecrets.Queries
{
    public class GetDescQuery : IRequest<List<GetTajneDto>>
    {
        public int page { get; }
        public int pageSize { get; }
        public int id { get; }

        public GetDescQuery(int Page, int PageSize, int Id)
        {
            page = Page;
            pageSize = PageSize;
            id = Id;
        }
    }
}
