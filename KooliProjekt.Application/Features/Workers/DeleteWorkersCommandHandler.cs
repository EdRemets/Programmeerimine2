using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class DeleteWorkersCommandHandler : IRequestHandler<DeleteWorkersCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteWorkersCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteWorkersCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (await _dbContext.Operations
                .AnyAsync(item => item.worker.id == request.Id, cancellationToken))
            {
                result.AddError("This Worker has operations.");
                return result;
            }

            await _dbContext.Workers
                .Where(item => item.id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            return result;
        }
    }
}
