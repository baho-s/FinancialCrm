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
        public List<IncomingTransferDto> IncomingTransferAndAmount()
        {
            return context.BankProcesses.Where(x => x.ProcessType.StartsWith("Gelen")).Select(x => new IncomingTransferDto
            {
                Amount = x.Amount,
                Sender = x.Sender
            }).ToList();
        }
    }
}
