
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ardalis.ApiEndpoint;

public sealed class FromModelAttribute : Attribute, IBindingSourceMetadata
{
	public BindingSource BindingSource { get; } = BindingSource.ModelBinding;
}
