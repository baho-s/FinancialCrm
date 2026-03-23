using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //IGenericDal'ı implement ettik ve method imzalarının içeriklerini burada doldurucaz.
        
        //GenericRepository<T> sınıfı bizden bir sınıf ister göndereceğimiz sınıf için,
        //(örn: GenericRepository<Bank> dediğimiz de) GenericRepository methodlarını o sınıf için kullanabiliriz.

        FinancialContext context = new FinancialContext();
        // DbContext'ten türeyen FinancialContext sınıfından bir nesne oluşturduk.
        // Bu nesne Entity Framework aracılığıyla veritabanındaki tablolara erişmemizi sağlar.

        private readonly DbSet<T> _object;
        //DbSet EntityFramework'te bir tabloyu temsil eder, <T> hangi entity gönderilirse onu temsil ediyor.
        //Bu nesne şu işi yapar: Hangi entity ile çalışıyorsak onun tablosunu tutar
        //readonly demek bu değişken sadece Constructor içerisinde atanabilir, sonradan değiştirilemez.(Buda güvenlik sağlar)


        public GenericRepository()
        {
            _object=context.Set<T>();
            //Constructor içerisinde _object nesnesine context.Set<T>() ataması yaptık bu şu anlama gelir;
            // context.Set<T>() Entity Framework'te generic olarak tabloya erişmemizi sağlar.
            // T hangi entity ise o entity'nin DbSet'ini döndürür.
            // Böylece GenericRepository içinde tüm tablolar için ortak CRUD işlemleri yazabiliriz.
        }

        

        public List<T> GetAll()
        {
            return _object.ToList();
            //T Gönderilen entity 
            //Product için → context.Products.ToList()
            //Category için → context.Categories.ToList()
            //Comment için → context.Comments.ToList()
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
            //Mesela Product göndermiş olalım, geri dönüş değeri Product olur.
            // T generic tipini temsil eder. Repository hangi entity ile kullanılıyorsa
            // o entity tipinde veri döndürür (Product, Comment, Category vb.).
            // Böylece tüm tablolar için ortak GetById metodu kullanılabilir.
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
