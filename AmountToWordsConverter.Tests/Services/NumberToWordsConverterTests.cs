using AmountToString.Services;

namespace AmountToWordsConverter.Tests.Services
{
    public class NumberToWordsConverterTests
    {
        [Theory]
        [InlineData(2523.45, "Two thousand five hundred twenty-three and 45/100 dollars")]
        [InlineData(1000000, "One million dollars")]
        [InlineData(0, "Zero dollars")]
        [InlineData(1, "One dollar")]
        [InlineData(100, "One hundred dollars")]
        [InlineData(1000, "One thousand dollars")]
        [InlineData(1000000000, "One billion dollars")]
        public void ConvertAmountToWords_ValidAmounts_ReturnsExpectedString(decimal amount, string expected)
        {
            // Arrange - Initialize the service
            var converter = new NumberToWordsConverter();

            // Act
            var result =  converter.ConvertAmountToWords(amount);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertAmountToWords_NegativeAmount_ReturnsMinusInWords()
        {
            // Arrange - Initialize the service
            var converter = new NumberToWordsConverter();

            // Act
            var result = converter.ConvertAmountToWords(-45.67m);

            // Assert
            Assert.Equal("Minus Forty-five and 67/100 dollars", result);
        }

        [Theory]
        [InlineData(1000000000, "One billion dollars")]
        [InlineData(1000000000.99, "One billion and 99/100 dollars")]
        public void ConvertAmountToWords_LargeNumbers_ReturnsExpectedWords(decimal amount, string expected)
        {
            // Arrange - Initialize the service
            var converter = new NumberToWordsConverter();

            // Act
            var result = converter.ConvertAmountToWords(amount);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}