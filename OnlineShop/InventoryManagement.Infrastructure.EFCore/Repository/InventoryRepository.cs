using _0_FrameWork.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext=inventoryContext;
            _shopContext=shopContext;
        }

        public Inventory GetBy(long ProductId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x=>x.ProductId == ProductId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x=>new EditInventory {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<InventoryViewModel> Serach(InventoryViewModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id,x.Name}).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel {
                Id=x.Id,
                UnitPrice=x.UnitPrice,
                InStock=x.InStock,
                ProductId=x.ProductId,
                CurrentCount=x.CalculateCurrentCount(),
            }) ;
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            if (searchModel.InStock)
                query = query.Where(x=> !x.InStock );
            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item => {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;});
            return inventory;
        }
    }
}
