using Livraria.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Infraestructure.Data.Map
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("author");

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
