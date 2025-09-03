using FastEnumUtility;
using Microsoft.JSInterop;

namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMInterop
	{
		private readonly JsLibDOMGlobalOptions _options;
		private readonly JsLibDOMInteropCore _core;
		private JsLibDOMDoc _doc;
		private JsLibDOMHead _head;
		private JsLibDOMBody _body;
		private JsLibDOMElements _elements;

		public JsLibDOMInterop(JsLibDOMInteropCore core, JsLibDOMGlobalOptions options)
		{
			_options = options;
			_core = core;
			_doc = new JsLibDOMDoc(core, options);
			_head = new JsLibDOMHead(core, _options);
			_body = new JsLibDOMBody(core, _options);
			_elements = new JsLibDOMElements(core, _options);
		}

		public JsLibDOMDoc Doc => _doc;
		public JsLibDOMHead Head => _head;
		public JsLibDOMBody Body => _body;
		public JsLibDOMElements Elements => _elements;

		public async Task ConsoleLog(object msg)
		{
			var v = await _core.GetInvoker();
			await v.InvokeVoidAsync(FuncMap.ConsoleLog.GetLabel(), msg);
		}
	}
}
