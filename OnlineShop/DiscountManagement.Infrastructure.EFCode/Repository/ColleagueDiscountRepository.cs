using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Application.Contracts.Product;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _ShopContext;

        public ColleagueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext=discountContext;
            _ShopContext=shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _discountContext.ColleagueDiscounts.Select(c => new EditColleagueDiscount 
            {
                Id = c.Id,
                DiscountRate = c.DiscountRate,
                ProductId = c.ProductId
            }).FirstOrDefault(c => c.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _ShopContext.Products.Select(p => new  { p.Id,p.Name}).ToList();
            var query = _discountContext.ColleagueDiscounts.Select(c => new ColleagueDiscountViewModel
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                DiscountRate = c.DiscountRate,
                ProductId = c.ProductId,
                IsRemoved = c.IsRemoved
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x=>x.ProductId == searchModel.ProductId);
            var discounts = query.OrderByDescending(x=>x.Id).ToList();
            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x=>x.Id == discount.ProductId)?.Name);
            return discounts;
        }
    }
}
