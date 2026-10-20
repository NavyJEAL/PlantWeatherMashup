using DTO;

public class PlantModel
{
	public int PlantID {get; set;}
	public string? PlantName {get; set;}
	public string? Watering {get; set;}
	public string? Sunlight {get; set;}
	public bool Indoor {get; set;}
	public HardinessDto? Hardiness { get; set; }
	public string? ImageUrl { get; set; }

}