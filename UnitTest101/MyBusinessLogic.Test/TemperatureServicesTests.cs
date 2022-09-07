using Moq;
using Xunit;

namespace MyBusinessLogic.Test
{
    //https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
    //https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq
    public class TemperatureServicesTests
    {
        [Theory]
        [InlineData(2022, 9, 19, 12, 50, 30, 2022, 9, 20, 23, 59, 59, 26.0)]
        [InlineData(2022, 9, 20, 12, 50, 30, 2022, 9, 20, 23, 59, 58, 25.5)]
        [InlineData(2022, 9, 21, 0, 0, 0, 2022, 9, 22, 23, 59, 58, 30.0)]
        public void GetMaxTemperature(
            int fromYear, int fromMonth, int fromDay, int fromHour,int fromMinut,int fromSecond,
            int toYear, int toMonth, int toDay, int toHour,int toMinut,int toSecond,
            double expected)
        {
            // Arrange
            var fromDate = new DateTime(fromYear, fromMonth, fromDay, fromHour, fromMinut, fromSecond);
            var toDate = new DateTime(toYear, toMonth, toDay, toHour, toMinut, toSecond);

            var temperatureLoaderMoq = new Mock<ITemperatureLoader>();
            temperatureLoaderMoq.Setup(t => t.LoadTemperature()).Returns(TemperatureMeasurements());

            var sut = new TemperatureService(temperatureLoaderMoq.Object) as ITemperatureService;

            // Act
            var actual = sut.GetMaxTemperature(fromDate, toDate);

            // Assert
            Assert.Equal(expected, actual);
        }


        private IEnumerable<TemperatureMeasurement> TemperatureMeasurements()
        {
            yield return new TemperatureMeasurement { Temperature = 24.0, Time = new DateTime(2022, 9, 20, 11, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 24.5, Time = new DateTime(2022, 9, 20, 12, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 25.0, Time = new DateTime(2022, 9, 20, 13, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 25.5, Time = new DateTime(2022, 9, 20, 14, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 26.0, Time = new DateTime(2022, 9, 20, 23, 59, 59) };
            yield return new TemperatureMeasurement { Temperature = 30.0, Time = new DateTime(2022, 9, 21, 0, 0, 0) };
            yield return new TemperatureMeasurement { Temperature = 29.0, Time = new DateTime(2022, 9, 21, 12, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 28.0, Time = new DateTime(2022, 9, 21, 13, 50, 30) };
            yield return new TemperatureMeasurement { Temperature = 27.0, Time = new DateTime(2022, 9, 21, 14, 50, 30) };
        }
    }
}