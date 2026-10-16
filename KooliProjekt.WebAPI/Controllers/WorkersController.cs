using KooliProjekt.Application.Features.Workers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class WorkersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public WorkersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetWorkersQuery { Id = id };
            var result = await _mediator.Send(query);

            if (id <= 0)
            {
                return NotFound();
            }

            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListWorkersQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
