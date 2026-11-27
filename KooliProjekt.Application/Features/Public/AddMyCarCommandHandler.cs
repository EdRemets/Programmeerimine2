using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class AddMyCarCommandHandler : IRequestHandler<AddMyCarCommand, OperationResult<int?>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserProvider _userProvider;

        public AddMyCarCommandHandler(ApplicationDbContext dbContext, IUserProvider userProvider)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<int?>> Handle(AddMyCarCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int?>();

            var userId = _userProvider.UserId();
            if (userId == null)
            {
                result.AddError("User not found");
                return result;
            }

            var client = await _dbContext.FindAsync<Client>(userId.Value);
            if (client == null)
            {
                result.AddError("User not found");
                return result;
            }

            var car = new Car
            {
                manufacturer = request.Manufacturer,
                model = request.Model,
                licensePlate = request.LicensePlate,
                client = client
            };

            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync(cancellationToken);

            result.Value = car.id;

            return result;
        }
    }
}
