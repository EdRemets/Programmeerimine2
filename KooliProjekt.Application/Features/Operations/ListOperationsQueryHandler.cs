using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationsQueryHandler : IRequestHandler<ListOperationQuery, OperationResult<PagedResult<OperationListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OperationListItemDto>>> Handle(ListOperationQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<OperationListItemDto>>();

            result.Value = await _dbContext.Operations
                .AsNoTracking()
                .OrderByDescending(o => o.id)
                .Select(o => new OperationListItemDto
                {
                    Id = o.id,
                    Date = o.date,
                    Status = o.status.ToString(),
                    Cost = o.cost,
                    CarName = o.car.manufacturer + " " + o.car.model,
                    LicensePlate = o.car.licensePlate,
                    OperationTypeName = o.operationType.name,
                    WorkerId = o.worker.id,
                    WorkerName = o.worker.name
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}
