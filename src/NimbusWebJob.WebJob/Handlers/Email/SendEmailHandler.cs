using System.Threading.Tasks;
using Nimbus.Handlers;
using NimbusWebJob.MessageContracts.Email.Commands;
using Serilog;

namespace NimbusWebJob.WebJob.Handlers.Email
{
    public class SendEmailHandler : IHandleCommand<SendEmailCommand>
    {
        private readonly ILogger _logger;

        public SendEmailHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(SendEmailCommand busCommand)
        {
            _logger.Information("<SendEmailHandler> Sending email to {EmailAddress}", busCommand.EmailAddress);

            return Task.FromResult(0);
        }
    }
}