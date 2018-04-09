using Livraria.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Infraestructure.Data.Map
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("category");

            Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
