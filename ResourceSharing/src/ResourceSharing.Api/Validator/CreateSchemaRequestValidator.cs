using FluentValidation;
using ResourceSharing.Api.Models;

namespace ResourceSharing.Api.Validator
{
    internal class CreateSchemaRequestValidator : AbstractValidator<CreateSchemaRequest>
    {
        public CreateSchemaRequestValidator()
        {
            RuleFor(x => x.Fields).NotEmpty().WithMessage("Define at least one field");
        }
    }
}
