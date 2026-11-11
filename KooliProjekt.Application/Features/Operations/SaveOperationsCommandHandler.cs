using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationsCommandHandler : IRequestHandler<SaveOperationsCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOperationsCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveOperationsCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var car = await _dbContext.FindAsync<Car>(request.CarId);
            var operationType = await _dbContext.FindAsync<OperationType>(request.OperationTypeId);
            var worker = await _dbContext.FindAsync<Worker>(request.WorkerId);

            if (car == null)
            {
                result.AddError("Car not found.");
            }
            if (operationType == null)
            {
                result.AddError("OperationType not found.");
            }
            if (worker == null)
            {
                result.AddError("Worker not found.");
            }
            if (result.HasErrors)
            {
                return result;
            }

            var operation = new Operation();

            if (request.Id == 0)
            {
                _dbContext.Add(operation);
            }
            else
            {
                operation = await _dbContext.FindAsync<Operation>(request.Id);
            }

            operation.date = request.Date;
            operation.status = request.Status;
            operation.cost = request.Cost;
            operation.car = car;
            operation.operationType = operationType;
            operation.worker = worker;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
