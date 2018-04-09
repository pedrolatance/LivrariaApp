using Livraria.Domain.Contracts.Repositories;
using Livraria.Infraestructure.Data;
using Livraria.Infraestructure.Repositories;
using Unity;
using Unity.Lifetime;

namespace Livraria.Startup
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<LivrariaDataContext, LivrariaDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthorRepository, AuthorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPublisherRepository, PublisherRepository>(new HierarchicalLifetimeManager());



        }

    }
}
