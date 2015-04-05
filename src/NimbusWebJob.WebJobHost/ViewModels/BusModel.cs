using System.Collections.Generic;

namespace NimbusWebJob.WebJobHost.ViewModels
{
    public class BusModel
    {
        public List<QueueModel> Queues { get; set; }
        public List<TopicModel> Topics { get; set; } 
    }
}