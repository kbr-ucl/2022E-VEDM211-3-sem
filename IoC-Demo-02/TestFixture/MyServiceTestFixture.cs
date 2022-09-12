using Helpers;
using Services;

namespace TestFixture
{
    public class MyServiceTestFixture
    {
        [Fact]
        public void MyHelper_Gets_Called()
        {
            // Arrange
            var sut = new MyService(new MyHelper());

            // Act

            // Assert
            Assert.Throws<NotImplementedException>( () => sut.DoService());

        }
    }
}