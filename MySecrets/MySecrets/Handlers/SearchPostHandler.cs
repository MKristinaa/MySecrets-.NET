using AutoMapper;
using MediatR;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Queries;

namespace MySecrets.Handlers
{
    public class SearchPostHandler : IRequestHandler<SearchPostQuery, List<GetTajneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SearchPostHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetTajneDto>> Handle(SearchPostQuery request, CancellationToken cancellationToken)
        {
            var tajne = await uow.TajneRepository.SearchPost(request.id, request.text);
            return mapper.Map<List<GetTajneDto>>(tajne);
        }
    }
}
