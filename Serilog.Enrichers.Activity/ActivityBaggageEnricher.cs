namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class ActivityBaggageEnricher : ILogEventEnricher
    {
        public const string ActivityBaggagePropertyName = "ActivityBaggage";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityBaggagePropertyName, GetActivityBaggage()));
        }

        private static string? GetActivityBaggage()
        {
            return Activity.Current?.Baggage?.Aggregate(new StringBuilder(), (sb, i) => sb.Append(i).Append(';'), sb => sb.ToString());
        }
    }
}