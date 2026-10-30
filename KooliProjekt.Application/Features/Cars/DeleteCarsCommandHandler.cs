using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteCarsCommandHandler : IRequestHandler<DeleteCarsCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteCarsCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteCarsCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Cars
                .Where(item => item.id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
