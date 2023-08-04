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
    public class IEmployeeManager : IEmployeeService
    {
        private readonly IEmplooyeDal _employeeDal;

        public IEmployeeManager(IEmplooyeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void TDelete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee TGetByID(string id)
        {
            return _employeeDal.GetByID(id);
        }

        public List<Employee> TGetList()
        {
            return _employeeDal.GetList();
        }

        public void TInsert(Employee t)
        {
            t.Id = ObjectId.GenerateNewId().ToString();
            _employeeDal.Insert(t);
        }

        public void TUpdate(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
