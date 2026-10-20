using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mashup.Models;
using Mashup.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Mashup.Controllers;

[ApiController]
[Route("api/plant-search")]
public class SearchController : ControllerBase
{
	readonly PlantService _plantService;
	readonly IMemoryCache _cache;

		public SearchController(PlantService plantService, IMemoryCache cache){
		_plantService = plantService;
		_cache = cache;
	}

	[HttpGet]
	public async Task<IActionResult> SearchPlants([FromQuery] string searchInput)
	{
		if(string.IsNullOrWhiteSpace(searchInput) || searchInput.Length < 3)
		{
			return BadRequest("Search query must be at least 3 characters long.");
		}

		var normalizedName = searchInput.Trim().ToLowerInvariant();
		var key = $"plant_search_{normalizedName}";

		if(_cache.TryGetValue(key, out var hit))
		{
			return Ok(hit);
		}

		var plants = await _plantService.Search(normalizedName);
		_cache.Set(key, plants, TimeSpan.FromHours(1));
		return Ok(plants);
	}
}