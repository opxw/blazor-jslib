namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMAttributeOperation : JsLibDOMOperationBase
	{
		public string Name { get; set; }
		public object? Value { get; set; }
		public DOMAttributeOperation Operation { get; set; }
	}
}