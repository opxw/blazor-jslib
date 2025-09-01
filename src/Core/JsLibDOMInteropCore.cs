using Microsoft.JSInterop;

namespace Opx.Blazor.JsLibDOM
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class JsLibDOMInteropCore : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsLibDOMInteropCore(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Opx.Blazor.JsLibDOM/blazor-jslib.min.js").AsTask());
        }

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }

        async Task ModifyClassBy(DOMClassOperation opr, DOMElementBy el, string identifier, string className, bool showLog)
        {
            var v = await moduleTask.Value;
            await v.InvokeVoidAsync("modClassBy", (int)opr, (int)el, identifier, className, showLog);
        }

		async Task ModifyClassesBy(DOMClassOperation opr, DOMElementBy el, string identifier, string[] classNames, bool showLog)
		{
			var v = await moduleTask.Value;
			await v.InvokeVoidAsync("modClassesBy", (int)opr, (int)el, identifier, classNames, showLog);
		}

        public async Task ModifyClass(JsLibDOMClassOperation opr)
        {
            if (opr.Identifier == null)
                return;

            if (!string.IsNullOrWhiteSpace(opr.ClassName))
                await ModifyClassBy(opr.Operation, opr.ElementBy, opr.Identifier, opr.ClassName, opr.ShowConsoleLog);
            else
                await ModifyClassesBy(opr.Operation, opr.ElementBy, opr.Identifier, opr.ClassNames, opr.ShowConsoleLog);
        }

        public async Task ModifyAttribute(JsLibDOMAttributeOperation opr)
        {
            if (opr.Identifier == null)
                return;

            var v = await moduleTask.Value;
            await v.InvokeVoidAsync("modAttributeBy", opr.ElementBy, opr.Identifier, opr.Name, opr.Value, opr.ShowConsoleLog);
        }

		public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public Lazy<Task<IJSObjectReference>> Task => moduleTask;
        
        public async Task<IJSObjectReference> GetInvoker()
        {
            return await moduleTask.Value;
        }
	}
}
