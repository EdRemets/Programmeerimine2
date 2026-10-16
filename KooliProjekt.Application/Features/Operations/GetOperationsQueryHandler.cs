using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationsQueryHandler : IRequestHandler<GetOperationsQuery, Operation>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Operation> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.Operations.FindAsync(request.Id, cancellationToken);

            return list;
        }
    }
}
