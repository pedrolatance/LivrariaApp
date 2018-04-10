using Livraria.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Infraestructure.Data.Map
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("book");

            Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.ISBN)
                .HasMaxLength(12)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_ISBN", 1) {IsUnique = true }))
                .IsRequired();

            Property(x => x.StorageQty)
                .IsRequired();

            HasRequired(x => x.Category);
            HasRequired(x => x.Publisher);
            HasRequired(x => x.Author);
        }
    }
}
