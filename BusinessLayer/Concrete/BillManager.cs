using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BillManager : IBillService
    {
        private readonly IBillDal _billDal;

        public BillManager(IBillDal billDal)
        {
            _billDal = billDal;
        }

        public void TDelete(Bill entity)
        {
            _billDal.Delete(entity);
        }

        public List<Bill> TGetAll()
        {
            return _billDal.GetAll();
        }

        public List<BillListDto> TGetActiveBillsDto()
        {
            return _billDal.GetActiveBillsDto();
        }

        public List<BillDashboardDto> TGetBillTitleAmountListDto()
        {
            return _billDal.GetBillTitleAmountListDto();
        }

        public Bill TGetById(int id)
        {
            return _billDal.GetById(id);
        }

        

        public void TInsert(Bill entity)
        {
            bool isExists = _billDal.BillExists(entity.BillTitle, entity.BillPeriod, entity.BillAmount);
            if (isExists)
            {
                throw new Exception("Aynı fatura zaten kayıtlı.");
            }
            _billDal.Insert(entity);
        }

        public void TUndoDelete(Bill entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Bill entity)
        {
            _billDal.Update(entity);
        }

        public List<BillListDto> TGetDeletedBillsDto()
        {
            return _billDal.GetDeletedBillsDto();
        }
    }
}
