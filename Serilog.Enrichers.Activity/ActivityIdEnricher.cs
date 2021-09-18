namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;

    public class ActivityIdEnricher : ILogEventEnricher
    {
        public const string ActivityIdPropertyName = "ActivityId";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityIdPropertyName, GetActivityId()));
        }

        private static string GetActivityId()
        {
            return Activity.Current?.Id;
        }
    }
}