using AmountToString.Controllers;
using AmountToString.Interfaces;
using AmountToString.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace AmountToWordsConverter.Tests.Controllers
{
    public class AmountControllerTests
    {
        private readonly Mock<INumberToWordsConverter> _mockConverter;
        private readonly HomeController _controller;

        public AmountControllerTests()
        {
            // Mock the ILogger dependency
            Mock<ILogger<HomeController>> mockLogger = new();

            // Mock the INumberToWordsConverter dependency
            _mockConverter = new Mock<INumberToWordsConverter>();

            // Inject the mock service into the controller
            _controller = new HomeController(mockLogger.Object, _mockConverter.Object);
        }

        [Fact]
        public void Index_GetRequest_ReturnsView()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model); // On GET request, the model should be null
        }

        [Fact]
        public void Index_PostRequestValidAmount_ReturnsViewWithModel()
        {
            // Arrange
            const decimal amount = 2523.45m;
            const string expectedWords = "Two thousand five hundred twenty-three and 45/100 dollars";

            // Set up the mock converter to return the expected words
            _mockConverter.Setup(x => x.ConvertAmountToWords(amount))
                          .Returns(expectedWords);

            // Act
            var result = _controller.Index(amount);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<AmountModel>(viewResult.Model);
            Assert.Equal(amount, model.Amount);
            Assert.Equal(expectedWords, model.AmountInWords);
        }

        [Theory]
        [InlineData(-45.67, "Minus forty-five and 67/100 dollars")]
        [InlineData(1000, "One thousand dollars")]
        public void Index_PostRequest_ReturnsExpectedWords(decimal amount, string expectedWords)
        {
            // Arrange
            _mockConverter.Setup(x => x.ConvertAmountToWords(amount))
                          .Returns(expectedWords);

            // Act
            var result = _controller.Index(amount);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<AmountModel>(viewResult.Model);
            Assert.Equal(amount, model.Amount);
            Assert.Equal(expectedWords, model.AmountInWords);
        }

        [Fact]
        public void Index_PostRequest_CallsConverterWithCorrectAmount()
        {
            // Arrange
            const decimal amount = 123.45m;

            // Act
            _controller.Index(amount);

            // Assert
            _mockConverter.Verify(x => x.ConvertAmountToWords(amount), Times.Once);
        }
    }
}
