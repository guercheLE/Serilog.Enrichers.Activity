namespace Serilog
{
    using Serilog.Configuration;
    using Serilog.Enrichers;
    using System;

    public static class ActivityLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithActivityId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityIdEnricher>();
        }

        public static LoggerConfiguration WithActivityParentId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityParentIdEnricher>();
        }

        public static LoggerConfiguration WithActivityRootId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityRootIdEnricher>();
        }

        public static LoggerConfiguration WithActivityOperationName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityOperationNameEnricher>();
        }

        public static LoggerConfiguration WithActivityTags(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityTagsEnricher>();
        }

        public static LoggerConfiguration WithActivityBaggage(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActivityBaggageEnricher>();
        }
    }
}