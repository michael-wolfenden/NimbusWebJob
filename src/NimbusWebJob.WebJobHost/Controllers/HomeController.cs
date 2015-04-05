using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.ServiceBus;
using NimbusWebJob.WebJobHost.ConfigurationSettings;
using NimbusWebJob.WebJobHost.ViewModels;

namespace NimbusWebJob.WebJobHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceBusConnectionStringSetting _serviceBusConnectionString;

        public HomeController(ServiceBusConnectionStringSetting serviceBusConnectionString)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
        }

        public async Task<ActionResult> Index()
        {
            // see: https://github.com/GlobalX/SbManager/blob/master/src/SbManager/BusHelpers/BusMonitor.cs#L38
            var manager = NamespaceManager.CreateFromConnectionString(_serviceBusConnectionString);
            var model = new BusModel
            {
                Queues = (await manager.GetQueuesAsync()).Select(e => new QueueModel
                {
                    ActiveMessageCount = e.MessageCountDetails.ActiveMessageCount,
                    DeadLetterCount = e.MessageCountDetails.DeadLetterMessageCount,
                    Name = e.Path
                }).ToList(),

                Topics = (await manager.GetTopicsAsync()).Select(e => new TopicModel
                {
                    Name = e.Path
                }).ToList()
            };

            foreach (var topic in model.Topics)
            {
                topic.Subscriptions = manager.GetSubscriptions(topic.Name).Select(e => new SubscriptionModel
                {
                    Name = e.Name,
                    ActiveMessageCount = e.MessageCountDetails.ActiveMessageCount,
                    DeadLetterCount = e.MessageCountDetails.DeadLetterMessageCount
                }).ToList();

                topic.ActiveMessageCount = topic.Subscriptions.Sum(s => s.ActiveMessageCount);
                topic.DeadLetterCount = topic.Subscriptions.Sum(s => s.DeadLetterCount);
            }

            return View(model);
        }
    }
}