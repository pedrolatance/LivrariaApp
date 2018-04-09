using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Repositories
{
    public interface IPublisherRepository : IDisposable
    {
        List<Publisher> Get();
        Publisher Get(int id);
        void Create(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(Publisher publisher);
    }
}
