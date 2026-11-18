using FluentValidation;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypesQueryValidator : AbstractValidator<GetOperationTypesQuery>
    {
        public GetOperationTypesQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.");
        }
    }
}
