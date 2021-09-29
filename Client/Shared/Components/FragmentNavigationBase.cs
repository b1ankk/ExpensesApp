using System;
using System.Threading.Tasks;
using ExpensesApp.Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace ExpensesApp.Client.Shared.Components
{
    public class FragmentNavigationBase : ComponentBase, IDisposable
    {
        [Inject] NavigationManager NavManager { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }

        protected override void OnInitialized()
        {
            NavManager.LocationChanged += TryFragmentNavigation;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await NavManager.NavigateToFragmentAsync(JsRuntime);
        }

        private async void TryFragmentNavigation(object sender, LocationChangedEventArgs args)
        {
            await NavManager.NavigateToFragmentAsync(JsRuntime);
        }

    public void Dispose()
        {
            NavManager.LocationChanged -= TryFragmentNavigation;
        }
    }
}
