using Microsoft.JSInterop;

namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMInterop
	{
		private readonly JsLibDOMGlobalOptions _options;
		private readonly JsLibDOMInteropCore _core;
		private JsLibDOMHead _head;
		private JsLibDOMBody _body;
		private JsLibDOMElements _elements;

		public JsLibDOMInterop(JsLibDOMInteropCore core, JsLibDOMGlobalOptions options)
		{
			_options = options;
			_core = core;
			_head = new JsLibDOMHead(core, _options);
			_body = new JsLibDOMBody(core, _options);
			_elements = new JsLibDOMElements(core, _options);
		}

		public JsLibDOMHead Head => _head;
		public JsLibDOMBody Body => _body;
		public JsLibDOMElements Elements => _elements;

		public async Task ConsoleLog(string msg)
		{
			var v = await _core.GetInvoker();
			await v.InvokeVoidAsync("consoleLog", msg, true);
		}
	}
}
