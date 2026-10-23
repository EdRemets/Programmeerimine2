using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationsQueryHandler : IRequestHandler<GetOperationsQuery, OperationResult<OperationDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OperationDto>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<OperationDto>();

            result.Value = await _dbContext.Operations
                .AsNoTracking()
                .Where(o => o.id == request.Id)
                .Select(o => new OperationDto
                {
                    Id = o.id,
                    Date = o.date,
                    Status = o.status.ToString(),
                    Cost = o.cost,
                    CarName = o.car.manufacturer + " " + o.car.model,
                    LicensePlate = o.car.licensePlate,
                    OperationTypeName = o.operationType.name,
                    WorkerName = o.worker.name
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}