namespace Horizons.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Horizons.Data.Models;

    using static GCommon.ValidationConstants.Terrain;

    public class TerrainConfiguration : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .HasMany(t => t.Destinations)
                .WithOne(d => d.Terrain);
        }
    }
}
