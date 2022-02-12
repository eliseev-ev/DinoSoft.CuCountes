using Microsoft.AspNetCore.Components;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    public static class Links
    {
        public static string Index => $"";

        public static string CounterGroupPage(Guid counterGroupId) => $"/counter-groups/{counterGroupId}";

        public static string CounterPage(Guid counterGroupId, Guid counterId) => $"{CounterGroupPage(counterGroupId)}/counters/{counterId}";

        public static string CounterEditPage(Guid counterGroupId, Guid counterId) => $"{CounterPage(counterGroupId, counterId)}/edit";
    }
}
