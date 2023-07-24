using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplicaiton : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplicaiton(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository=colleagueDiscountRepository;
        }

        public OprationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OprationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return operation.succedde();
        }


        public OprationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OprationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            colleagueDiscount.Edit(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return operation.succedde();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OprationResult Remove(long id)
        {
            var operation = new OprationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Restore(long id)
        {
            var operation = new OprationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return operation.succedde();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel) ;
        }
    }
}
