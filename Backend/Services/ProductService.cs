using Dtos;
using PostgresDataAccess.Models;
using PostgresDataAccess.Repositories;

namespace Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _repo.GetAll().Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name ?? string.Empty,
                Price = p.Price
            });
        }

        public ProductDto GetById(int id)
        {
            var p = _repo.GetById(id);
            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name ?? string.Empty,
                Price = p.Price
            };
        }

        public void Add(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };
            _repo.Add(product);
        }

        public void Update(ProductDto dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
            _repo.Update(product);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}