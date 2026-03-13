using BusinessLayer.Abstract;
using FinancalCrm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        public void TDelete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> TGetAll()
        {
            throw new NotImplementedException();
        }

        public User TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> TGetDeletedList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(User entity)
        {
            throw new NotImplementedException();
        }

        public void TUndoDelete(User entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
