using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MySecrets.Dtos;

namespace MySecrets.Queries
{
    public class SearchPostQuery : IRequest<List<GetTajneDto>>
    {
        public int id { get; }
        public string text { get; }

        public SearchPostQuery(int Id, string Text)
        {
            id = Id;
            text = Text;
        }
    }
}
