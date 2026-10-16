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
            var query = new GetOperationTypesQuery { Id = id };
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
            var query = new ListOperationTypesQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
