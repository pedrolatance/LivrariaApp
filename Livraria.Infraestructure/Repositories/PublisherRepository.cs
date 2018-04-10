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
    public class PublisherRepository : IPublisherRepository
    {
        private LivrariaDataContext _context;

        public PublisherRepository(LivrariaDataContext context)
        {
            this._context = context;
        }

        public List<Publisher> Get()
        {
            return _context.Publishers.ToList();
        }

        public Publisher Get(int id)
        {
            return _context.Publishers.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            _context.Entry<Publisher>(publisher).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
