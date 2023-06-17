﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x=>x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x=>x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.Picture).HasMaxLength(1000);
            builder.Property(x=>x.PictureAlt).HasMaxLength(225);
            builder.Property(x=>x.PictureTitle).HasMaxLength(500);
            builder.Property(x=>x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x=>x.Slug).HasMaxLength(500).IsRequired();

            builder.HasOne(x=>x.Category).WithMany(x=>x.products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
