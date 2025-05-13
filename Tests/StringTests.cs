using ProgramForTest;

public class StringTests
{
    [Fact]
    public void CalculateNewLines_ReturnsCorrectAmount()
    {
        // Arrange
        var input = "Hej\nNy rad\nNy rad igen!";

        // Act
        int count = StringUtility.CalculateNewLines(input);

        // Assert
        Assert.Equal(2, count);
    }
}
