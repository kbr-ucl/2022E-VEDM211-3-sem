using Ejendom.BusinessLogic.Step02;
using Xunit;

namespace Ejendom.BusinessLogic.Test.EjendomBeregnerServiceTests.Step03
{
    public class BeregnKvadratmeterTests
    {
        [Fact]
        public void BeregnKvadratmeter_Beregnes_Korrekt()
        {
            // Arrange
            var ejendomRepositoryMock = new EjendomRepositoryMock();
            var sut = new Step02.EjendomBeregnerService(ejendomRepositoryMock);
            var expected = 11.0;

            // Act
            var actual = sut.BeregnKvadratmeter("");

            // Assert
            Assert.Equal(expected, actual);
        }
    }

    public class EjendomRepositoryMock : IEjendomRepository
    {
        public IEnumerable<EjendomEntity> ReadEjendoms(string lejemaalDataFilename)
        {
            yield return new EjendomEntity {AntalRum = 2, Kvadratmeter = 4.5, Lejlighednummer = 1};
            yield return new EjendomEntity {AntalRum = 3.5, Kvadratmeter = 6.5, Lejlighednummer = 2};
        }
    }
}