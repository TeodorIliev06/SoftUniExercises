namespace RecipeSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RecipeSharingPlatform.Data.Models;

    using static GCommon.ValidationConstants.Category;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .HasMany(c => c.Recipes)
                .WithOne(r => r.Category);
        }
    }
}
