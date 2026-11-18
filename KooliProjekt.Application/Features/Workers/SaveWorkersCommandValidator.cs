using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Workers
{
    public class SaveWorkersCommandValidator : AbstractValidator<SaveWorkersCommand>
    {
        public SaveWorkersCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Workers.Any(worker => worker.id == id))
                    .WithMessage("Worker with given Id does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
        }
    }
}
