using Livraria.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Infraestructure.Data.Map
{
    public class PublisherMap : EntityTypeConfiguration<Publisher>
    {
        public PublisherMap()
        {
            ToTable("publisher");

            Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            
        }
    }
}
