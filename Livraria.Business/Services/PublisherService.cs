using Livraria.Common.Resources;
using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Contracts.Services;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Business.Services
{
    public class PublisherService : IPublisherService
    {
        #region Dependancy Injection
        private IPublisherRepository _repository;

        public PublisherService(IPublisherRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Methods
        public List<Publisher> GetAll()
        {
            return _repository.Get();
        }

        public Publisher GetById(int id)
        {
            if (id <= 0)
                throw new Exception(Errors.PublisherNotFound);

            return _repository.Get(id); 
        }

        public Publisher GetByName(string name)
        {
            return _repository.Get().Where(x => x.Name == name).FirstOrDefault();
        }

        public void Register(string name)
        {
            var hasPublisher = GetByName(name);
            if (hasPublisher != null)
                throw new Exception(Errors.DuplicatedName);

            var publisher = new Publisher(name);
            _repository.Create(publisher);
        }

        public void ChangeInformation(int id, string name)
        {
            var publisher = GetById(id);
            var hasPublisher = GetByName(name);
            if (hasPublisher != null)
                throw new Exception(Errors.DuplicatedName);


            publisher.ChangeName(name);
            publisher.ValidatePublisher();

            _repository.Update(publisher); ;
        }

        public void Delete(int id)
        {
            var publisher = GetById(id);
            _repository.Delete(publisher);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        #endregion
    }
}
