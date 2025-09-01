using Microsoft.Extensions.DependencyInjection;

namespace Opx.Blazor.JsLibDOM
{
	public static class JsLibSetupExtension
	{
		public static IServiceCollection AddInteractiveBlazorJsLibDOM(this IServiceCollection s, JsLibDOMGlobalOptions? options = null)
		{
			var opt = options == null ? new JsLibDOMGlobalOptions() : options;
			s.AddScoped(o => opt);
			s.AddScoped<JsLibDOMInteropCore>();
			s.AddScoped<JsLibDOMInterop>();

			return s;
		}
	}
}
