using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MySecrets.Commands;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Models;

namespace MySecrets.Handlers
{
    public class CreateTajneHandler : IRequestHandler<CreateTajneCommand,Tajne>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreateTajneHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<Tajne> Handle(CreateTajneCommand request, CancellationToken cancellationToken)
        {
            
            var tajna = mapper.Map<Tajne>(request._tajne);
            uow.TajneRepository.AddTajna(tajna);
            await uow.SaveAsync();
            return tajna;
            
        }
    }
}
