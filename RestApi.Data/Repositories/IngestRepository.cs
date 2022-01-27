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
        object AddIngest(Ingest ingest);
        object GetIngestGenre();
        object GetBroadcastProgram();
        object Get();
        public IEnumerable<Ingest> Gets();
    }
    public class IngestRepository:RepositoryBase<Ingest>,IIngestRepository
    {
        public IngestRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public object GetBroadcastProgram()
        {
            var entities = DbContext.broadcastPrograms;
            return entities;
        }
        public object GetIngestGenre()
        {
            var entities = DbContext.ingestGenres;
            return entities;
        }
        public object AddIngest(Ingest ingest)
        {
            ingest.CreateDate = DateTime.Now;
            ingest.UpdateDate =DateTime.Now;
            ingest.CreateBy = "Lê Thanh Ngọc";
            ingest.IngestGenreId = 1;
            ingest.Status = 0;//
            DbContext.Ingests.Add(ingest);
            DbContext.SaveChanges();
            return ingest;
        }
        public object Get()
        {
            var entities = from t1 in DbContext.Ingests
                           join t2 in DbContext.ingestGenres on t1.IngestGenreId equals t2.IngestGenreId
                           join t3 in DbContext.broadcastPrograms on t1.BroadcastProgramId equals t3.BroadcastProgramId
                           join t4 in DbContext.Cards on t1.CardId equals t4.CardId
                           select new
                           {
                               t1.IngestId,
                               t1.FileName,
                               t1.Reporter,
                               t1.film,
                               t1.Genre,
                               t1.Production,
                               t1.SaveData,
                               t1.Status,
                               t1.StatusName,
                               t1.Subscriber,
                               t1.ProcessingHistory,
                               t1.CreateDate,
                               t1.CreateBy,
                               t1.UpdateDate,
                               t1.CardId,
                               t1.BroadcastProgramId,
                               t1.IngestGenreId,
                               t1.GenreName,
                             
                               t2.IngestGenreName,
                               t3.BroadcastProgramName,
                               t4.CardName,
                               t4.CardSender,
                               t4.CardSendDate,
                               t4.CardRecipient,
                               t4.CardCode,
                           };
            return entities;
        }

        public IEnumerable<Ingest> Gets()
        {
            var entities = DbContext.Ingests.ToList();
            return entities;
        }


    }
}
