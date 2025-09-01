namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMByName
	{
		private JsLibDOMClassOperation _classOpr = new();
		private JsLibDOMAttributeOperation _attrOpr = new();
		private JsLibDOMInteropCore _core;

		private string _name = string.Empty;

		public JsLibDOMByName(string name, JsLibDOMInteropCore core,
			JsLibDOMGlobalOptions options)
		{
			_classOpr.Identifier = name;
			_attrOpr.Identifier = name;

			_classOpr.ElementBy = DOMElementBy.Name;
			_attrOpr.ElementBy = DOMElementBy.Name;

			_core = core;
			_classOpr.ShowConsoleLog = options.ShowConsoleLog;
			_attrOpr.ShowConsoleLog = options.ShowConsoleLog;
		}

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				_classOpr.Identifier = _name;
				_attrOpr.Identifier = _name;
			}
		}

		public async Task AddClass(string className)
		{
			_classOpr.Operation = DOMClassOperation.Add;
			_classOpr.ClassNames = null;
			_classOpr.ClassName = className;

			await _core.ModifyClass(_classOpr);
		}

		public async Task AddClasses(string[] classNames)
		{
			_classOpr.Operation = DOMClassOperation.Add;
			_classOpr.ClassName = null;
			_classOpr.ClassNames = classNames;

			await _core.ModifyClass(_classOpr);
		}

		public async Task RemoveClass(string className)
		{
			_classOpr.Operation = DOMClassOperation.Remove;
			_classOpr.ClassNames = null;
			_classOpr.ClassName = className;

			await _core.ModifyClass(_classOpr);
		}

		public async Task RemoveClasses(string[] classNames)
		{
			_classOpr.Operation = DOMClassOperation.Remove;
			_classOpr.ClassNames = classNames;
			_classOpr.ClassName = null;

			await _core.ModifyClass(_classOpr);
		}

		public async Task SetAttribute(string name, object? value)
		{
			_attrOpr.Operation = DOMAttributeOperation.Set;
			_attrOpr.Name = name;
			_attrOpr.Value = value;

			await _core.ModifyAttribute(_attrOpr);
		}
	}
}