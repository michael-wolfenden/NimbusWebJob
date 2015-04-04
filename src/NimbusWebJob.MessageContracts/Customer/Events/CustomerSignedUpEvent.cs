using Nimbus.MessageContracts;
using NimbusWebJob.MessageContracts.Customer.Dtos;

namespace NimbusWebJob.MessageContracts.Customer.Events
{
    public class CustomerSignedUpEvent : IBusEvent
    {
        public CustomerDto Customer { get; set; }

        protected CustomerSignedUpEvent()
        {
        }

        public CustomerSignedUpEvent(CustomerDto customer)
        {
            Customer = customer;
        }
    }
}