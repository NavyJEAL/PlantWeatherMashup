using Microsoft.EntityFrameworkCore;
using DTO;

namespace Mashup.Services;

public class PlantService
{
	private readonly HttpClient _httpClient;
	private readonly string _apikey;
	private readonly AppDbContext _dbContext;	

	public PlantService(HttpClient httpClient, IConfiguration configuration, AppDbContext dbContext)
	{
		_httpClient = httpClient;
		_apikey = configuration["PlantApiKey"] ?? throw new ArgumentNullException("PlantApiKey is not set in configuration.");
		_dbContext = dbContext;
	}

	public async Task<List<PlantModel>> Search(string plantName)
	{
		var url = $"species-list?key={_apikey}&q={Uri.EscapeDataString(plantName)}";
		var response = await _httpClient.GetAsync(url);
		response.EnsureSuccessStatusCode();

		var result = await response.Content.ReadFromJsonAsync<SearchResult>();
		return result?.Data?.Select(MapToPlantModel).ToList() ?? new List<PlantModel>();
	}

	private static PlantModel MapToPlantModel(SpeciesDto dto) => new PlantModel
	{
		PlantID = dto.Id,
		PlantName = dto.CommonName ?? "Unknown",
		ImageUrl = dto.DefaultImage?.Thumbnail
	};
}