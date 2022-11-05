using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Ardalis.ApiEndpoint;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
	[HttpGet("modelbinding/{id}")]
	public IActionResult WithModelBinding([FromModel] DemoDynamicModel demoModel)
	{
		return StatusCode(StatusCodes.Status204NoContent);
	}
}
