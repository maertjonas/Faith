using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Data.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(a => a.Id);
            builder.ToTable("post");
            builder.Property(p => p.Id)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Text");

        }
    }
}
