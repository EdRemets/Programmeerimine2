using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, OperationResult>
    {
        private readonly IFileClient _fileClient;

        public DeleteFileCommandHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var deleted = await _fileClient.Delete(request.FileName, FileStore.ForCar(request.Id));
            if (!deleted)
            {
                result.AddError("File not found");
            }

            return result;
        }
    }
}
