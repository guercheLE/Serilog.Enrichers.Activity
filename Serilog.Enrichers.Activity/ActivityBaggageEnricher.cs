namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class ActivityBaggageEnricher : ILogEventEnricher
    {
        public const string ActivityBaggagePropertyName = "ActivityBaggage";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityBaggagePropertyName, GetActivityBaggage()));
        }

        private static IEnumerable<KeyValuePair<string, string>> GetActivityBaggage()
        {
            return Activity.Current?.Baggage;
        }
    }
}