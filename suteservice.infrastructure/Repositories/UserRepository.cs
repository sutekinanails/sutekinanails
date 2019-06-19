using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using suteservice.domain.AggregatesModel.UserAgregate;
using suteservice.domain.SeedWork;

namespace suteservice.infrastructure.Repositories
{
    public class UserRepository : baseRepository, IUserRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, User registrationIn)
        {
            throw new NotImplementedException();
        }
    }
}
