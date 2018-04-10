using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Services
{
    public interface IAuthorService : IDisposable
    {
        List<Author> GetAll();
        Author GetById(int id);
        Author GetByName(string name);
        void Register(string name);
        void ChangeInformation(int id, string name);
        void Delete(int id);
    }
}
