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
    public class EfBankProcessDal : GenericRepository<BankProcess>, IBankProcessDal
    {
        FinancialContext context=new FinancialContext();
        // GenericRepository sınıfından miras alıyoruz.
        // Böylece Insert, Update, Delete, GetAll, GetById gibi genel CRUD işlemlerini
        // tekrar yazmadan Bank entity'si için kullanabiliriz.

        // IBankDal interface'ini implement ediyoruz.
        // Bank tablosuna özel yazılmış metod imzaları bu interface içinde bulunur.
        // Bu metodların içerikleri ise burada (EfBankProcessDal sınıfında) doldurulur.

        //Ef' içerisindeki işlemlerimizide tamamladıktan sonra Business katmanına geçiyoruz.

        public List<ComingAndGoingTransferDto> GetIncomingOrOutgoingTransferDtos(string GelenOrGiden, int? count=null)// int? kullanmamızın sebebi bu parametrenin null olabilmesidir.
        {
            
            var query= context.BankProcesses.Where(x => x.ProcessType.StartsWith(GelenOrGiden)).OrderByDescending(x => x.ProcessDate).Select
                        (x => new ComingAndGoingTransferDto
                        {
                            Amount = x.Amount, 
                            Sender = x.Sender
                        });
            if(count.HasValue)
            {
                query=query.Take(count.Value);
            }
            return query.ToList();
        }

        public decimal GetLast30DaysTotalAmount(string GelenOrGiden)
        {
            DateTime date = DateTime.Now.AddDays(-30);
            
            return context.BankProcesses.Where(x=>x.ProcessType.StartsWith(GelenOrGiden) && x.ProcessDate>=date).
                Sum(x=>(decimal?)x.Amount)??0;// (decimal?) kullanmamızın sebebi: Hiç kayıt gelmezse Sum() sonucu null olabilir.
                                              // ?? 0 ise "null gelirse 0 döndür" anlamına gelir.
                                              // Yani son 30 günde hiç işlem yoksa toplam 0 olarak döner.
        }
    }
}
