﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public SelectList Products { get; set; }
    }
}
