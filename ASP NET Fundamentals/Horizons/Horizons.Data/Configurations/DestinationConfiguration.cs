namespace Horizons.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Horizons.Data.Models;

    using static GCommon.ValidationConstants.Destination;

    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .HasOne(d => d.Publisher)
                .WithMany()
                .IsRequired()
                .HasForeignKey(d => d.PublisherId);

            builder
                .HasOne(d => d.Terrain)
                .WithMany(t => t.Destinations)
                .IsRequired()
                .HasForeignKey(d => d.TerrainId);

            builder
                .Property(d => d.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
