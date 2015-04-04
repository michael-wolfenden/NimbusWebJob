using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using NimbusWebJob.MessageContracts.Customer.Events;
using NimbusWebJob.MessageContracts.Email.Commands;
using NimbusWebJob.WebJob.Infrastructure.Extensions;
using ILogger = Serilog.ILogger;

namespace NimbusWebJob.WebJob.Handlers.Customer.WhenACustomerSignsUp
{
    public class SendThemAWelcomeEmail : IHandleMulticastEvent<CustomerSignedUpEvent>
    {
        private readonly ILogger _logger;
        private readonly IBus _bus;

        public SendThemAWelcomeEmail(ILogger logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public Task Handle(CustomerSignedUpEvent @event)
        {
            _logger.For("Event", @event)
                   .Information("<SendThemAWelcomeEmail> Sending a welcome email to {CustomerId} at {EmailAddress}",
                       @event.Customer.CustomerId, @event.Customer.EmailAddress);

            return _bus.Send(new SendEmailCommand(@event.Customer.EmailAddress));
        }
    }
}