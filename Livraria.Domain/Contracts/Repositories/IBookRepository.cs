using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Repositories
{
    public interface IBookRepository : IDisposable
    {
        List<Book> Get();
        Book Get(int id);
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
