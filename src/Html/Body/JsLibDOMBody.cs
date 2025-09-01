using Microsoft.JSInterop;

namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMBody : JsLibDOMPropBase
	{
		public JsLibDOMBody(JsLibDOMInteropCore js, JsLibDOMGlobalOptions options) : base(js, options)
		{
		}

		public async Task AddCss(string url)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addCss", url, 1, Options.ShowConsoleLog);
		}

		public async Task AddJs(string url, bool async = false)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addJs", url, 1, async, Options.ShowConsoleLog);
		}

		public async Task AddClasses(string[] names)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addClassesToBody", names, Options.ShowConsoleLog);
		}

		public async Task AddClass(string name)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("addClassToBody", name, Options.ShowConsoleLog);
		}

		public async Task RemoveClasses(string[] names)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("remClassesFromBody", names, Options.ShowConsoleLog);
		}

		public async Task RemoveClass(string name)
		{
			var v = await JS.GetInvoker();
			await v.InvokeVoidAsync("remClassFromBody", name, Options.ShowConsoleLog);
		}
	}
}