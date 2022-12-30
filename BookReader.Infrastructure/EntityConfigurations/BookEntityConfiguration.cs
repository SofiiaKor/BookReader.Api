using BookReader.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.EntityConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Author).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Year).IsRequired();
            builder.Property(t => t.Publisher);
            builder.Property(t => t.NumberOfPages);
        }
    }
}