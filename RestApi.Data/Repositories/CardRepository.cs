using RestApi.Data.Entities;
using RestApi.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Repositories
{
    public interface ICardRepository:IRepository<Card>
    {
        
    }
    public class CardRepository:RepositoryBase<Card>,ICardRepository
    {
        public CardRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
     

    }
}
