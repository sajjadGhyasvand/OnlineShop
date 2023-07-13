using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcontext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) : base(context)
        {
            _context=context;
            _shopcontext=shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return GetDetails(id, _context);
        }

        public EditCustomerDiscount GetDetails(long id, DiscountContext _context)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id=x.Id,
                DiscountRate=x.DiscountRate,
                EndDate=x.EndDate.ToString(),
                StartDate=x.StartDate.ToString(),
                ProductId=x.ProductId,
                Reason=x.Reason,
            }).FirstOrDefault(x => x.Id==id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopcontext.Products.Select(x => new {x.Id,x.Name}).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id=x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                ProductId = x.ProductId,
                Reason = x.Reason,
            });
            if (searchModel.PriductId > 0)
                query=query.Where(x => x.ProductId == searchModel.PriductId);
            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
                query=query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
                query=query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());


            var discounts = query.OrderByDescending(x=>x.Id).ToList();
            discounts.ForEach(discount => discount.Product  = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discounts;
        }
    }
}
