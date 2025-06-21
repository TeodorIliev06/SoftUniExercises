namespace RecipeSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RecipeSharingPlatform.Data.Models;

    using static GCommon.ValidationConstants.Recipe;

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(r => r.Instructions)
                .IsRequired()
                .HasMaxLength(InstructionsMaxLength);

            builder
                .HasOne(r => r.Author)
                .WithMany()
                .IsRequired()
                .HasForeignKey(r => r.AuthorId);

            builder
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .IsRequired()
                .HasForeignKey(r => r.CategoryId);

            builder
                .Property(r => r.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
