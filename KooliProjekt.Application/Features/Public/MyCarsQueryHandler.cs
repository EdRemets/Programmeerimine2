using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class MyCarsQueryHandler : IRequestHandler<MyCarsQuery, OperationResult<PagedResult<CarListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserProvider _userProvider;

        public MyCarsQueryHandler(ApplicationDbContext dbContext, IUserProvider userProvider)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<PagedResult<CarListItemDto>>> Handle(MyCarsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<CarListItemDto>>();

            var userId = _userProvider.UserId();
            if (userId == null)
            {
                result.AddError("User not found");
                return result;
            }

            result.Value = await _dbContext.Cars
                .AsNoTracking()
                .Where(c => c.client.id == userId.Value)
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
