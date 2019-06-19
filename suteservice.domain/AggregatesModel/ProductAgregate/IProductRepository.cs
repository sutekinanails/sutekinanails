using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using suteservice.domain.SeedWork;

namespace suteservice.domain.AggregatesModel.ProductAgregate
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> Get ();
        Task<List<Product>> GetAsync ();
        Product Get (string id);
        Task<Product> GetAsync (string id);
        void Update (string id, Product registrationIn);
        void Remove (string id);
        void Remove (Product entity);
        Product Create (Product entity);
        Task<Product> CreateAsync (Product entity);
    }
}
