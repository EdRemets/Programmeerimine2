using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, Worker>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWorkersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Worker> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.Workers.FindAsync(request.Id, cancellationToken);

            return list;
        }
    }
}
