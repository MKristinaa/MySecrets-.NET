using MediatR;
using MySecrets.Models;

namespace MySecrets.Queries
{
    public class GetAllQuery : IRequest<IEnumerable<Tajne>>
    {
    }
}
