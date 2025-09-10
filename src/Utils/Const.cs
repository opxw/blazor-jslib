using FastEnumUtility;

namespace Opx.Blazor.JsLibDOM
{
	public enum FuncMap
	{
		[Label("fg0")]
		ConsoleLog = 0,

		[Label("fd0")]
		DocModifyAttribute,
		[Label("fd1")]
		DocAddJs,
		[Label("fd2")]
		DocAddCss,

		[Label("fh0")]
		HeadAddMeta,

		[Label("fb0")]
		BodyAddClass,
		[Label("fb1")]
		BodyAddClasses,
		[Label("fb2")]
		BodyRemoveClass,
		[Label("fb3")]
		BodyRemoveClasses,
		[Label("fb4")]
		BodyModifyAttribute,

		[Label("fe0")]
		ElementModifyClass,
		[Label("fe1")]
		ElementModifyClasses,
		[Label("fe2")]
		ElementModifyAttribute,
		[Label("fe3")]
		ElementModifyContent,
		[Label("fe4")]
		ElementGetValue,
		[Label("fe5")]
		ElementSetValue,

		[Label("fce0")]
		AttributeOfElementIdChanged
	}

	public enum ScriptLocation
	{
		Head = 0,
		Body
	}

	public enum DOMElementBy
	{
		Id = 0,
		Name,
		Class,
		Tag
	}

	public enum DOMClassOperation
	{
		Add = 0,
		Remove
	}

	public enum DOMAttributeOperation
	{
		Set = 0,
		Remove
	}

	public enum DOMContentOperation
	{
		Add = 0,
		Remove
	}

	public enum DOMContentType
	{
		Text = 0,
		InnerHTML
	}
}