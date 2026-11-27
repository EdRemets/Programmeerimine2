using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Public
{
    public class AddMyCarCommandValidator : AbstractValidator<AddMyCarCommand>
    {
        public AddMyCarCommandValidator(ApplicationDbContext dbContext)
        {
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
                .Must(licensePlate => !dbContext.Cars.Any(car => car.licensePlate == licensePlate))
                    .WithMessage("A car with the same license plate already exists.");
        }
    }
}
