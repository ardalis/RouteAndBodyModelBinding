using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Ardalis.RouteAndBodyModelBinding;

public static class RouteAndBodyModelBinderProviderSetup
{
	public static void InsertRouteAndBodyBinding(this IList<IModelBinderProvider> providers)
	{
		var bodyProvider = providers.Single(provider => provider.GetType() == typeof(BodyModelBinderProvider)) as BodyModelBinderProvider;
		var complexProvider = providers.Single(provider => provider.GetType() == typeof(ComplexObjectModelBinderProvider)) as ComplexObjectModelBinderProvider;

		var RouteAndBodyProvider = new RouteAndBodyModelBinderProvider(bodyProvider, complexProvider);

		providers.Insert(0, RouteAndBodyProvider);
	}
}
