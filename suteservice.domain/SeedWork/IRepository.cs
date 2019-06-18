using System;
using System.Collections.Generic;

namespace suteservice.domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot {
        //string ConnectionString { get; set; }
        //string DatabaseName { get; set; }
        //bool IsSSL { get; set; }

        IUnitOfWork UnitOfWork { get; }
    }
}
