using RestApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IcardService
    {
        public object Get();
        object GetCardById(int cardId);
    }
    public class cardService : IcardService
    {
        private readonly ICardRepository _cardRepository;
        public cardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public object Get()
        {
            return _cardRepository.GetAll();
        }
        public object GetCardById(int cardId)
        {
            return _cardRepository.GetById(cardId);
        }
    }
}
