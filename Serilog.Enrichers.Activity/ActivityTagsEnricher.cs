namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class ActivityTagsEnricher : ILogEventEnricher
    {
        public const string ActivityTagsPropertyName = "ActivityTags";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityTagsPropertyName, GetActivityTags()));
        }

        private static string? GetActivityTags()
        {
            return Activity.Current?.Tags?.Aggregate(new StringBuilder(), (sb, i) => sb.Append(i).Append(';'), sb => sb.ToString());
        }
    }
}