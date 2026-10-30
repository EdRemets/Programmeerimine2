using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class SaveOperationTypesCommandHandler : IRequestHandler<SaveOperationTypesCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOperationTypesCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveOperationTypesCommand request, CancellationToken cancellationToken)
        {
            var operationType = new OperationType();

            if (request.Id == 0)
            {
                _dbContext.Add(operationType);
            }
            else
            {
                operationType = await _dbContext.FindAsync<OperationType>(request.Id);
            }

            operationType.name = request.Name;

            await _dbContext.SaveChangesAsync();

            return new OperationResult();
        }

    }
}
