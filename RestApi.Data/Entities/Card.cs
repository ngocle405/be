using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [MaxLength(250)]
        public string CardCode { get; set; }
        [MaxLength(250)]
        public string CardName { get; set; }
        
        public DateTime CardSendDate { get; set; }//ngày gửi
        [MaxLength(250)]
        public string CardRecipient { get; set; }//người nhận thẻ
        public string CardSender { get; set; }//người gửi thẻ
        public ICollection<Ingest> Ingests { get; set; }
        public Card()
        {
            Ingests = new HashSet<Ingest>();
        }
    }
}
