using System;
using System.Collections.Generic;
using System.Text;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class DeleteOperationTypesCommandHandler : IRequestHandler<DeleteOperationTypesCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteOperationTypesCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteOperationTypesCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (await _dbContext.Operations
                .AnyAsync(item => item.operationType.id == request.Id, cancellationToken))
            {
                result.AddError("This OperationType has operations.");
                return result;
            }

            await _dbContext.OperationTypes
                .Where(item => item.id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            return result;
        }
    }
}
