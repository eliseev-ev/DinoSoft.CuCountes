using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    internal class NavigationService : INavigationService
    {
        private readonly NavigationManager navigationManager;

        public NavigationService(
            NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public void NavigateTo(string link)
        {
            navigationManager.NavigateTo(Links.Service.NavigationPage(link));
        }
    }
}
