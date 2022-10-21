using DataImportEngine.Application.Commands;
using FluentAssertions;

namespace UnitTests
{
    public class ImportCommandValidatorTests
    {
        private readonly ImportCommandValidator _sut;

        public ImportCommandValidatorTests()
        {
            _sut = new ImportCommandValidator();
        }

        [Theory]
        [InlineData("", "")]
        public void Given_EmptyOriginOrData_When_ValidatorIsCalled_Then_Validator_HasErrors(string origin, string data)
        {
            var importCommand = new ImportCommand(origin, data);

            var result = _sut.ValidateAsync(importCommand);

            result.Result.Should().NotBeNull();
            result.Result.Errors.Any().Should().BeTrue();
            result.Result.Errors.Count().Should().Be(4);
        }

        [Theory]
        [InlineData("capterra**", "capterra.yaml")]
        public void Given_MalformedOrigin_When_ValidatorIsCalled_Then_Validator_HasErrors(string origin, string data)
        {
            var importCommand = new ImportCommand(origin, data);

            var result = _sut.ValidateAsync(importCommand);

            result.Result.Should().NotBeNull();
            result.Result.Errors.Any().Should().BeTrue();
            result.Result.Errors.Count().Should().Be(1);
        }

        [Theory]
        [InlineData("capterra", "capterra.yaml")]
        public void Given_ValidOriginAndData_When_ValidatorIsCalled_Then_Validator_HasNotErrors(string origin, string data)
        {
            var importCommand = new ImportCommand(origin, data);

            var result = _sut.ValidateAsync(importCommand);

            result.Result.Should().NotBeNull();
            result.Result.Errors.Any().Should().BeFalse();
        }
    }
}