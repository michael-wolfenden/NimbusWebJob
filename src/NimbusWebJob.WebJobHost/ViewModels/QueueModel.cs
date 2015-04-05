namespace NimbusWebJob.WebJobHost.ViewModels
{
    public class QueueModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterCount { get; set; }
    }
}