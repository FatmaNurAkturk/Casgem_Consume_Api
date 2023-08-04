using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class IUserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public IUserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public User TGetByID(string id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TInsert(User t)
        {
            t.Id = ObjectId.GenerateNewId().ToString();
            _userDal.Insert(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
