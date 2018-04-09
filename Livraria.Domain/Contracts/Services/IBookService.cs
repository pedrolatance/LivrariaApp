using Livraria.Domain.Models;
using System;

namespace Livraria.Domain.Contracts.Services
{
    public interface IBookService : IDisposable
    {
        Book GetById(int id);
        Book GetByIsbn(string isbn);
        void Register(string title, string isbn, int storageQty, DateTime date, int authorId, int categoryId, int publisherId);
        void ChangeInformation(int id, string title, string isbn, int storageQty,DateTime date, int authorId, int categoryId, int publisherId);
        void Delete(int id);
    }
}
