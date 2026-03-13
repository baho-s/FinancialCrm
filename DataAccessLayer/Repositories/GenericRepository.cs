using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Abstract;
using EntityLayer.Dto;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
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
            return _object.Where(x=>x.IsDeleted==false).ToList();
            //T Gönderilen entity 
            //Product için → context.Products.ToList()
            //Category için → context.Categories.ToList()
            //Comment için → context.Comments.ToList()
        }

        public T GetById(int id)
        {
            return (T)_object.Find(id);
            //Mesela Product göndermiş olalım, geri dönüş değeri Product olur.
            // T generic tipini temsil eder. Repository hangi entity ile kullanılıyorsa
            // o entity tipinde veri döndürür (Product, Comment, Category vb.).
            // Böylece tüm tablolar için ortak GetById metodu kullanılabilir.
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);//Eklenecek veriyi hafızaya çektik. addedEntity içine
            addedEntity.State = EntityState.Added;//Burada veriyi EntityState.Added ile gelen veriyi ekledik.
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            // Entity Framework'te entity'nin durumunu (State) kontrol etmek ve değiştirmek için kullanılır.
            // EntityState ile entity'nin veritabanında ekleneceği, güncelleneceği veya silineceği belirlenir.
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Delete methodu direkt veritabanından silme yapmaz,
        //IsDeleted'i true yapar ver listelerken buna bakarak listeleriz.
        //Bunun amacı silinen değerleri geri getirmektir.
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate= DateTime.Now;
            context.SaveChanges();
        }

        //Silinen değerleri geri getirmek için methodumuz.
        public void UndoDelete(T entity)
        {
            entity.IsDeleted=false;
            entity.DeletedDate = null;
            context.SaveChanges();
        }

        
        
    }
}
