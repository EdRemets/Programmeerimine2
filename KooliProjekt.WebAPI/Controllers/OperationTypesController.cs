using KooliProjekt.Application.Features.OperationTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class OperationTypesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OperationTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetOperationTypesQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListOperationTypesQuery { Page = page, PageSize = pageSize };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveOperationTypesCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteOperationTypesCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}