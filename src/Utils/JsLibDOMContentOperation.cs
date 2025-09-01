namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMContentOperation : JsLibDOMOperationBase
	{
		public string? Content { get; set; } = null;
		public DOMContentType ContentType { get; set; }
		public DOMContentOperation Operation { get; set; }
	}
}