using Dtos;
using PostgresDataAccess.Models;
using PostgresDataAccess.Repositories;

namespace Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _repo.GetAll().Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty
            });
        }

        public CategoryDto GetById(int id)
        {
            var c = _repo.GetById(id);
            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty
            };
        }

        public void Add(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };
            _repo.Add(category);
        }

        public void Update(CategoryDto dto)
        {
            var category = new Category
            {
                Id = dto.Id,
                Name = dto.Name
            };
            _repo.Update(category);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}