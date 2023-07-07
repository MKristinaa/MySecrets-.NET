using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Queries;

namespace MySecrets.Handlers
{
    public class GetPageHandler : IRequestHandler<GetPageQuery, List<TajneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPageHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<TajneDto>> Handle(GetPageQuery request, CancellationToken cancellationToken)
        {
            var tajne = await uow.TajneRepository.Page(request.page, request.pageSize, request.id);
            return mapper.Map<List<TajneDto>>(tajne);
        }
    }
}
