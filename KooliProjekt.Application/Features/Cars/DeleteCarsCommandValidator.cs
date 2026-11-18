using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteCarsCommandValidator : AbstractValidator<DeleteCarsCommand>
    {
        public DeleteCarsCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.")
                .Must(id => dbContext.Cars.Any(car => car.id == id))
                    .WithMessage("Car with given Id does not exist.");
        }
    }
}
