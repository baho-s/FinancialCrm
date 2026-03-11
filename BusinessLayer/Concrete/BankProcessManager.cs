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
    public class BankProcessManager : IBankProcessService
    {
        private readonly IBankProcessDal _bankProcessDal;

        public BankProcessManager(IBankProcessDal bankProcessDal)
        {
            _bankProcessDal = bankProcessDal;
        }

        public void TDelete(BankProcess entity)
        {
            throw new NotImplementedException();
        }

        public List<BankProcess> TGetAll()
        {
            throw new NotImplementedException();
        }

        public BankProcess TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<IncomingTransferDto> TIncomingTransferAndAmount()
        {
            return _bankProcessDal.IncomingTransferAndAmount();
        }

        public void TInsert(BankProcess entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BankProcess entity)
        {
            throw new NotImplementedException();
        }
    }
}
