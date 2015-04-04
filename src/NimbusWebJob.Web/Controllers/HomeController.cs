using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nimbus;
using NimbusWebJob.MessageContracts.Customer.Dtos;
using NimbusWebJob.MessageContracts.Customer.Events;
using NimbusWebJob.Web.Infrastructure.Extensions;
using NimbusWebJob.Web.Infrastructure.Mappers;
using NimbusWebJob.Web.ViewModels;
using ILogger = Serilog.ILogger;

namespace NimbusWebJob.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public HomeController(ILogger logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View(new IndexInputModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexInputModel model)
        {
            var customerDto = model.ToCustomerDto();

            _logger.With("Model", model)
                   .Information("{GivenName} {FamilyName} at {EmailAddress} is signing up with Id {CustomerId}",
                       model.GivenName, model.FamilyName, model.EmailAddress, customerDto.CustomerId
                );

            await _bus.Publish(new CustomerSignedUpEvent(customerDto));

            ViewBag.Message = "CustomerSignedUpEvent has been published.. Check the logs";

            return View(model);
        }
    }
}