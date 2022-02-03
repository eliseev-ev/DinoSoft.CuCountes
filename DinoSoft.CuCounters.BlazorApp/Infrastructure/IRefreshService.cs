namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    internal interface IRefreshService
    {
        void Add(Type key, Action action);

        void RequestRefresh(Type key);
    }
}