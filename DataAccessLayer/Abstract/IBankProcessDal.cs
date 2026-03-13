using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBankProcessDal:IGenericDal<BankProcess>
    {
        List<ComingAndGoingTransferDto> GetIncomingOrOutgoingTransferDtos(string GelenOrGiden, int? count=null);
        decimal GetLast30DaysTotalAmount(string GelenOrGiden);
    }
}
