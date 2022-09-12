using Moq;
using Services;

namespace TestFixture;

public class MyServiceUnitTest
{
    [Fact]
    public void DoService_UnitTest()
    {
        // Arrange
        var myHelper = new Mock<IMyHelper>();
        var sut = new MyService(myHelper.Object);

        // Act
        sut.DoService();

        // Assert
    }
}