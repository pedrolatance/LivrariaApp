using Livraria.Domain.Models;
using System;

namespace Livraria.Domain.Contracts.Services
{
    public interface IAuthorService : IDisposable
    {
        Author GetById(int id);
        Author GetByName(string name);
        void Register(string name);
        void ChangeInformation(int id, string name);
        void Delete(int id);
    }
}
