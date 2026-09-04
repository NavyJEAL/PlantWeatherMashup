namespace Mashup.Services;
public class WeatherService
{
	private readonly HttpClient _httpClient;

	public WeatherService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

}
