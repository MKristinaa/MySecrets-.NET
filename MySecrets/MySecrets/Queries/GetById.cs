using MediatR;
using MySecrets.Dtos;

namespace MySecrets.Queries
{
    public class GetById : IRequest<List<GetTajneDto>>
    {
        public int Id { get; set; }
        public GetById(int id)
        {
            Id = id;
        }
    }
}
