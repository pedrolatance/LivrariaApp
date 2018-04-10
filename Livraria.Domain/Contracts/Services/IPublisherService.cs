using Livraria.Domain.Models;
using System;

namespace Livraria.Domain.Contracts.Services
{
    public interface IPublisherService : IDisposable
    {
        Publisher GetById(int id);
        Publisher GetByName(string name);
        void Register(string name);
        void ChangeInformation(int id, string name);
        void Delete(int id);
    }
}
