using KooliProjekt.Application.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
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
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetCarsQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListCarsQuery { Page = page, PageSize = pageSize };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody]SaveCarsCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteCarsCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpPost("AddFile")]
        public async Task<IActionResult> AddFile(int id, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            using var inputStream = file.OpenReadStream();

            var command = new AddFileCommand();
            command.Id = id;
            command.FileName = fileName;
            command.InputStream = inputStream;

            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpGet("ListFiles/{id}")]
        public async Task<IActionResult> ListFiles(int id)
        {
            var query = new ListFilesQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("GetFile/{id}/{fileName}")]
        public async Task<IActionResult> GetFile(int id, string fileName)
        {
            var command = new GetFileCommand { Id = id, FileName = fileName };
            var result = await _mediator.Send(command);

            if (result.HasErrors)
            {
                return Result(result);
            }

            if (result.Value == null)
            {
                return NotFound();
            }

            var contentTypeProvider = new FileExtensionContentTypeProvider();
            if (!contentTypeProvider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(result.Value, contentType);
        }

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile([FromBody]DeleteFileCommand command)
        {
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
