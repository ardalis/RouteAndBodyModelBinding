using Microsoft.AspNetCore.Mvc;

namespace Ardalis.ApiEndpoint;

public class DemoDynamicModel
{
	[FromRoute]
	public int? Id { get; set; }
	[FromQuery]
	public string Value1 { get; set; }
	[FromQuery]
	public bool Value2 { get; set; }
}
