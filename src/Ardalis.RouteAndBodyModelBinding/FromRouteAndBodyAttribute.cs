using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ardalis.RouteAndBodyModelBinding;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FromRouteAndBodyAttribute : Attribute, IBindingSourceMetadata
{
	public BindingSource BindingSource => RouteAndBodyBindingSource.RouteAndBody;
}
