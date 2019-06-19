using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using suteservice.domain.SeedWork;

namespace suteservice.domain.AggregatesModel.UserAgregate {
    public interface IUserRepository : IRepository<User> { 
        List<User> Get ();
        Task<List<User>> GetAsync ();
        User Get (string id);
        Task<User> GetAsync (string id);
        void Update (string id, User registrationIn);
        void Remove (string id);
        void Remove (User entity);
        User Create (User entity);
        Task<User> CreateAsync (User entity);
    }
}