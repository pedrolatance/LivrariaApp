using Livraria.Business.Services;
using Livraria.Domain.Contracts.Repositories;
using Livraria.Domain.Contracts.Services;
using Livraria.Infraestructure.Data;
using Livraria.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Livraria.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<LivrariaDataContext, LivrariaDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookService, BookService>(new HierarchicalLifetimeManager());

            container.RegisterType<IAuthorRepository, AuthorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthorService, AuthorService>(new HierarchicalLifetimeManager());

            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoyService, CategoryService>(new HierarchicalLifetimeManager());

            container.RegisterType<IPublisherRepository, PublisherRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPublisherService, PublisherService>(new HierarchicalLifetimeManager());
        }
    }
}
