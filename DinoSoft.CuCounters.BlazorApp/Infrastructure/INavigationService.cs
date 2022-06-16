namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    internal interface INavigationService
    {
        /// <summary>
        /// Перенаправить на страницу.
        /// </summary>
        /// <param name="link"></param>
        void NavigateTo(string link);
    }
}