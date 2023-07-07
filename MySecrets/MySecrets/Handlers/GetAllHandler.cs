using MediatR;
using MySecrets.Interfaces;
using MySecrets.Models;
using MySecrets.Queries;
using MySecrets.Repo;

namespace MySecrets.Handlers
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Tajne>>
    {
        private readonly IUnitOfWork uow;

        public GetAllHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        

        public async Task<IEnumerable<Tajne>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await uow.TajneRepository.GetAllAsync();
        }
    }


}
