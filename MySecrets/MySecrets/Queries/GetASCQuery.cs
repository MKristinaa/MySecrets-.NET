using MediatR;
using MySecrets.Dtos;
using MySecrets.Models;

namespace MySecrets.Queries
{
    public class GetASCQuery : IRequest<List<GetTajneDto>>
    {
        public int page { get; }
        public int pageSize { get; }
        public int id { get; }

        public GetASCQuery(int Page, int PageSize, int Id)
        {
            page = Page;
            pageSize = PageSize;
            id = Id;
        }
    }
}
