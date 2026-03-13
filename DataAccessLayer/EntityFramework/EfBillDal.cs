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

        public bool BillExists(string title, string period, decimal amount)
        {
            return context.Bills.Any(x =>
            
                x.BillTitle == title&&
                x.BillPeriod == period&&
                x.BillAmount == amount&&
                x.IsDeleted==false
            );
        }

        public List<BillListDto> GetActiveBillsDto()
        {
            return context.Bills.Where(b=>b.IsDeleted==false).Select(b => new BillListDto
            {
                BillId = b.BillId,
                BillAmount = b.BillAmount,
                BillPeriod = b.BillPeriod,
                BillTitle = b.BillTitle
            }).ToList();
        }

        public List<BillDashboardDto> GetBillTitleAmountListDto()
        {
            return context.Bills.Select(x => new BillDashboardDto
            {
                BillTitle = x.BillTitle,
                BillAmount = x.BillAmount
            }).ToList();
        }

        public List<BillListDto> GetDeletedBillsDto()
        {
            return context.Bills.Where(b => b.IsDeleted == true).Select(b => new BillListDto
            {
                BillId = b.BillId,
                BillAmount = b.BillAmount,
                BillPeriod = b.BillPeriod,
                BillTitle = b.BillTitle
            }).ToList();
        }
    }
}
