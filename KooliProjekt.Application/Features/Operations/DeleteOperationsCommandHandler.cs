using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class DeleteOperationsCommandHandler : IRequestHandler<DeleteOperationsCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteOperationsCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteOperationsCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Operations
                .Where(item => item.id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            return new OperationResult();
        }
    }
}
