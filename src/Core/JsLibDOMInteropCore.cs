using Microsoft.JSInterop;
using Opx.Blazor.JsLibDOM.Utils;

namespace Opx.Blazor.JsLibDOM
{
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

        async Task ModElementClassBy(DOMClassOperation opr, DOMElementBy el, string identifier, string className, bool showLog)
        {
            var v = await moduleTask.Value;
            var log = showLog ? FuncMap.ElementModifyClass.ToString() : null;
            await v.InvokeVoidAsync(FuncMap.ElementModifyClass.fn(), (int)opr, (int)el, identifier, className, log);
        }

		async Task ModElementClassesBy(DOMClassOperation opr, DOMElementBy el, string identifier, string[] classNames, bool showLog)
		{
			var v = await moduleTask.Value;
			var log = showLog ? FuncMap.ElementModifyClasses.ToString() : null;
			await v.InvokeVoidAsync(FuncMap.ElementModifyClasses.fn(), (int)opr, (int)el, identifier, classNames, log);
		}

        public async Task ModifyElementClass(JsLibDOMClassOperation opr)
        {
            if (opr.Identifier == null)
                return;

            var log = "";

            if (!string.IsNullOrWhiteSpace(opr.ClassName))
            {
                await ModElementClassBy(opr.Operation, opr.ElementBy, opr.Identifier, opr.ClassName, opr.ShowExecutionLog);
            }
            else
            {
				await ModElementClassesBy(opr.Operation, opr.ElementBy, opr.Identifier, opr.ClassNames, opr.ShowExecutionLog);
            }
        }

        public async Task ModifyElementAttribute(JsLibDOMAttributeOperation opr)
        {
            if (opr.Identifier == null)
                return;

			var log = opr.ShowExecutionLog ? FuncMap.ElementModifyAttribute.ToString() : null;
			var v = await moduleTask.Value;
            await v.InvokeVoidAsync(FuncMap.ElementModifyAttribute.fn(), (int)opr.Operation, (int)opr.ElementBy ,opr.Identifier, opr.Name, opr.Value, log);
        }

        public async Task ModifyElementContent(JsLibDOMContentOperation opr)
        {
            if (opr.Identifier == null)
                return;

            var log = opr.ShowExecutionLog ? FuncMap.ElementModifyContent.ToString() : null;
            var v = await moduleTask.Value;
            await v.InvokeVoidAsync(FuncMap.ElementModifyContent.fn(), (int)opr.Operation, (int)opr.ElementBy, opr.Identifier, (int)opr.ContentType,
                opr.Content, log);
        }

        public async ValueTask<T> ElementGetValue<T>(DOMElementBy elementBy, string identifier, bool showLog = false)
        {
            var result = default(T);

            var log = showLog ? FuncMap.ElementGetValue.ToString() : null;
			var v = await moduleTask.Value;
			return await v.InvokeAsync<T>(FuncMap.ElementGetValue.fn(), (int)elementBy, identifier, log);
		}

		public async Task ElementSetValue(DOMElementBy elementBy, string identifier, object value, bool showLog  = false)
		{
			var log = showLog ? FuncMap.ElementGetValue.ToString() : null;
			var v = await moduleTask.Value;
			await v.InvokeVoidAsync(FuncMap.ElementSetValue.fn(), (int)elementBy, identifier, value, log);
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
