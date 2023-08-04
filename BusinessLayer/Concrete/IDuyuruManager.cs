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
    public class IDuyuruManager : IDuyuruService
    {
        private readonly IDuyuruDal _duyuruDal;

        public IDuyuruManager(IDuyuruDal duyuruDal)
        {
            _duyuruDal = duyuruDal;
        }

        public void TDelete(Duyuru t)
        {
            _duyuruDal.Delete(t);
        }

        public Duyuru TGetByID(string id)
        {
            return _duyuruDal.GetByID(id);
        }

        public List<Duyuru> TGetList()
        {
            return _duyuruDal.GetList();
        }

        public void TInsert(Duyuru t)
        {
            t.Id = ObjectId.GenerateNewId().ToString();
            _duyuruDal.Insert(t);
        }

        public void TUpdate(Duyuru t)
        {
            _duyuruDal.Update(t);
        }
    }
}
