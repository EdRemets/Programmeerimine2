using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class ListWorkersQueryHandler : IRequestHandler<ListWorkersQuery, OperationResult<PagedResult<WorkerListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorkersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WorkerListItemDto>>> Handle(ListWorkersQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<WorkerListItemDto>>();

            result.Value = await _dbContext.Workers
            .AsNoTracking()
            .OrderByDescending(w => w.id)
            .Select(w => new WorkerListItemDto
            {
                Id = w.id,
                Name = w.name
            })
            .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}
