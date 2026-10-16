using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationsQueryHandler : IRequestHandler<ListOperationQuery, IEnumerable<Operation>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Operation>> Handle(ListOperationQuery query, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Operations.ToListAsync(cancellationToken);

            return result;
        }
    }
}
