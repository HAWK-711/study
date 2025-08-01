using System.Collections.Generic;
using System.Linq;
using Models;
using PostgresDataAccess.Repositories;

namespace PostgresDataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.AsNoTracking().ToList();
        }

        public Order GetById(int id)
        {
            return _context.Order.AsNoTracking().FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Order.Find(id);
            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}