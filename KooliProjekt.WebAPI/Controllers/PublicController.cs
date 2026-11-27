using KooliProjekt.Application.Features.Public;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Authorize(Roles = "Client")]
    public class PublicController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterClientCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpGet("MyCars/{page}/{pageSize}")]
        public async Task<IActionResult> MyCars(int page, int pageSize)
        {
            var query = new MyCarsQuery { Page = page, PageSize = pageSize };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("AddMyCar")]
        public async Task<IActionResult> AddMyCar([FromBody]AddMyCarCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
