using KooliProjekt.Application.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CarsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCarsQuery { Id = id };
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
            var query = new ListCarsQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
