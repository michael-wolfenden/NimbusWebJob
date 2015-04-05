namespace NimbusWebJob.WebJobHost.ViewModels
{
    public class SubscriptionModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterCount { get; set; } 
    }
}