using Dtos;
using PostgresDataAccess.Models;
using PostgresDataAccess.Repositories;

namespace Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<OrderDto> GetAll()
        {
            return _repo.GetAll().Select(o => new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                ProductId = o.ProductId,
                Quantity = o.Quantity
            });
        }

        public OrderDto GetById(int id)
        {
            var o = _repo.GetById(id);
            return new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                ProductId = o.ProductId,
                Quantity = o.Quantity
            };
        }

        public void Add(OrderDto dto)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
            _repo.Add(order);
        }

        public void Update(OrderDto dto)
        {
            var order = new Order
            {
                Id = dto.Id,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
            _repo.Update(order);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}