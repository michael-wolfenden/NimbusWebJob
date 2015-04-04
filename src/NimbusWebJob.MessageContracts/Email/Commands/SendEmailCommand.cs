using Nimbus.MessageContracts;

namespace NimbusWebJob.MessageContracts.Email.Commands
{
    public class SendEmailCommand : IBusCommand
    {
        public string EmailAddress { get; set; }

        protected SendEmailCommand()
        {
        }

        public SendEmailCommand(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}