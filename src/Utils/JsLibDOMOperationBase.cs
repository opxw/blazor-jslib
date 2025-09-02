namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMOperationBase
	{
		public string? Identifier { get; set; } = null;
		public DOMElementBy ElementBy { get; set; }
		public bool ShowExecutionLog { get; set; }
	}
}