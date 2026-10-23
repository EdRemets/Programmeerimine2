using KooliProjekt.Application.Features.Operations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class OperationsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetOperationsQuery { Id = id };
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

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListOperationQuery { Page = page, PageSize = pageSize };
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
