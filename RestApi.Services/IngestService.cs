using RestApi.Data.Entities;
using RestApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IIngestService
    {
        object GetBroadcastProgram();
        public object Get();
        object GetIngestGenre();
        object AddIngest(Ingest ingest);

    }
    public class IngestService : IIngestService
    {
        private readonly IIngestRepository _IngestRepository;
        public IngestService(IIngestRepository IngestRepository)
        {
           _IngestRepository = IngestRepository;
        }

        public object AddIngest(Ingest ingest)
        {
            return _IngestRepository.AddIngest(ingest);
        }

        /// <summary>
        /// createBy:Lê thanh Ngọc (24/01/2022)
        /// </summary>
        /// <returns>danh sách ingest</returns>
        public object Get()
        {
            return _IngestRepository.Get();
        }
        public object GetBroadcastProgram()
        {
            return _IngestRepository.GetBroadcastProgram();
        }

        public object GetIngestGenre()
        {
            return _IngestRepository.GetIngestGenre();
        }
    }
}
