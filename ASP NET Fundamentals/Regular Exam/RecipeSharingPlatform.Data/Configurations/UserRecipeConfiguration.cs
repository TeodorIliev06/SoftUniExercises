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
                .HasKey(ur => new { ur.DestinationId, ur.UserId });

            builder
                .HasOne(ur =>
                    ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ur =>
                    ur.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ur => ur.DestinationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
