using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationsCommandValidator : AbstractValidator<SaveOperationsCommand>
    {
        public SaveOperationsCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Operations.Any(operation => operation.id == id))
                    .WithMessage("Operation with given Id does not exist.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be Waiting (0), InProgress (1) or Done (2).");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost must not be negative.")
                .PrecisionScale(18, 2, true).WithMessage("Cost can have at most 2 decimal places and 16 digits before the decimal point.")
                .When(x => x.Cost != null);

            RuleFor(x => x.CarId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CarId must be greater than or equal to 1.")
                .Must(carId => dbContext.Cars.Any(car => car.id == carId))
                    .WithMessage("The specified car does not exist.");

            RuleFor(x => x.OperationTypeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("OperationTypeId must be greater than or equal to 1.")
                .Must(operationTypeId => dbContext.OperationTypes.Any(type => type.id == operationTypeId))
                    .WithMessage("The specified operation type does not exist.");

            RuleFor(x => x.WorkerId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("WorkerId must be greater than or equal to 1.")
                .Must(workerId => dbContext.Workers.Any(worker => worker.id == workerId))
                    .WithMessage("The specified worker does not exist.");
        }
    }
}
