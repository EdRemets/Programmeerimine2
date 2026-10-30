using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarsCommandHandler : IRequestHandler<SaveCarsCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCarsCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveCarsCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var car = new Car();

            if (request.Id == 0)
            {
                _dbContext.Add(car);
            }
            else
            {
                car = await _dbContext.FindAsync<Car>(request.Id);
            }
            
            car.manufacturer = request.Manufacturer;
            car.model = request.Model;
            car.licensePlate = request.LicensePlate;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
