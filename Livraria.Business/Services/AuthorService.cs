using Livraria.Common.Resources;
using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Contracts.Services;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Business.Services
{
    public class AuthorService : IAuthorService
    {
        #region Dependancy Injection
        private IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Methods
        public List<Author> GetAll()
        {
            return _repository.Get();
        }

        public Author GetById(int id)
        {
            if (id <= 0)
                throw new Exception(Errors.AuthorNotFound);

            return _repository.Get(id); ;
        }

        public Author GetByName(string name)
        {
            return _repository.Get().Where(x => x.Name == name).FirstOrDefault();
        }

        public void Register(string name)
        {
            var hasAuthor = GetByName(name);
            if (hasAuthor != null)
                throw new Exception(Errors.DuplicatedName);

            var author = new Author(name);
            _repository.Create(author);
        }

        public void ChangeInformation(int id, string name)
        {
            var author = GetById(id);
            var hasAuthor = GetByName(name);
            if (hasAuthor != null)
                throw new Exception(Errors.DuplicatedName);

            author.ChangeName(name);
            author.ValidateAuthor();

            _repository.Update(author);
        }

        public void Delete(int id)
        {
            var author = GetById(id);
            _repository.Delete(author);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        #endregion
    }
}
