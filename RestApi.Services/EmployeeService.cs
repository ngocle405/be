using RestApi.Data.Entities;
using RestApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        object GetById(int employeeId);
        void Add(Employee employee);
        void Update(int employeeId, Employee employee);
        void Delete(int employeeId);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReponsitory _employeeReponsitory;
        public EmployeeService(IEmployeeReponsitory employeeReponsitory)
        {
            _employeeReponsitory = employeeReponsitory;
        }
        public IEnumerable<Employee> GetAll()
        {
            return  _employeeReponsitory.GetAll();
        }
        public object GetById(int employeeId)
        {
           return _employeeReponsitory.GetById(employeeId);
        }
        public void Add(Employee employee)
        {
            _employeeReponsitory.Add(employee);
            _employeeReponsitory.SaveChanges();
        }
        public void Update(int employeeId,Employee employee)
        {

            _employeeReponsitory.Update(employeeId, employee);
            _employeeReponsitory.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var tbl = _employeeReponsitory.GetById(employeeId);
            _employeeReponsitory.Delete(tbl);
            _employeeReponsitory.SaveChanges();
        }
    }
}
