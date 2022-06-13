using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ardalis.RouteAndBodyModelBinding;

public class RouteAndBodyBindingSource : BindingSource
{
	public const string ID = "RouteAndBody";

	public static readonly BindingSource RouteAndBody = new RouteAndBodyBindingSource(
		ID,
		ID,
		true,
		true
		);

	public RouteAndBodyBindingSource(string id, string displayName, bool isGreedy, bool isFromRequest) : base(id, displayName, isGreedy, isFromRequest)
	{
	}

	public override bool CanAcceptDataFrom(BindingSource bindingSource)
	{
		return bindingSource == Body || bindingSource == this;
	}
}
