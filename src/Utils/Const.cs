namespace Opx.Blazor.JsLibDOM
{
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
}