using System.Threading;

namespace NimbusWebJob.WebJob.Infrastructure.Extensions
{
    public static class ManualResetEventExtensions
    {
        public static void BlockUntilOpened(this ManualResetEvent manualResetEvent)
        {
            manualResetEvent.WaitOne();
        }

        public static void Open(this ManualResetEvent manualResetEvent)
        {
            manualResetEvent.Set();
        }
    }
}