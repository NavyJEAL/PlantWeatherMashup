namespace Mashup.Services;
public class CoordinatesService
{
	private readonly HttpClient _httpClient;

	public CoordinatesService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

}