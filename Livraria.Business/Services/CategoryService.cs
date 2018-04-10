using Livraria.Common.Resources;
using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Contracts.Services;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Business.Services
{
    public class CategoryService : ICategoyService
    {
        #region Dependancy Injection
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Methods
        public List<Category> GetAll()
        {
            return _repository.Get();
        }

        public Category GetById(int id)
        {
            if (id <= 0)
                throw new Exception(Errors.CategoryNotFound);

            return _repository.Get(id); ;
        }

        public Category GetByName(string name)
        {
            return _repository.Get().Where(x => x.Name == name).FirstOrDefault();
        }

        public void Register(string name)
        {
            var hasCategory = GetByName(name);
            if (hasCategory != null)
                throw new Exception(Errors.DuplicatedName);

            var category = new Category(name);
            _repository.Create(category);
        }

        public void ChangeInformation(int id, string name)
        {
            var category = GetById(id);
            var hasCategory = GetByName(name);
            if (hasCategory != null)
                throw new Exception(Errors.DuplicatedName);

            category.ChangeName(name);
            category.ValidateCategory();

            _repository.Update(category);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            _repository.Delete(category);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        #endregion
    }
}
