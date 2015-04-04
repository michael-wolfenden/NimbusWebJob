using Serilog;

namespace NimbusWebJob.Web.Infrastructure.Extensions
{
    public static class ILoggerExtensions
    {
        public static ILogger With(this ILogger logger, string propertyName, object value)
        {
            return logger.ForContext(propertyName, value, destructureObjects: true);
        }
    }
}