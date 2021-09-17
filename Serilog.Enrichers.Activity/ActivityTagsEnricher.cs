namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class ActivityTagsEnricher : ILogEventEnricher
    {
        public const string ActivityTagsPropertyName = "ActivityTags";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityTagsPropertyName, GetActivityTags()));
        }

        private static IEnumerable<KeyValuePair<string, string?>>? GetActivityTags()
        {
            return Activity.Current?.Tags;
        }
    }
}