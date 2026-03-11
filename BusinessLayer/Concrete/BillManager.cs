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
            throw new NotImplementedException();
        }

        public List<Bill> TGetAll()
        {
            return _billDal.GetAll();
        }

        public List<BillDto> TGetBillDtoList()
        {
            return _billDal.GetBillDtoList();
        }

        public Bill TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Bill entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Bill entity)
        {
            throw new NotImplementedException();
        }
    }
}
