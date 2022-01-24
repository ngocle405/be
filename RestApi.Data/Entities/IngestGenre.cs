using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("IngestGenre")]
    public class IngestGenre
    {
        [Key]
        public int IngestGenreId { get; set; }
        [Required]
        [MaxLength(250)]
        public string IngestGenreName { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Ingest> Ingests { get; set; }
        //nếu employee chưa có thì có ds rỗng
        public IngestGenre()
        {
            Ingests = new HashSet<Ingest>();
        }
    }
}
