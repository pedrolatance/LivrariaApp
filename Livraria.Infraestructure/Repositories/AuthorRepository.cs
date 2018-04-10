using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Models;
using Livraria.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infraestructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private LivrariaDataContext _context;

        public AuthorRepository(LivrariaDataContext context)
        {
            this._context = context;
        }

        public List<Author> Get()
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _context.Authors
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Entry<Author>(author).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}
