using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("BroadcastProgram")]
    public class BroadcastProgram
    {
        [Key]
        public int BroadcastProgramId { get; set; }
        [MaxLength(250)]
        public string BroadcastProgramName { get; set; }
        public string Description { get; set; }
        public ICollection<Ingest> Ingests { get; set; }
        public BroadcastProgram()
        {
            Ingests = new HashSet<Ingest>();
        }
    }
}
