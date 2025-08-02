using Dtos;
using PostgresDataAccess.Models;
using PostgresDataAccess.Repositories;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _repo.GetAll().Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
            });
        }

        public UserDto GetById(int id)
        {
            var u = _repo.GetById(id);
            return new UserDto
            {
                Id = u.Id,
                Name = u.Name,
            };
        }

        public void Add(UserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
            };
            _repo.Add(user);
        }

        public void Update(UserDto dto)
        {
            var user = new User
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            _repo.Update(user);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}