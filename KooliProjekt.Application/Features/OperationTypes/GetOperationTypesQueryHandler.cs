using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypesQueryHandler : IRequestHandler<GetOperationTypesQuery, OperationResult<OperationTypeDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationTypesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OperationTypeDto>> Handle(GetOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<OperationTypeDto>();

            result.Value = await _dbContext.OperationTypes
                .AsNoTracking()
                .Where(t => t.id == request.Id)
                .Select(t => new OperationTypeDto
                {
                    Id = t.id,
                    Name = t.name
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}