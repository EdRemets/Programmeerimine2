using System.IO;
using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Cars
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        public AddFileCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.")
                .Must(id => dbContext.Cars.Any(car => car.id == id))
                    .WithMessage("Car with given Id does not exist.");

            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File name is required.")
                .Must(fileName => fileName == Path.GetFileName(fileName))
                    .WithMessage("File name must not contain a path.");

            RuleFor(x => x.InputStream)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("File is required.")
                .Must(stream => stream.Length > 0).WithMessage("File must not be empty.");
        }
    }
}
