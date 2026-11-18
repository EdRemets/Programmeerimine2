using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Operations
{
    public class DeleteOperationsCommandValidator : AbstractValidator<DeleteOperationsCommand>
    {
        public DeleteOperationsCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.")
                .Must(id => dbContext.Operations.Any(operation => operation.id == id))
                    .WithMessage("Operation with given Id does not exist.");
        }
    }
}
