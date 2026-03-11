using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBillDal:IGenericDal<Bill>
    {
        // Dashboard ekranında faturaların başlık ve tutar bilgilerini birlikte gösterebilmek için
        // Entity yerine DTO kullanıyoruz.
        //
        // Normalde veritabanından Bill entity'si gelir fakat UI katmanında
        // bütün alanlara ihtiyacımız yoktur. Bu nedenle sadece gerekli alanları
        // taşıyan bir DTO oluşturduk.
        //
        // Bu method, Bill tablosundaki verileri alıp BillDto tipine dönüştürerek
        // katmanlar arasında taşımayı sağlar.
        List<BillDto> GetBillDtoList();
        
    }
}
