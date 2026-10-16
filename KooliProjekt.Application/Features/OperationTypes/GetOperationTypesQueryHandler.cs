using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypesQueryHandler : IRequestHandler<GetOperationTypesQuery, OperationType>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationTypesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationType> Handle(GetOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.OperationTypes.FindAsync(request.Id, cancellationToken);

            return list;
        }
    }
}
