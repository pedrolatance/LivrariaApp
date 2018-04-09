using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        List<Category> Get();
        Category Get(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
