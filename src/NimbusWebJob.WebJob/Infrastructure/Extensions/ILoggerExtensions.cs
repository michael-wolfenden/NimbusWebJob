using Serilog;

namespace NimbusWebJob.WebJob.Infrastructure.Extensions
{
    public static class ILoggerExtensions
    {
        public static ILogger For(this ILogger logger, string propertyName, object value)
        {
            return logger.ForContext(propertyName, value, destructureObjects: true);
        }
    }
}