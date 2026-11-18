using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class SaveOperationTypesCommandValidator : AbstractValidator<SaveOperationTypesCommand>
    {
        public SaveOperationTypesCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.OperationTypes.Any(type => type.id == id))
                    .WithMessage("Operation type with given Id does not exist.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .Must((command, name) => !dbContext.OperationTypes.Any(type =>
                        type.name == name &&
                        type.id != command.Id))
                    .WithMessage("An operation type with the same name already exists.");
        }
    }
}
