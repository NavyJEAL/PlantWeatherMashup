namespace Mashup.Services;
public class AdviceService
{
	private readonly HttpClient _httpClient;
	public AdviceService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
}