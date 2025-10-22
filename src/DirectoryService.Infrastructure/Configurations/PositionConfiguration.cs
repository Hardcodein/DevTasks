namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PositionId.Create(value)
            ).IsRequired();

        builder.OwnsOne(p => p.Name, ownName =>
        {
            ownName.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired();
            ownName.HasIndex(n => n.Value).IsUnique();
        });

        builder.OwnsOne(p => p.Description, ownDescription =>
        {
            ownDescription.Property(n => n.Value)
                .HasColumnName("description")
                .IsRequired(false);
        });

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}