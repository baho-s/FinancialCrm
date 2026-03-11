using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISpendingService:IGenericService<Spending>
    {
        List<CategorySpendingDto> TGetCategorySpendingDtos();
    }
}
