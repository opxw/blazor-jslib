using Microsoft.JSInterop;
using Opx.Blazor.JsLibDOM.Utils;

namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMDoc : JsLibDOMPropBase
	{
		public JsLibDOMDoc(JsLibDOMInteropCore js, JsLibDOMGlobalOptions options) : base(js, options)
		{
		}

		public async Task SetAttribute(string name, object value)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.DocModifyAttribute;
			await v.InvokeVoidAsync(f.fn(), (int)DOMAttributeOperation.Set, name, value,
				Options.ShowExecutionLog ? f.ToString() : null);
		}

		public async Task RemoveAttribute(string name, object value)
		{
			var v = await JS.GetInvoker();
			var f = FuncMap.DocModifyAttribute;
			await v.InvokeVoidAsync(f.fn(), (int)DOMAttributeOperation.Remove, name, null,
				Options.ShowExecutionLog ? f.ToString() : null);
		}
	}
}