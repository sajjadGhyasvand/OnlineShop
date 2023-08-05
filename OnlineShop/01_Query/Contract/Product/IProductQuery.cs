﻿using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Query.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        ProductQueryModel GetProductDetails(string slug);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);

    }
}
