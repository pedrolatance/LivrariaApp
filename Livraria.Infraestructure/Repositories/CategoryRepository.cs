using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Models;
using Livraria.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private LivrariaDataContext _context;

        public CategoryRepository(LivrariaDataContext context)
        {
            this._context = context;
        }

        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Entry<Category>(category).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
