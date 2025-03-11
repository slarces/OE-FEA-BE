using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Flag_Explorer_App.Domain.Entities.Base;

namespace Flag_Explorer_App.Infrastructure.Builders
{
    public class AbstractModelBuilder<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name, "public");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("timestamp with time zone")
                .IsRequired(true);

            builder.Property(p => p.DateModified)
                .HasColumnName("DateModified")
                .HasColumnType("timestamp with time zone")
                .IsRequired(true);

            builder.Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("boolean")
                .IsRequired(true);

        }
    }
}
