using System.Text.Json;
using System.Text.Json.Serialization;

namespace DTO;

public class SearchResult
{
	[JsonPropertyName("data")]
	public  List<SpeciesDto>? Data { get; set; }
}

public class SpeciesDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("common_name")]
    public string? CommonName { get; set; }
	
	[JsonPropertyName("default_image")] 
	public ImageDto? DefaultImage { get; set; }
}
