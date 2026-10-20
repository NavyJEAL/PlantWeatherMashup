using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mashup.Models;
using Mashup.Services;

namespace Mashup.Controllers;

public class PlantController : Controller
{
	private readonly PlantService _plantService;
	private readonly AdviceService _adviceService;

	public PlantController(PlantService plantService, AdviceService adviceService)
	{
		_plantService = plantService;
		_adviceService = adviceService;
	}
	
	// CRUD operationer här nere

}