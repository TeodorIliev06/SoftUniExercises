﻿namespace Horizons.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Horizons.Data.Models;

    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> builder)
        {
            builder
                .HasKey(ud => new { ud.DestinationId, ud.UserId });

            builder
                .HasOne(ud => 
                    ud.User)
                .WithMany()
                .HasForeignKey(ud => ud.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ud =>
                    ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
