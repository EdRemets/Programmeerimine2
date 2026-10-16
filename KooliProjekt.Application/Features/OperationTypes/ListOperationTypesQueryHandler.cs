using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class ListOperationTypesQueryHandler : IRequestHandler<ListOperationTypesQuery, IEnumerable<OperationType>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationTypesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OperationType>> Handle(ListOperationTypesQuery query, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OperationTypes.ToListAsync(cancellationToken);

            return result;
        }
    }
}
