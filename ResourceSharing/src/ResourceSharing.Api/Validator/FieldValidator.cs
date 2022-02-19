using FluentValidation;
using ResourceSharing.Api.Models;

namespace ResourceSharing.Api.Validator
{
    internal class FieldValidator : AbstractValidator<Field>
    {
        public FieldValidator()
        {
            RuleFor(x => x.Name).Length(1, 40).WithMessage("Name length should be between 1 and 40");
            RuleFor(x => x.Default)
                .Must(x => x == null || int.TryParse(x, out _))
                .When(x => x.Type == DataType.Int)
                .WithMessage("Should be parsed to int");

            RuleFor(x => x.Default)
                .Must(x => x == null || bool.TryParse(x, out _))
                .When(x => x.Type == DataType.Bool)
                .WithMessage("Should be parsed to bool");
        }
    }
}
