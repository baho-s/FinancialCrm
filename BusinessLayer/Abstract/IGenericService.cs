using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // Business katmanında kullanılan generic servis arayüzüdür.
        // DataAccess katmanındaki IGenericDal yapısına benzer şekilde
        // tüm entity'ler için ortak CRUD işlemlerinin tanımlanmasını sağlar.
        // Manager sınıfları bu interface'i implement ederek
        // DAL üzerinden veri işlemlerini gerçekleştirir.
        void TUpdate(T entity);
        void TDelete(T entity);
        void TInsert(T entity);
        void TUndoDelete(T entity);
        List<T> TGetAll();
        T TGetById(int id);
    }
}
