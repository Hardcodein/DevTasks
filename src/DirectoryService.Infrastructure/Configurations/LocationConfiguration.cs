namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(l => l.Id)
            .HasName("pk_location");

        builder.Property(l => l.Id)
            .HasConversion(
                id => id.Value,
                value => LocationId.Create(value))
            .HasColumnName("id");

        builder.OwnsOne(l => l.Name, ownName =>
        {
            ownName.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired();

            ownName.HasIndex(n => n.Value)
                .IsUnique();
        });

        builder.OwnsOne(l => l.Address, ownAddress =>
        {

            ownAddress.Property(a => a.MailIndex)
                .HasColumnName("mail_index");

            ownAddress.Property(a => a.Country)
                .HasColumnName("country");

            ownAddress.Property(a => a.City)
                .HasColumnName("city");

            ownAddress.Property(a => a.District)
                .HasColumnName("district");

            ownAddress.Property(a => a.Street)
                .HasColumnName("street");

            ownAddress.Property(a => a.NumberofHouse)
                .HasColumnName("number_of_house");

            ownAddress.ToJson("address");

        });

        builder.OwnsOne(l => l.Timezone, ownTimezone =>
        {
            ownTimezone.Property(tz => tz.Ianacode)
                .HasColumnName("timezone")
                .IsRequired();
        });

        builder.Property(l => l.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(l => l.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}