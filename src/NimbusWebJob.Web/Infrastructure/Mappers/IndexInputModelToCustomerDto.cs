using System;
using NimbusWebJob.MessageContracts.Customer.Dtos;
using NimbusWebJob.Web.ViewModels;

namespace NimbusWebJob.Web.Infrastructure.Mappers
{
    public static class IndexInputModelToCustomerDto
    {
        public static CustomerDto ToCustomerDto(this IndexInputModel model)
        {
            return new CustomerDto
            {
                EmailAddress = model.EmailAddress,
                FamilyName = model.FamilyName,
                GivenName = model.GivenName,
                CustomerId = Guid.NewGuid()
            };
        }
    }
}