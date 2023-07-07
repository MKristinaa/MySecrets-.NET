using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Queries;

namespace MySecrets.Handlers
{
    public class GetDescHandler : IRequestHandler<GetDescQuery, List<GetTajneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetDescHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetTajneDto>> Handle(GetDescQuery request, CancellationToken cancellationToken)
        {
            var tajne = await uow.TajneRepository.GetTajneDesc(request.page, request.pageSize, request.id);
            return mapper.Map<List<GetTajneDto>>(tajne);
        }
    }
}
