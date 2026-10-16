using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Car>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.Cars.FindAsync(request.Id, cancellationToken);

            return list;
        }
    }
}
