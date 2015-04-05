using System.Collections.Generic;

namespace NimbusWebJob.WebJobHost.ViewModels
{
    public class TopicModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterCount { get; set; }
        public List<SubscriptionModel> Subscriptions { get; set; }
    }
}