using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;
using MySecrets.Dtos;
using MySecrets.Models;

namespace MySecrets.Commands
{
    public class CreateTajneCommand : IRequest<Tajne>
    {
        public TajneDto _tajne { get; set; }

        public CreateTajneCommand(TajneDto tajne)
        {
            _tajne = tajne;
        }

    }
}
