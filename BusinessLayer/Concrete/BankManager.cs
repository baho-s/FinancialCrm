using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BankManager : IBankService
    {
        // BankManager Business katmanında yer alır.
        // DataAccess katmanındaki EfBankDal veritabanından veri çekme, ekleme,
        // silme gibi işlemleri gerçekleştirir.
        // BankManager ise bu veriler üzerinde iş kurallarını ve mantıksal işlemleri uygular.
        // Yani DAL veriyi getirir, Business katmanı bu veriyi yönetir ve kontrol eder.
        //--------------------------------------------//
        
        private readonly IBankDal _bankDal;
        //------------------------------------//
        // Constructor üzerinden IBankDal bağımlılığı alıyoruz (Dependency Injection).
        // Böylece BankManager doğrudan EfBankDal'a bağlı olmaz, interface üzerinden çalışır.
        // Bu sayede kod daha esnek ve sürdürülebilir hale gelir.
        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }


        public void TDelete(Bank entity)
        {
            throw new NotImplementedException();
        }

        public List<Bank> TGetAll()
        {
            return _bankDal.GetAll();
        }

        public Bank TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bank> TGetDeletedList()
        {
            throw new NotImplementedException();
        }

        public decimal TGetTotalBalance()
        {
            return _bankDal.GetTotalBalance();
        }

        public void TInsert(Bank entity)
        {
            throw new NotImplementedException();
        }

        public void TUndoDelete(Bank entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Bank entity)
        {
            throw new NotImplementedException();
        }
    }
}
