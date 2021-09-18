namespace Serilog.Enrichers
{
    using Serilog.Core;
    using Serilog.Events;
    using System.Diagnostics;

    public class ActivityOperationNameEnricher : ILogEventEnricher
    {
        public const string ActivityOperationNamePropertyName = "ActivityOperationName";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ActivityOperationNamePropertyName, GetActivityOperationName()));
        }

        private static string GetActivityOperationName()
        {
            return Activity.Current?.OperationName;
        }
    }
}