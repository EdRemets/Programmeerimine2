using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Workers
{
    public class DeleteWorkersCommandValidator : AbstractValidator<DeleteWorkersCommand>
    {
        public DeleteWorkersCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.")
                .Must(id => dbContext.Workers.Any(worker => worker.id == id))
                    .WithMessage("Worker with given Id does not exist.");
        }
    }
}
