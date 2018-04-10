using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Models;
using Livraria.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LivrariaDataContext _context;

        public BookRepository(LivrariaDataContext context)
        {
            this._context = context;
        }

        public List<Book> Get()
        {
            return _context.Books
                .Include("Author")
                .Include("Category")
                .Include("Publisher")
                .OrderBy(x => x.Title)
                .ToList();
        }

        public Book Get(int id)
        {
            return _context.Books
                .Include("Category")
                .Include("Author")
                .Include("Publisher")
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Book Get(string isbn)
        {
            return _context.Books
                .Include("Category")
                .Include("Author")
                .Include("Publisher")
                .Where(x => x.ISBN == isbn)
                .FirstOrDefault();
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Entry<Book>(book).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
