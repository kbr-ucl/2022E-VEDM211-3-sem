using System.Diagnostics.Metrics;

namespace MyBusinessLogic
{
    public interface ITemperatureService
    {
        public double GetMaxTemperature(DateTime fromDateTime, DateTime toDateTime);
        public double GetMinTemperature(DateTime fromDateTime, DateTime toDateTime);
        public double GetAverageTemperature(DateTime fromDateTime, DateTime toDateTime);
    }

    public class TemperatureService : ITemperatureService
    {
        private readonly ITemperatureLoader _temperatureLoader;

        public TemperatureService(ITemperatureLoader temperatureLoader)
        {
            _temperatureLoader = temperatureLoader;
        }

        double ITemperatureService.GetMaxTemperature(DateTime fromDateTime, DateTime toDateTime)
        {
            var measurements = _temperatureLoader.LoadTemperature();
            return measurements.Where(m => m.Time >= fromDateTime && m.Time <= toDateTime).Max(a => a.Temperature);
        }

        double ITemperatureService.GetAverageTemperature(DateTime fromDateTime, DateTime toDateTime)
        {
            var measurements = _temperatureLoader.LoadTemperature();
            return measurements.Where(m => m.Time >= fromDateTime && m.Time <= toDateTime).Average(a => a.Temperature);
        }

        double ITemperatureService.GetMinTemperature(DateTime fromDateTime, DateTime toDateTime)
        {
            var measurements = _temperatureLoader.LoadTemperature();
            return measurements.Where(m => m.Time >= fromDateTime && m.Time <= toDateTime).Min(a => a.Temperature);
        }
    }
}