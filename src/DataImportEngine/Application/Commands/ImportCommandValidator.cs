using DataImportEngine.Common;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DataImportEngine.Application.Commands
{
    public class ImportCommandValidator : AbstractValidator<ImportCommand>
    {
        public ImportCommandValidator()
        {
            RuleFor(_ => _.Origin).NotEmpty()
                                  .WithMessage("Origin must not be empty");
            RuleFor(_ => _.Origin).Must(x => IsValidOriginFormat(x))
                                          .WithMessage($"Origin must be only letters from A to Z and numbers from 0 to 9 characters, not allowed special characters");
            RuleFor(_ => _.Origin).Must(x => IsOriginAllowed(x.ToUpperInvariant()))
                                          .WithMessage($"Origin not allowed; Allowed origins are: {Constants.SOFTWAREADVICE_ORIGIN_NAME} and {Constants.CAPTERRA_ORIGIN_NAME}");

            RuleFor(_ => _.Data).NotEmpty();
        }

        private bool IsValidOriginFormat(string origin)
        {
            return Regex.IsMatch(origin, @"^[a-zA-Z0-9]+$");
        }

        private bool IsOriginAllowed(string origin)
        {
            var coso = origin.Contains(Constants.SOFTWAREADVICE_ORIGIN_NAME) || origin.Contains(Constants.CAPTERRA_ORIGIN_NAME);
            return coso;
        }
    }
}
