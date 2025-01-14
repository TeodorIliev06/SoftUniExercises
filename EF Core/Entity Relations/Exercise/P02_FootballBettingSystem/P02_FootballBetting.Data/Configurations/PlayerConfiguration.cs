﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasOne(p => p.Town)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TownId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
