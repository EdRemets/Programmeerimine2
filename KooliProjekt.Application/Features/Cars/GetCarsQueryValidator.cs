using FluentValidation;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarsQueryValidator : AbstractValidator<GetCarsQuery>
    {
        public GetCarsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.");
        }
    }
}
