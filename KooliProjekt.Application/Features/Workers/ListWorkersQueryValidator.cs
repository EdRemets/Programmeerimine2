using FluentValidation;

namespace KooliProjekt.Application.Features.Workers
{
    public class ListWorkersQueryValidator : AbstractValidator<ListWorkersQuery>
    {
        public ListWorkersQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Page must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize must be greater than or equal to 1.")
                .LessThanOrEqualTo(100).WithMessage("PageSize must not exceed 100.");
        }
    }
}
