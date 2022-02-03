using Microsoft.AspNetCore.Components;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    /// <summary>
    /// Сервис для обновления состояний.
    /// Регистрируем событие по ключу,
    /// и по ключу можем запускать события.
    /// </summary>
    internal class RefreshService : IRefreshService
    {
        // Нужно как-то удалять экшены
        private Dictionary<int, List<Action>> actionHolder = new Dictionary<int, List<Action>>();

        public void Add(Type type, Action action)
        {
            var hash = type.GetHashCode();
            if (!actionHolder.TryGetValue(hash, out var actions))
            {
                actions = new List<Action>();
                actionHolder.Add(hash, actions);
            }

            actions.Add(action);
        }

        public void RequestRefresh(Type type)
        {
            var hash = type.GetHashCode();
            if (actionHolder.TryGetValue(hash, out var actions))
            {
                actions.ForEach(x => x.Invoke());
            }
        }
    }
}
