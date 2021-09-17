namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;

    public class ActivityParentIdEnricher : ILogEventEnricher
    {
        public const string ActivityParentIdPropertyName = "ActivityParentId";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityParentIdPropertyName, GetActivityParentId()));
        }

        private static string? GetActivityParentId()
        {
            return Activity.Current?.ParentId;
        }
    }
}