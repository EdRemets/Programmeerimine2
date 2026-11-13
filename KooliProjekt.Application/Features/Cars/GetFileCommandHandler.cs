using System.IO;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommandHandler : IRequestHandler<GetFileCommand, OperationResult<Stream>>
    {
        private readonly IFileClient _fileClient;

        public GetFileCommandHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<OperationResult<Stream>> Handle(GetFileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Stream>();

            result.Value = await _fileClient.Get(request.FileName, FileStore.ForCar(request.Id));

            return result;
        }
    }
}
