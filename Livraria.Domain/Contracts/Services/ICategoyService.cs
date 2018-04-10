using Livraria.Domain.Models;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Contracts.Services
{
    public interface ICategoyService : IDisposable
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        void Register(string name);
        void ChangeInformation(int id, string name);
        void Delete(int id);
    }
}
