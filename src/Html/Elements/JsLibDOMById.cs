namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMById
	{
		private JsLibDOMClassOperation _classOpr = new();
		private JsLibDOMAttributeOperation _attrOpr = new();
		private JsLibDOMContentOperation _contentOpr = new();
		private JsLibDOMInteropCore _core;
		
		private string _id = string.Empty;
		private bool _globalShowLog = false;

		public JsLibDOMById(string id, JsLibDOMInteropCore core,
			JsLibDOMGlobalOptions options)
		{
			_globalShowLog = options.ShowExecutionLog;

			_classOpr.Identifier = id;
			_attrOpr.Identifier = id;
			_contentOpr.Identifier = id;

			_classOpr.ElementBy = DOMElementBy.Id;
			_attrOpr.ElementBy = DOMElementBy.Id;
			_contentOpr.ElementBy = DOMElementBy.Id;

			_core = core;
			_classOpr.ShowExecutionLog = _globalShowLog;
			_attrOpr.ShowExecutionLog = _globalShowLog;
			_contentOpr.ShowExecutionLog = _globalShowLog;
		}

		public string Id
		{
			get => _id;
			set
			{
				_id = value;
				_classOpr.Identifier = _id;
				_attrOpr.Identifier = _id;
				_contentOpr.Identifier = _id;
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

		public async Task RemoveAttribute(string name)
		{
			_attrOpr.Operation = DOMAttributeOperation.Remove;
			_attrOpr.Name = name;

			await _core.ModifyElementAttribute(_attrOpr);
		}

		public async Task AddContent(string content)
		{
			_contentOpr.Operation = DOMContentOperation.Add;
			_contentOpr.ContentType = DOMContentType.Text;
			_contentOpr.Content = content;

			await _core.ModifyElementContent(_contentOpr);
		}

		public async Task RemoveContent()
		{
			_contentOpr.Operation = DOMContentOperation.Remove;
			_contentOpr.ContentType = DOMContentType.Text;

			await _core.ModifyElementContent(_contentOpr);
		}
		public async Task AddHtmlContent(string content)
		{
			_contentOpr.Operation = DOMContentOperation.Add;
			_contentOpr.ContentType = DOMContentType.InnerHTML;
			_contentOpr.Content = content;

			await _core.ModifyElementContent(_contentOpr);
		}

		public async Task RemoveHtmlContent()
		{
			_contentOpr.Operation = DOMContentOperation.Remove;
			_contentOpr.ContentType = DOMContentType.InnerHTML;

			await _core.ModifyElementContent(_contentOpr);
		}

		public async ValueTask<T> GetValue<T>()
		{
			return await _core.ElementGetValue<T>(DOMElementBy.Id, _id, _globalShowLog);
		}

		public async Task SetValue(object value)
		{
			await _core.ElementSetValue(DOMElementBy.Id, _id, value, _globalShowLog);
		}
	}
}