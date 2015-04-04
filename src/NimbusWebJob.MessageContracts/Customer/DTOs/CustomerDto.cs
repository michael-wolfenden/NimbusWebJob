using System;

namespace NimbusWebJob.MessageContracts.Customer.Dtos
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string EmailAddress { get; set; } 
    }
}