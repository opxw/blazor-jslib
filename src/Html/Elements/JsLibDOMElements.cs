namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMElements : JsLibDOMPropBase
	{
		private JsLibDOMById _domById;
		private JsLibDOMByName _domByName;

		public JsLibDOMElements(JsLibDOMInteropCore js, JsLibDOMGlobalOptions options) : base(js, options)
		{
			_domById = new JsLibDOMById("", JS, Options);
			_domByName = new JsLibDOMByName("", JS, Options);
		}

		public JsLibDOMById ById(string id)
		{
			_domById.Id = id;
			return _domById;
		}

		public JsLibDOMByName ByName(string id)
		{
			_domByName.Name = id;
			return _domByName;
		}
	}
}