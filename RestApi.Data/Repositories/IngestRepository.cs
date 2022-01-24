using RestApi.Data.Entities;
using RestApi.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Repositories
{
    public interface IIngestRepository : IRepository<Ingest>
    {
        
    }
    public class IngestRepository:RepositoryBase<Ingest>,IIngestRepository
    {
        public IngestRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
