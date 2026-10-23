using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListCarsQueryHandler : IRequestHandler<ListCarsQuery, OperationResult<PagedResult<CarListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CarListItemDto>>> Handle(ListCarsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<CarListItemDto>>();

            result.Value = await _dbContext.Cars
                .AsNoTracking()
                .OrderByDescending(c => c.id)
                .Select(c => new CarListItemDto
                {
                    Id = c.id,
                    Manufacturer = c.manufacturer,
                    Model = c.model,
                    LicensePlate = c.licensePlate
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}