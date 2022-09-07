namespace MyBusinessLogic;

public class TemperatureMeasurement
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
}

public interface ITemperatureLoader
{
    public IEnumerable<TemperatureMeasurement> LoadTemperature();
}

public class TemperatureLoader : ITemperatureLoader
{
    public IEnumerable<TemperatureMeasurement> LoadTemperature()
    {
        throw new NotImplementedException();
    }
}