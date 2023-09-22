// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace Vitals.FoodType.API;

public class FoodTypeDbContext(DbContextOptions<FoodTypeDbContext> options) : DbContext(options)
{
    public DbSet<FoodType> FoodTypes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FoodType>(b =>
        {
            b.ToTable("food_types");

            b.HasKey(e => e.Id);

            b.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();
            
            b.Property(e => e.ProviderId)
                .HasColumnName("provider_id")
                .IsRequired();

            b.Property(e => e.Processed)
                .HasColumnName("processed")
                .IsRequired();

            b.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            b.Property(e => e.FoodTypes)
                .HasColumnName("food_types")
                .HasColumnType("jsonb")
                .IsRequired();

            b.HasIndex(e => new { e.ProviderId, e.Processed, e.CreatedAt })
                .HasDatabaseName("idx_food_types_provider_id_processed_created_at");
        });
    }
}

