using Livraria.Domain.Models;
using Livraria.Infraestructure.Data.Map;
using System.Data.Entity;

namespace Livraria.Infraestructure.Data
{
    public class LivrariaDataContext : DbContext
    {
        public LivrariaDataContext()
            : base("AppConnectionStrings")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PublisherMap());

        }
    }
}
