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

            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(25).WithMessage("Username must not exceed 25 characters.")
                .Must((command, userName) => !dbContext.Workers.Any(worker =>
                        worker.userName == userName &&
                        worker.id != command.Id))
                    .WithMessage("A worker with the same username already exists.")
                .When(x => !string.IsNullOrWhiteSpace(x.UserName));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required when creating a worker with username.")
                .When(x => x.Id == 0 && !string.IsNullOrWhiteSpace(x.UserName));
        }
    }
}
