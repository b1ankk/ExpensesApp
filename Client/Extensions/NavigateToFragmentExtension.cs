using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ExpensesApp.Client.Extensions
{
    public static class NavigateToFragmentExtension
    {
        public static ValueTask NavigateToFragmentAsync(this NavigationManager navigationManager, IJSRuntime jsRuntime) {
            Uri uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);

            if (uri.Fragment.Length == 0)
                return default;

            return jsRuntime.InvokeVoidAsync("scrollToFragment", uri.Fragment[1..]);
        }
    }
}
