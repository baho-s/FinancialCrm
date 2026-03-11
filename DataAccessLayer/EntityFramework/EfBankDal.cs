using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBankDal : GenericRepository<Bank>, IBankDal
    {
        FinancialContext context=new FinancialContext();
        
        //Bankaların bakiyelerinin toplam değerini gösteren method.
        public decimal GetTotalBalance()
        {
            return context.Banks.Sum(x=>x.BankBalance);
        }
    }
}
