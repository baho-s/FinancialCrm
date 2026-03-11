using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        //IGenericDal<T> where T:Class nedir?
        //Generic(Genel) işlemlerin imzası(method isimleri) burada tanımlanır.
        //IGeneriDal interfacesi GenericRepository<T> sınıfına implement edilir.
        //Devamı GenericRepository içerisinde.

        
        //Aynı zamanda IGenericDal<T> interfacesi IBankDal'a da implemnt edilir,
        //Çünkü IBankDal'da Bank sınıfı için yapılacak işlemler vardır ve o işlemler içerisinde,
        //Genel işlemlerde vardır tekrar yazmamak için IGenericDal'dan implement ederiz.
        //Devamı IBankDal içerisinde.

        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
