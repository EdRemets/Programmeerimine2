using FluentValidation;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationsQueryValidator : AbstractValidator<GetOperationsQuery>
    {
        public GetOperationsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.");
        }
    }
}
