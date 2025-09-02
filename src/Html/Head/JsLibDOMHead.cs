using Microsoft.JSInterop;
using Opx.Blazor.JsLibDOM.Utils;

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
			var f = FuncMap.DocAddCss;
			await v.InvokeVoidAsync(f.fn(), url, 0, 
				Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task AddJs(string url, bool async = false)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.DocAddJs;
			await v.InvokeVoidAsync(f.fn(), url, 0, async, 
				Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task AddMeta(string name, string content)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.HeadAddMeta;
			await v.InvokeVoidAsync(f.fn(), name, content, 
				Options.ShowExecutionLog ? f.ToString() : null);
		}
	}
}