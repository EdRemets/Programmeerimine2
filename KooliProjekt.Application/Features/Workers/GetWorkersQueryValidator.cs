using FluentValidation;

namespace KooliProjekt.Application.Features.Workers
{
    public class GetWorkersQueryValidator : AbstractValidator<GetWorkersQuery>
    {
        public GetWorkersQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.");
        }
    }
}
