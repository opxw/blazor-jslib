using Microsoft.JSInterop;

namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMHead : JsLibDOMPropBase
	{
		public JsLibDOMHead(JsLibDOMInteropCore js, JsLibDOMGlobalOptions options) : base(js, options)
		{
		}

		public async Task AddCss(string url)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addCss", url, 0, Options.ShowConsoleLog);
		}

		public async Task AddJs(string url, bool async = false)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addJs", url, 0, async, Options.ShowConsoleLog);
		}
	}
}