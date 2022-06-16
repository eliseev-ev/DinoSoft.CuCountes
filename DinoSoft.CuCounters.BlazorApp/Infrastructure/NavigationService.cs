using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    internal class NavigationService
    {
        private readonly NavigationManager navigationManager;

        public NavigationService(
            NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        /// <summary>
        /// Перенаправить на страницу.
        /// </summary>
        /// <param name="link"></param>
        public void NavigateTo(string link)
        {
            navigationManager.NavigateTo(Links.Service.NavigationPage(link));
        }
    }
}
