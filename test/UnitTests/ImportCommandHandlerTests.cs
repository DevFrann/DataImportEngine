using DataImportEngine.Application.Commands;
using DataImportEngine.Application.Handlers;
using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UnitTests
{
    public class ImportCommandHandlerTests
    {
        private readonly ImportCommandHandler _sut;
        private readonly IValidator<ImportCommand> _validator;
        private readonly Mock<IImportDataRepository<List<SoftwareAdviceEntity>>> _jsonRepositoryMock;
        private readonly Mock<IImportDataRepository<List<CapterraEntity>>> _ymlRepositoryMock;
        //private readonly Mock<IProductRepository<ProductDto>> _productRepositoryMock;
        public const string ValidJson = @"
        {
            ""products"": [
                {
                    ""categories"": [
                        ""Customer Service"",
                        ""Call Center""
                    ],
                    ""twitter"": ""@freshdesk"",
                    ""title"": ""Freshdesk""
                },
                {
                    ""categories"": [
                        ""CRM"",
                        ""Sales Management""
                    ],
                    ""title"": ""Zoho""
                }
            ]
        }";

        public ImportCommandHandlerTests()
        {
            _validator = new ImportCommandValidator();
            _jsonRepositoryMock = new Mock<IImportDataRepository<List<SoftwareAdviceEntity>>>();
            _ymlRepositoryMock = new Mock<IImportDataRepository<List<CapterraEntity>>>();
            //_productRepositoryMock = new Mock<IProductRepository<ProductDto>>();

            _sut = new ImportCommandHandler(_validator,
                                            _jsonRepositoryMock.Object,
                                            _ymlRepositoryMock.Object);
            //_productRepositoryMock.Object);
            InitializeDefaultMockSetUps();
        }

        private void InitializeDefaultMockSetUps()
        {
            _jsonRepositoryMock.Setup(p =>
                    p.ReadDataAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<SoftwareAdviceEntity> { new SoftwareAdviceEntity { Title = "test", Categories = new List<string> { "Cat1"}, Twitter = "Twitt" } })
                .Verifiable();

            _ymlRepositoryMock.Setup(p =>
                    p.ReadDataAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<CapterraEntity> { new CapterraEntity { Name = "test", Tags = "Cat1, Cat2", Twitter = "Twitt" } })
                .Verifiable();

            //_productRepositoryMock.Setup(p =>
            //        p.CreateAsync(It.IsAny<ProductEntity>()))
            //    .ReturnsAsync(new ProductDto())
            //    .Verifiable();
        }

        [Theory]
        [InlineData("softwareadvice", ValidJson)]
        public async Task Given_IsValidAllInputData_When_HandlerIsCalled_Then_DataIsImported(string origin, string data)
        {
            var result = await _sut.HandleAsync(new ImportCommand(origin, data));

            result.Should().NotBeNull();
            result.ErrorMessages.Should().BeNullOrEmpty();
            result.Products.Count.Should().Be(1);
            result.Imported.Should().BeTrue();
            _jsonRepositoryMock.VerifyAll();
            _jsonRepositoryMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("softwareadvice", ValidJson)]
        public async Task Given_IsValidAllInputData_AND_NullCommand_When_HandlerIsCalled_Then_DataIsImported(string origin, string data)
        {
            var result = await _sut.HandleAsync(null);

            result.Should().NotBeNull();
            result.ErrorMessages.Should().NotBeNullOrEmpty();
            result.ErrorMessages.Count().Should().Be(1);
            result.ErrorMessages.FirstOrDefault().Contains("Command is null");
            result.Products.Should().BeNullOrEmpty();
            result.Imported.Should().BeFalse();
            _jsonRepositoryMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("", ValidJson)]
        public async Task Given_IsNotValidAllInputData_When_HandlerIsCalled_Then_DataIsImported(string origin, string data)
        {
            var result = await _sut.HandleAsync(new ImportCommand(origin, data));

            result.Should().NotBeNull();
            result.ErrorMessages.Should().NotBeNullOrEmpty();
            result.ErrorMessages.Count().Should().Be(1);
            result.ErrorMessages.FirstOrDefault().Contains("Command is not valid");
            result.Products.Should().BeNullOrEmpty();
            result.Imported.Should().BeFalse();
            _jsonRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void Ctor_When_AnyArgumentIsNull_Then_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ImportCommandHandler(default, default, default));
            Assert.Throws<ArgumentNullException>(() => new ImportCommandHandler(default, default, _ymlRepositoryMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ImportCommandHandler(default, _jsonRepositoryMock.Object, _ymlRepositoryMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ImportCommandHandler(new ImportCommandValidator(), default, default));
            Assert.Throws<ArgumentNullException>(() => new ImportCommandHandler(new ImportCommandValidator(), _jsonRepositoryMock.Object, default));
        }
    }
}