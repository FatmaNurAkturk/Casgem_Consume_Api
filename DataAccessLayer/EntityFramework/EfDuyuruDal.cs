using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfDuyuruDal : IDuyuruDal
    {
        private readonly IMongoCollection<Duyuru> _duyuru;

        public EfDuyuruDal()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CasgemEmlakApi");
            _duyuru = database.GetCollection<Duyuru>("Duyurus");
        }

        public void Delete(Duyuru t)
        {
            _duyuru.DeleteOne(x => x.Id == t.Id);
        }

        public Duyuru GetByID(string id)
        {
            return _duyuru.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Duyuru> GetList()
        {
            return _duyuru.Find(x => true).ToList();
        }

        public void Insert(Duyuru t)
        {
            _duyuru.InsertOne(t);
        }

        public void Update(Duyuru t)
        {
            _duyuru.ReplaceOne(x => x.Id == t.Id, t);
        }
    }
}
