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
    public class SpendingManager : ISpendingService
    {
        private readonly ISpendingDal _spendingDal;

        public SpendingManager(ISpendingDal spendingDal)
        {
            _spendingDal = spendingDal;
        }

        public void TDelete(Spending entity)
        {
            throw new NotImplementedException();
        }

        public List<Spending> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Spending TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategorySpendingDto> TGetCategorySpendingDtos()
        {
            return _spendingDal.GetCategorySpendingDtos();
        }

        public List<Spending> TGetDeletedList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Spending entity)
        {
            throw new NotImplementedException();
        }

        public void TUndoDelete(Spending entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Spending entity)
        {
            throw new NotImplementedException();
        }
    }
}
