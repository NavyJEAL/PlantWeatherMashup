namespace Mashup.Services;
public class PlantService
{
	private readonly HttpClient _httpClient;

	public PlantService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

}