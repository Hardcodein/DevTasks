using DevTasks.Domain.Department.Relations.VO.DepartmentPosition;

namespace DevTasks.Infrastructure.Configurations.Relations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("departments_positions");
        
        builder.HasKey(x => x.Id)
            .HasName("pk_departments_positions");
        
        builder.Property(x => x.Id)
            .HasConversion(
                i=>i.Value,
                value => DepartmentPositionId.Create(value))
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(dl=>dl.DepartmentId)
            .HasConversion(
                i=>i.Value,
                value => DepartmentId.Create(value))
            .HasColumnName("department_id")
            .IsRequired();

        builder.Property(dp => dp.PositionId)
            .HasConversion(
                i => i.Value,
                value => PositionId.Create(value))
            .HasColumnName("location_id")
            .IsRequired();
        
        builder.HasOne<Department>()
            .WithMany(d=>d.Positions)
            .HasForeignKey(d=>d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasOne<Position>()
            .WithMany(p=>p.Departments)
            .HasForeignKey(d=>d.PositionId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}