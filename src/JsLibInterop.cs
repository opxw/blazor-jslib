using Microsoft.JSInterop;

namespace Opx.Blazor.JsLib
{
	public class JsLibInterop
	{
		private readonly JsLibGlobalOptions _options;
		private readonly JsLibInteropCore _core;
		private JsLibHead _head;
		private JsLibBody _body;

		public JsLibInterop(JsLibInteropCore core, JsLibGlobalOptions options)
		{
			_options = options;
			_core = core;
			_head = new JsLibHead(core, _options);
			_body = new JsLibBody(core, _options);
		}

		public JsLibHead Head => _head;
		public JsLibBody Body => _body;

		public async Task ConsoleLog(string msg)
		{
			var v = await _core.GetInvoker();
			await v.InvokeVoidAsync("consoleLog", msg, true);
		}
	}
}
