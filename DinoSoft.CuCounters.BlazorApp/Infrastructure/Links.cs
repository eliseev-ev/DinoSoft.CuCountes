using Microsoft.AspNetCore.Components;

namespace DinoSoft.CuCounters.BlazorApp.Infrastructure
{
    public static class Links
    {
        public static class Service
        {
            public static string NavigationPage(string pageRoute) => $"/navigation-proxy/{pageRoute}";
            public static string Index => $"";
        }

        public static string GroupPage(Guid groupId) => $"counter-groups/{groupId}";

        public static string CounterPage(Guid groupId, Guid counterId) => $"{GroupPage(groupId)}/counters/{counterId}";

        public static string CounterEditPage(Guid groupId, Guid counterId) => $"{CounterPage(groupId, counterId)}/edit";
    }
}
