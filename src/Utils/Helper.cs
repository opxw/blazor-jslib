using FastEnumUtility;

namespace Opx.Blazor.JsLibDOM.Utils
{
	internal static class Helper
	{
		public static string fn(this FuncMap s)
		{
			return s.GetLabel();
		}
	}
}