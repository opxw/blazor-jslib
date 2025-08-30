using Microsoft.JSInterop;

namespace Opx.Blazor.JsLib
{
	public class JsLibPropBase
	{
		private JsLibInteropCore _js;
		private JsLibGlobalOptions _options;

		public JsLibPropBase(JsLibInteropCore js, JsLibGlobalOptions options)
		{
			_js = js;
			_options = options;
		}

		protected JsLibInteropCore JS => _js;
		protected JsLibGlobalOptions Options => _options;
		
		protected string ToJsArray(string[] args)
		{
			return System.Text.Json.JsonSerializer.Serialize(args);
		}
	}

	public class JsLibHead : JsLibPropBase
	{
		public JsLibHead(JsLibInteropCore js, JsLibGlobalOptions options) : base(js, options)
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

	public class JsLibBody : JsLibPropBase
	{
		public JsLibBody(JsLibInteropCore js, JsLibGlobalOptions options) : base(js, options)
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
			await v.InvokeVoidAsync("addClassToBody", ToJsArray(names), Options.ShowConsoleLog);
		}

		public async Task AddClass(string name)
		{
			var v = await JS.GetInvoker();
			var arg = ToJsArray(new string[] { name });
			await v.InvokeVoidAsync("addClassToBody", arg, Options.ShowConsoleLog);
		}
	}

	public class JsLibElement
	{
	}
}