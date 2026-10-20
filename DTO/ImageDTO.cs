using System.Text.Json.Serialization;

namespace DTO;

public class ImageDTO
{
	[JsonPropertyName("default_image")]
    public ImageDto? DefaultImage { get; set; }
}

public class ImageDto
{
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("small_url")]
    public string? SmallUrl { get; set; }

    [JsonPropertyName("regular_url")]
    public string? RegularUrl { get; set; }
}
