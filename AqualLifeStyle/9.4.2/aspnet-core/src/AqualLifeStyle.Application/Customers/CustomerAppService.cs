using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AqualLifeStyle.Application.Customers.Dto;
using AqualLifeStyle.Domain.Common;
using AqualLifeStyle.Domain.Customers;

namespace AqualLifeStyle.Application.Customers
{
    public class CustomerAppService : AqualLifeStyleAppServiceBase, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IReadOnlyList<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllListAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                EmailAddress = c.Email.Value,
                MembershipId = c.MembershipId,
                IsActive = c.IsActive
            }).ToList();
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                EmailAddress = customer.Email.Value,
                MembershipId = customer.MembershipId,
                IsActive = customer.IsActive
            };
        }

        public async Task CreateAsync(CreateCustomerDto input)
        {
            var email = new EmailAddress(input.EmailAddress);
            var customer = Customer.Create(input.Name, email, input.MembershipId);
            await _customerRepository.InsertAsync(customer);
        }
    }
}
