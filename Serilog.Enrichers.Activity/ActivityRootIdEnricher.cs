namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;

    public class ActivityRootIdEnricher : ILogEventEnricher
    {
        public const string ActivityRootIdPropertyName = "ActivityRootId";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityRootIdPropertyName, GetActivityRootId()));
        }

        private static string? GetActivityRootId()
        {
            return Activity.Current?.RootId;
        }
    }
}