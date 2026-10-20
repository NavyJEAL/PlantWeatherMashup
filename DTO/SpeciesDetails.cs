using System.Text.Json.Serialization;
using DTO;

namespace DTO;
public class SpeciesDetails
{
	[JsonPropertyName("watering")]
	public string? Watering { get; set;}

	[JsonPropertyName("sunlight")]
	public List<string>? Sunlight { get; set; }

	[JsonPropertyName("indoor")]
	public bool Indoor { get; set;}

    [JsonPropertyName("hardiness")]
    public HardinessDto? Hardiness { get; set; }

	[JsonPropertyName("default_image")] 
	public ImageDto? DefaultImage { get; set; }

}

public class HardinessDto
{
    [JsonPropertyName("min")]
    public string? Min { get; set; }

    [JsonPropertyName("max")]
    public string? Max { get; set; }
}
