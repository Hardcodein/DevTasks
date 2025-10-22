namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(x => x.Id)
            .HasName("pk_departments");

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value))
            .HasColumnName("id");

        builder.OwnsOne(d => d.Name, ownName =>
        {
            ownName.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired();

            ownName.HasIndex(n => n.Value)
                .IsUnique();
        });

        builder.OwnsOne(d => d.Identifier, ownIdentifier =>
        {
            ownIdentifier.Property(n => n.Value)
                .HasColumnName("identifier")
                .HasMaxLength(Constants.MAX_LENGTH_DEP_INT)
                .IsRequired();
        });

        builder.OwnsOne(d => d.Path, ownPath =>
        {
            ownPath.Property(n => n.Value)
                .HasColumnName("path")
                .IsRequired();
        });

        builder.Property(d => d.Depth)
            .HasColumnName("depth")
            .IsRequired();

        builder.Property(d => d.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.HasOne(d => d.Parent)
            .WithMany(dp => dp.Children).HasForeignKey("fk_parent_departments")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}