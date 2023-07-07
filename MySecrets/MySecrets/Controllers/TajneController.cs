using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySecrets.Commands;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Models;
using MySecrets.Queries;
using MySecrets.Repo;

namespace MySecrets.Controllers
{
    //[Authorize]
    public class TajneController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<TajneRepository> logger;
        private readonly DataContext dc;

        public TajneController(IMediator mediator, IUnitOfWork uow, IMapper mapper, ILogger<TajneRepository> logger, DataContext dc)
        {
            this.mediator = mediator;
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
            this.dc = dc;
        }


        [HttpPost("dodajTajnu")]
        public async Task<IActionResult> PostAsync(TajneDto tajnaDto)
        {
            var command = new CreateTajneCommand(tajnaDto);
            var result =  await mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("tajneALL")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("tajneById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var query = new GetById( id);
            var result = await mediator.Send(query);
            return Ok(result);

        }

        [HttpGet("tajneASC/{id}")]
        public async Task<IActionResult> GetASC(int page, int pageSize, int id)
        {

            var query = new GetASCQuery(page, pageSize, id);
            var result = await mediator.Send(query);
            return Ok(result);
            
        }

        [HttpGet("tajneDESC/{page}/{pageSize}/{id}")]
        public async Task<IActionResult> GetAsyncDesc(int page, int pageSize, int id)
        {
            var query = new GetDescQuery(page, pageSize, id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

       

        [HttpGet("tajne/SearchPost/{ime}")]
  
        public async Task<IActionResult> SearchPost(int id, string ime)
        {

            var query = new SearchPostQuery(id, ime);
            var result = await mediator.Send(query);
            return Ok(result);
            
        }


        [HttpGet("tajne/Page/{page}/{pageSize}/{id}")]
        public async Task<IActionResult> Page(int page, int pageSize, int id)
        {
            var query = new GetPageQuery(page, pageSize, id);
            var result = await mediator.Send(query);
            return Ok(result);
         } 
    }
}
