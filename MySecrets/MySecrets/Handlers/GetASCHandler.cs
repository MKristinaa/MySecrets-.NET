using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Models;
using MySecrets.Queries;

namespace MySecrets.Handlers
{
    public class GetASCHandler : IRequestHandler<GetASCQuery, List<GetTajneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetASCHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<GetTajneDto>> Handle(GetASCQuery request, CancellationToken cancellationToken)
        {
            var tajne = await uow.TajneRepository.GetTajneAsc(request.page, request.pageSize, request.id);
            return mapper.Map<List<GetTajneDto>>(tajne);
        }
    }
}
