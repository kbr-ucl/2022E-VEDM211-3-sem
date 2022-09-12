using Ejendom.BusinessLogic.Step04;
using Moq;
using Xunit;

namespace Ejendom.BusinessLogic.Test.EjendomBeregnerServiceTests.Step05;

// Step 5.
// Anvendelse af Moq frameworket til at lave test Mock's

public class BeregnKvadratmeterTests
{
    [Fact]
    public void BeregnKvadratmeter_Beregnes_Korrekt()
    {
        // Arrange
        var ejendomRepositoryMock = new Mock<IEjendomRepository>();
        ejendomRepositoryMock.Setup(m => m.ReadEjendoms()).Returns(Ejendoms());

        var sut = new EjendomBeregnerService(ejendomRepositoryMock.Object) as IEjendomBeregnerService;
        var expected = 11.0;

        // Act
        var actual = sut.BeregnKvadratmeter();

        // Assert
        Assert.Equal(expected, actual);
    }

    private IEnumerable<EjendomEntity> Ejendoms()
    {
        yield return new EjendomEntity {AntalRum = 2, Kvadratmeter = 4.5, Lejlighednummer = 1};
        yield return new EjendomEntity {AntalRum = 3.5, Kvadratmeter = 6.5, Lejlighednummer = 2};
    }
}
