using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, OperationResult<CarDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<CarDto>();

            result.Value = await _dbContext.Cars
                .AsNoTracking()
                .Where(c => c.id == request.Id)
                .Select(c => new CarDto
                {
                    Id = c.id,
                    Manufacturer = c.manufacturer,
                    Model = c.model,
                    LicensePlate = c.licensePlate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}