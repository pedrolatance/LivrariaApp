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
    public class CategoryService : ICategoyService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            this._repository = repository;
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

    }
}
