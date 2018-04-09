using Livraria.Domain.Models;
using System;

namespace Livraria.Domain.Contracts.Services
{
    public interface ICategoyService : IDisposable
    {
        Category GetById(int id);
        void Register(string name);
        void ChangeInformation(int id);
        void Delete(int id);
    }
}
