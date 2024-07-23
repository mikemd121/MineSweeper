using MineSweeper;
using Xunit;

namespace Minesweeper.Tests
{
    public class InputHandlerTests
    {
        [Theory]
        [InlineData("A1", 0, 0, 4)]
        [InlineData("B2", 1, 1, 4)]
        [InlineData("D4", 3, 3, 4)]
        [InlineData("C3", 2, 2, 4)]
        public void TryParseInput_ValidInput_ReturnsTrue(string input, int expectedX, int expectedY, int gridSize)
        {
            bool result = UserInputManager.TryParseCoordinates(input, gridSize, out int x, out int y);

            Assert.True(result);
            Assert.Equal(expectedX, x);
            Assert.Equal(expectedY, y);
        }

        [Theory]
        [InlineData("A5", 4)]
        [InlineData("E1", 4)]
        [InlineData("A0", 4)]
        [InlineData("1A", 4)]
        public void TryParseInput_InvalidInput_ReturnsFalse(string input, int gridSize)
        {
            bool result = UserInputManager.TryParseCoordinates(input, gridSize, out int x, out int y);

            Assert.False(result);
        }
    }
}
