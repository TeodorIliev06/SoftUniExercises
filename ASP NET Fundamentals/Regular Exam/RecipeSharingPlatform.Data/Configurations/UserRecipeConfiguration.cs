namespace RecipeSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RecipeSharingPlatform.Data.Models;

    public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> builder)
        {
            builder
                .HasKey(ur => new { ur.RecipeId, ur.UserId });

            builder
                .HasOne(ur =>
                    ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ur =>
                    ur.Recipe)
                .WithMany(r => r.UsersRecipes)
                .HasForeignKey(ur => ur.RecipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(ur => ur.Recipe.IsDeleted == false);
        }
    }
}
