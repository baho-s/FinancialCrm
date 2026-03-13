using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBankProcessService:IGenericService<BankProcess>
    {
        List<ComingAndGoingTransferDto> TGetIncomingOrOutgoingTransferDtos(string GelenOrGiden,int? count=null);
        decimal TGetLast30DaysTotalAmount(string GelenOrGiden);
    }
}
