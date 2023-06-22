﻿using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IPorductApplication
    {
        OprationResult Create(CreateProduct command);
        OprationResult Edit(EditProduct command);
        OprationResult InStock(long id);
        OprationResult NotInStock(long Id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
