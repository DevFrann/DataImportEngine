using DataImportEngine.Application.Commands;
using DataImportEngine.Application.Contracts;
using DataImportEngine.Application.Services;
using DataImportEngine.Domain.DTOs;
using Moq;
using FluentValidation;
using FluentAssertions;

namespace UnitTests
{
        public class ImportDataServiceTests
        {
            private readonly ImportDataService _sut;
            private readonly Mock<IImportCommandHandler> _importCommandHandlerMock;

            public ImportDataServiceTests()
            {
                _importCommandHandlerMock = new Mock<IImportCommandHandler>(MockBehavior.Strict);

                _sut = new ImportDataService(_importCommandHandlerMock.Object);
            }

            [Theory]
            [InlineData("softwareadvice", "softwareadvice.json")]
            public async Task Execute_When_InputMessageIsNull_Then_ReturnsNotCreated_And_NotUdpated_With_Error(string origin, string data)
            {
                var commandResponse = new ImportCommandResult
                {
                    Imported = true,
                    Products = new List<ProductEntity> {
                    new ProductEntity {
                        Name = "Freshdesk",
                        Categories = new List<string>{ "Customer Service", "Call Center"},
                        Twitter = "@freshdesk" },
                    new ProductEntity {
                        Name = "Zoho",
                        Categories = new List<string>{ "CRM", "Sales Management"},
                        Twitter = string.Empty }}
                };

                _importCommandHandlerMock.Setup(p =>
                        p.HandleAsync(It.IsAny<ImportCommand>()))
                    .ReturnsAsync(new ImportCommandResult())
                    .Verifiable();

                var func = async () => await _sut.ExecuteAsync(origin, data);
                func.Should().NotBeNull();
                func.Should().NotThrowAsync<ValidationException>();
                _importCommandHandlerMock.VerifyAll();
            }

            [Fact]
            public void Ctor_When_AnyArgumentIsNull_Then_Throws()
            {
                Assert.Throws<ArgumentNullException>(() => new ImportDataService(default));
            }
        }
    }