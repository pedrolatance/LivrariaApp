using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Repositories
{
    public interface IAuthorRepository : IDisposable
    {
        List<Author> Get();
        Author Get(int id);
        void Create(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
