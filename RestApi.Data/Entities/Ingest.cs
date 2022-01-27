using RestApi.Data.Attributes;
using RestApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("Ingest")]
    public class Ingest
    {
        [Key]
        public int IngestId { get; set; }
        [MaxLength(250)]
        [NotEmpty]
        [PropertyName("Tên đề tài")]
        [propMaxLength(50)]
        public string FileName { get; set; }
        [MaxLength(250)]
        [NotEmpty]
        [PropertyName("Phóng viên")]
        public string Reporter { get; set; }
        [NotEmpty]
        [PropertyName("Người đăng ký")]
        public string Subscriber { get; set; }
        [MaxLength(250)]
        [NotEmpty]
        [PropertyName("Đơn vị sản xuất")]
        public string Production { get; set; }
        [MaxLength(250)]
        [NotEmpty]
        [PropertyName("Quay phim")]
        public string film { get; set; }//quay fim
        [NotEmpty]
        [PropertyName("Chương trình phát sóng")]
        public int BroadcastProgramId { get; set; }
        [ForeignKey("BroadcastProgram")]
        [NotEmpty]
        public GenreType Genre { get; set; }
        public string GenreName

        {
            get
            {
                switch (Genre)
                {
                    case GenreType.BanTin:
                        return "Bản tin";
                    case GenreType.ChuyenMuc:
                        return "Chuyên mục";
                    case GenreType.PhongSu:
                        return "Phóng sự";
                    case GenreType.ChuongTrinhKhac:
                        return "Chương trình khác";
                    default: return null;
                }
            }
        }

        public int IngestGenreId { get; set; }
        [ForeignKey("IngestGenre")]

        public int CardId { get; set; }
        [ForeignKey("Card")]

        [MaxLength(250)]
        public string SaveData { get; set; }
        public string ProcessingHistory { get; set; }
        public Status Status { get; set; }
        public string StatusName 
        {
            get
            {
                switch (Status)
                {
                    case Status.ChoDuyet:
                        return "Chờ duyệt";
                    case Status.DaIngest:
                        return "Đã ingest";
                    case Status.DaNhan:
                        return "Đã nhận";
                    case Status.DaTraThe:
                        return "Đã trả thẻ";
                    default: return null;
                }
            }
        }
        [CheckDate]
        public DateTime CreateDate { get; set; }
      
        public string CreateBy { get; set; }
       
        public DateTime UpdateDate { get; set; }

        public string UpdateBy { get; set; }
       
    }
}
