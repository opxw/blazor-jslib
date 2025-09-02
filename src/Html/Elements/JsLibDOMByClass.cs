namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMByClass
	{
		private JsLibDOMClassOperation _classOpr = new();
		private JsLibDOMAttributeOperation _attrOpr = new();
		private JsLibDOMInteropCore _core;

		private string _id = string.Empty;

		public JsLibDOMByClass(string id, JsLibDOMInteropCore core,
			JsLibDOMGlobalOptions options)
		{
			_classOpr.Identifier = id;
			_attrOpr.Identifier = id;

			_classOpr.ElementBy = DOMElementBy.Class;
			_attrOpr.ElementBy = DOMElementBy.Class;

			_core = core;
			_classOpr.ShowExecutionLog = options.ShowExecutionLog;
			_attrOpr.ShowExecutionLog = options.ShowExecutionLog;
		}

		public string Id
		{
			get => _id;
			set
			{
				_id = value;
				_classOpr.Identifier = _id;
				_attrOpr.Identifier = _id;
			}
		}

		public async Task AddClass(string className)
		{
			_classOpr.Operation = DOMClassOperation.Add;
			_classOpr.ClassNames = null;
			_classOpr.ClassName = className;

			await _core.ModifyElementClass(_classOpr);
		}

		public async Task AddClasses(string[] classNames)
		{
			_classOpr.Operation = DOMClassOperation.Add;
			_classOpr.ClassName = null;
			_classOpr.ClassNames = classNames;

			await _core.ModifyElementClass(_classOpr);
		}

		public async Task RemoveClass(string className)
		{
			_classOpr.Operation = DOMClassOperation.Remove;
			_classOpr.ClassNames = null;
			_classOpr.ClassName = className;

			await _core.ModifyElementClass(_classOpr);
		}

		public async Task RemoveClasses(string[] classNames)
		{
			_classOpr.Operation = DOMClassOperation.Remove;
			_classOpr.ClassNames = classNames;
			_classOpr.ClassName = null;

			await _core.ModifyElementClass(_classOpr);
		}

		public async Task SetAttribute(string name, object? value)
		{
			_attrOpr.Operation = DOMAttributeOperation.Set;
			_attrOpr.Name = name;
			_attrOpr.Value = value;

			await _core.ModifyElementAttribute(_attrOpr);
		}
	}
}