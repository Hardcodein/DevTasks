namespace DirectoryService.Infrastructure.Configurations.Relations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("departments_locations");

        builder.HasKey(x => x.Id)
            .HasName("pk_departments_locations");

        builder.Property(dl => dl.Id)
            .HasConversion(
                i => i.Value,
                value => DepartmentLocationId.Create(value))
            .HasColumnName("id")
            .IsRequired();

        builder.Property(dl => dl.DepartmentId)
            .HasConversion(
                i => i.Value,
                value => DepartmentId.Create(value))
            .HasColumnName("department_id")
            .IsRequired();

        builder.Property(dl => dl.LocationId)
            .HasConversion(
                i => i.Value,
                value => LocationId.Create(value))
            .HasColumnName("location_id")
            .IsRequired();

        builder.HasOne<Department>()
            .WithMany(d => d.Locations)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne<Location>()
            .WithMany(l => l.Departments)
            .HasForeignKey(d => d.LocationId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}