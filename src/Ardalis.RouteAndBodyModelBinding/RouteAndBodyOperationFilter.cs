using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ardalis.RouteAndBodyModelBinding;


// or this one by https://github.com/fooberichu150
public class RouteAndBodyOperationFilter : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		var hybridParameters = context.ApiDescription.ParameterDescriptions
		 .Where(x => x.Source.Id == RouteAndBodyBindingSource.ID)
		 .Select(x => new { name = x.Name }).ToList();

		if (!hybridParameters.Any())
			return;

		var parameters = operation.Parameters.Where(p => hybridParameters.Any(hp => p.Name == hp.name)).ToList();

		foreach (OpenApiParameter parameter in parameters)
		{
			var name = parameter.Name;
			var isRequired = parameter.Required;
			var hybridMediaType = new OpenApiMediaType { Schema = parameter.Schema };

			operation.RequestBody = new OpenApiRequestBody
			{
				Content = new Dictionary<string, OpenApiMediaType>
												{
														{ "application/json", hybridMediaType }
												},
				Required = isRequired
			};

			operation.Parameters.Remove(parameter);
		}
	}
}
