
using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        /*private readonly IAuthHelper _authHelper;*/
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OprationResult Create(CreateInventory command)
        {
            var operation = new OprationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Edit(EditInventory command)
        {
            var operation = new OprationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            /*inventory.Edit(command.ProductId, command.UnitPrice);*/
            _inventoryRepository.SaveChanges();
            return operation.succedde();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

      /*  public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }*/

        public OprationResult Increase(IncreaseInventory command)
        {
            var operation = new OprationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound );

            const long operatorId = 1;
            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Reduce(DecreaseInventory command)
        {
            var operation = new OprationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
           /* var operatorId = _authHelper.CurrentAccountId();*/
            inventory.Reduce(command.Count, 0, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Reduce(List<DecreaseInventory> command)
        {
            var operation = new OprationResult();
           /* var operatorId = _authHelper.CurrentAccountId();*/
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, 0, item.Description, item.OrderId);
            }

            _inventoryRepository.SaveChanges();
            return operation.succedde();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Serach(searchModel);
        }
    }
}