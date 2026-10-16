using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class ListWorkersQueryHandler : IRequestHandler<ListWorkersQuery, IEnumerable<Worker>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWorkersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Worker>> Handle(ListWorkersQuery query, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Workers.ToListAsync(cancellationToken);

            return result;
        }
    }
}
