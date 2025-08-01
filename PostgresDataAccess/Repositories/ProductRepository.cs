using System.Collections.Generic;
using System.Linq;
using Models;
using PostgresDataAccess.Repositories;

namespace PostgresDataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Product.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Product.Find(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}