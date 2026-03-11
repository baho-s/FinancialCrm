using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSpendingDal : GenericRepository<Spending>, ISpendingDal
    {
        FinancialContext context = new FinancialContext();


        // Spendings tablosundaki harcamaları CategoryId alanına göre grupluyoruz.
        // Her kategoriye ait harcamaları bir grup haline getiriyoruz.
        // Daha sonra her grup için:
        // - Kategorinin adını navigation property kullanarak alıyoruz.(Bir entity'nin başka bir entity’ye nesne üzerinden erişmesini sağlayan property.)
        // - O kategoriye ait tüm SpendingAmount değerlerini toplayarak toplam harcamayı hesaplıyoruz.
        // Sonuç olarak kategori adı ve toplam harcama bilgisini CategorySpendingDto
        // içerisine aktararak liste halinde döndürüyoruz.
        public List<CategorySpendingDto> GetCategorySpendingDtos()
        {
            return context.Spendings.GroupBy(x => x.CategoryId).Select(x => new CategorySpendingDto
            {
                CategoryName = x.FirstOrDefault().Category.CategoryName,// Navigation Property: Spending entity'sinden(x'gruplandığı için spending oluyor) Category nesnesine erişerek kategori adını alıyoruz.
                TotalSpendingAmount = x.Sum(y=>y.SpendingAmount)
            }).ToList();
        }
    }
}
