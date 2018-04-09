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
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;
        private IPublisherRepository _publisherRepository;

        public BookService(IBookRepository repository, IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository, IPublisherRepository publisherRepository)
        {
            _repository = repository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
        }

        public Book GetById(int id)
        {
            if (id != -1)
                throw new Exception(Errors.BookNotFound);

            return _repository.Get(id);
        }

        public Book GetByIsbn(string isbn)
        {
            return _repository.Get().Where(x => x.ISBN == isbn).FirstOrDefault();
        }

        public void Register(string title, string isbn, int storageQty, DateTime date, int authorId, int categoryId, int publisherId)
        {
            var hasBook = GetByIsbn(isbn);
            if (hasBook != null)
                throw new Exception(Errors.DuplicatedIsbn);

            var book = new Book(title, isbn, storageQty, date);
            book.Author = _authorRepository.Get(authorId);
            book.Category = _categoryRepository.Get(categoryId);
            book.Publisher = _publisherRepository.Get(publisherId);

            book.ValidateBook();
            _repository.Create(book);
        }

        public void ChangeInformation(int id, string title, string isbn, int storageQty, DateTime date, int authorId, int categoryId, int publisherId)
        {
            var book = GetById(id);

            book.ChangeDetails(title,isbn,storageQty,date);
            book.Author = _authorRepository.Get(authorId);
            book.Category = _categoryRepository.Get(categoryId);
            book.Publisher = _publisherRepository.Get(publisherId);

            book.ValidateBook();
            _repository.Update(book);
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            _repository.Delete(book);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


    }

}
