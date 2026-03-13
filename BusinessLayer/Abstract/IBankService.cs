using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBankService:IGenericService<Bank>
    {
        // IGenericService<Bank> ile Bank için ortak CRUD işlemlerini alıyoruz.
        // Business katmanında Bank'a özel iş kuralları veya işlemler bu interface'e eklenebilir.
        decimal TGetTotalBalance();
    }
}
