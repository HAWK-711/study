using Dtos;
using PostgresDataAccess.Models;
using PostgresDataAccess.Repositories;

namespace Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return _repo.GetAll().Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty,
                Email = c.Email ?? string.Empty
            });
        }

        public CustomerDto GetById(int id)
        {
            var c = _repo.GetById(id);
            return new CustomerDto
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty,
                Email = c.Email ?? string.Empty
            };
        }

        public void Add(CustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email
            };
            _repo.Add(customer);
        }

        public void Update(CustomerDto dto)
        {
            var customer = new Customer
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };
            _repo.Update(customer);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}