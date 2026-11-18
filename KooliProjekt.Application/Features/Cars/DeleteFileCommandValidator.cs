using System.IO;
using FluentValidation;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than or equal to 1.");

            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File name is required.")
                .Must(fileName => fileName == Path.GetFileName(fileName))
                    .WithMessage("File name must not contain a path.");
        }
    }
}
