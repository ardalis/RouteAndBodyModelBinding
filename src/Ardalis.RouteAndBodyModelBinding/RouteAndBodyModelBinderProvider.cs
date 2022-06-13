using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Ardalis.RouteAndBodyModelBinding;

public class RouteAndBodyModelBinderProvider : IModelBinderProvider
{
	private BodyModelBinderProvider _bodyModelBinderProvider;
	private ComplexObjectModelBinderProvider _complexTypeModelBinderProvider;

	public RouteAndBodyModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider,
		ComplexObjectModelBinderProvider complexTypeModelBinderProvider)
	{
		_bodyModelBinderProvider = bodyModelBinderProvider;
		_complexTypeModelBinderProvider = complexTypeModelBinderProvider;
	}

	public IModelBinder GetBinder(ModelBinderProviderContext context)
	{
		var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
		var complexBinder = _complexTypeModelBinderProvider.GetBinder(context);

		if (context.BindingInfo.BindingSource != null
			&& context.BindingInfo.BindingSource.CanAcceptDataFrom(RouteAndBodyBindingSource.RouteAndBody))
		{
			return new RouteAndBodyModelBinder(bodyBinder, complexBinder);
		}
		return null;
	}
}
