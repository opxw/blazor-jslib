using Microsoft.Extensions.DependencyInjection;

namespace Opx.Blazor.JsLib
{
	public static class JsLibSetupExtension
	{
		public static IServiceCollection AddInteractiveBlazorJsLib(this IServiceCollection s, JsLibGlobalOptions? options = null)
		{
			var opt = options == null ? new JsLibGlobalOptions() : options;
			s.AddScoped<JsLibGlobalOptions>(o => opt);
			s.AddScoped<JsLibInteropCore>();
			s.AddScoped<JsLibInterop>();

			return s;
		}
	}
}
