namespace Opx.Blazor.JsLibDOM
{
	public class JsLibDOMPropBase : IDisposable
	{
		private JsLibDOMInteropCore _js;
		private JsLibDOMGlobalOptions _options;
		private bool disposedValue;

		public JsLibDOMPropBase(JsLibDOMInteropCore js, JsLibDOMGlobalOptions options)
		{
			_js = js;
			_options = options;
		}

		protected JsLibDOMInteropCore JS => _js;
		protected JsLibDOMGlobalOptions Options => _options;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~JsLibDOMPropBase()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		void IDisposable.Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}	
}