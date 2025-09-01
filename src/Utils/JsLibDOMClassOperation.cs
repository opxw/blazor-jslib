namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMClassOperation : JsLibDOMOperationBase
	{
		public string? ClassName { get; set; }
		public string[]? ClassNames { get; set; }
		public DOMClassOperation Operation { get; set; }
	}
}