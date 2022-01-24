
using RestApi.Data.Entities;
using RestApi.Data.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Repositories
{
    public interface IEmployeeReponsitory : IRepository<Ingest>
    {
        void SaveChanges();
    }
    public class EmployeeRepository:RepositoryBase<Ingest>,IEmployeeReponsitory
    {
        public EmployeeRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

      
    }
}
