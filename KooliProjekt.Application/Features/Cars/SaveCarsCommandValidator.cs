using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarsCommandValidator : AbstractValidator<SaveCarsCommand>
    {
        public SaveCarsCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Cars.Any(car => car.id == id))
                    .WithMessage("Car with given Id does not exist.");

            RuleFor(x => x.Manufacturer)
                .NotEmpty().WithMessage("Manufacturer is required.")
                .MaximumLength(50).WithMessage("Manufacturer must not exceed 50 characters.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.")
                .MaximumLength(50).WithMessage("Model must not exceed 50 characters.");

            RuleFor(x => x.LicensePlate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("License plate is required.")
                .MaximumLength(15).WithMessage("License plate must not exceed 15 characters.")
                .Must((command, licensePlate) => !dbContext.Cars.Any(car =>
                        car.licensePlate == licensePlate &&
                        car.id != command.Id))
                    .WithMessage("A car with the same license plate already exists.");
        }
    }
}
