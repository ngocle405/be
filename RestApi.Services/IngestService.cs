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
        public IEnumerable<Ingest> Get();
    }
    public class IngestService : IIngestService
    {
        private readonly IIngestRepository _IngestRepository;
        public IngestService(IIngestRepository IngestRepository)
        {
           _IngestRepository = IngestRepository;
        }
        /// <summary>
        /// createBy:Lê thanh Ngọc (24/01/2022)
        /// </summary>
        /// <returns>danh sách ingest</returns>
        public IEnumerable<Ingest> Get()
        {
            return _IngestRepository.GetAll();
        }
    }
}
