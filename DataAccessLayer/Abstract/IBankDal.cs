using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBankDal:IGenericDal<Bank>
    {
        // IGenericDal arayüzünü Bank entity'si ile kullanıyoruz.
        // Böylece Insert, Delete, Update, GetAll, GetById gibi genel CRUD işlemleri
        // Bank tablosu için otomatik olarak kullanılabilir hale gelir.
        // Eğer Bank'a özel bir sorgu gerekiyorsa bu interface içine yeni metodlar eklenebilir.

        //Buradaki Interface'leri Ef'sınıflarına implement ediyoruz burada,
        //Burada imzalarımı oluşturduk Her sınıfın kendine özel method imzaları.
        //Ef içerisinde bu imzaların içeriklerini yazıcaz.-->Devamı EfBankProcessDal'içerisinde.

        decimal GetTotalBalance();

    }
}
