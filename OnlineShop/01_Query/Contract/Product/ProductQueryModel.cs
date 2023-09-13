﻿using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Comment;

namespace _01_Query.Contract.Product
{
    public class ProductQueryModel
    {
            public long Id { get; set; }
            public string Picture { get; set; }
            public string PictureAlt { get; set; }
            public string PictureTitle { get; set; }
            public string Name { get; set; }
            public double DoublePrice { get; set; }
            public string Price { get; set; }
            public string PriceWithDiscount { get; set; }
            public int DiscountRate { get; set; }
            public string Category { get; set; }
            public string CategorySlug { get; set; }
            public bool HasDiscount { get; set; }
            public string DiscountExpireDate { get; set; }
            public string Code { get; set; }
            public string ShortDescription { get; set; }
            public string Slug { get; set; }
            public string Description { get; set; }
            public string Keywords { get; set; }
            public string MetaDescription { get; set; }
            public bool IsInStock { get; set; }
            public List<CommentQueryModel> Comments { get; set; }
            public List<ProductPictureQueryModel> Pictures { get; set; }
    }
    public class ProductPictureQueryModel
    {
        public long ProductId { get; set; }
        public ShopManagement.Domain.ProductAgg.Product Product { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
    }
}
