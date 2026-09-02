public class DailyForecast
{
	public DateOnly Date {get; set;}
	public int WeatherCode {get; set;}
	public double TemperatureMin {get; set;} // I Celcius 
	public double TemperatureMax {get; set;} // I Celcius
	public double Precipitation {get; set;} // Nederbörd
}