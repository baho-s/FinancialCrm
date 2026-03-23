using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBillDal : GenericRepository<Bill>, IBillDal
    {
        FinancialContext context=new FinancialContext();
        public List<BillDto> GetBillDtoList()
        {
            return context.Bills.Select(x => new BillDto
            {
                BillTitle = x.BillTitle,
                BillAmount = x.BillAmount
            }).ToList();
        }
    }
}
