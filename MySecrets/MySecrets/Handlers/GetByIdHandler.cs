using AutoMapper;
using MediatR;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Queries;

namespace MySecrets.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetById, List<GetTajneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<GetTajneDto>> Handle(GetById request, CancellationToken cancellationToken)
        {
            var tajne = await uow.TajneRepository.GetById(request.Id);
            return mapper.Map<List<GetTajneDto>>(tajne);
        }
    }
}
