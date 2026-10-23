using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Features.Operations;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, OperationResult<WorkerDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWorkersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<WorkerDto>();

            result.Value = await _dbContext.Workers
            .AsNoTracking()
            .Where(w => w.id == request.Id)
            .Select(w => new WorkerDto
            {
                Id = w.id,
                Name = w.name,
                IsAdmin = w.isAdmin
            })
            .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
