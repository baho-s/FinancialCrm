using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBillService:IGenericService<Bill>
    {
        List<BillDashboardDto> TGetBillTitleAmountListDto();
        List<BillListDto> TGetActiveBillsDto();

        List<BillListDto> TGetDeletedBillsDto();
    }
}
