using Microsoft.JSInterop;
using Opx.Blazor.JsLibDOM.Utils;

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
			var f = FuncMap.DocAddCss;
			await v.InvokeVoidAsync(f.fn(), url, 1, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task AddJs(string url, bool async = false)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.DocAddJs;
			await v.InvokeVoidAsync(f.fn(), url, 1, async, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task AddClasses(string[] names)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyAddClasses;
			await v.InvokeVoidAsync(f.fn(), names, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task AddClass(string name)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyAddClass;
			await v.InvokeVoidAsync(f.fn(), name, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task RemoveClasses(string[] names)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyRemoveClasses;
			await v.InvokeVoidAsync(f.fn(), names, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task RemoveClass(string name)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyRemoveClass;
			await v.InvokeVoidAsync(f.fn(), name, Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task SetAttribute(string name, object value)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyModifyAttribute;
			await v.InvokeVoidAsync(f.fn(), (int)DOMAttributeOperation.Set, name, value, 
				Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task RemoveAttribute(string name)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.BodyModifyAttribute;
			await v.InvokeVoidAsync(f.fn(), (int)DOMAttributeOperation.Remove, name, null, 
				Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task ResetClass()
		{
			await RemoveAttribute("class");
		}
	}
}