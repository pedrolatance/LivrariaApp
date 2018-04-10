using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Services
{
    public interface IBookService : IDisposable
    {
        List<Book> GetAll();
        Book GetById(int id);
        Book GetByIsbn(string isbn);
        void Register(string title, string isbn, int storageQty, int authorId, int categoryId, int publisherId);
        void ChangeInformation(int id, string title, string isbn, int storageQty, int authorId, int categoryId, int publisherId);
        void Delete(int id);
    }
}
