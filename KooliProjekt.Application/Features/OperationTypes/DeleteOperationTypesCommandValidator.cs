using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class DeleteOperationTypesCommandValidator : AbstractValidator<DeleteOperationTypesCommand>
    {
        public DeleteOperationTypesCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.")
                .Must(id => dbContext.OperationTypes.Any(type => type.id == id))
                    .WithMessage("Operation type with given Id does not exist.");
        }
    }
}
