using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Data.Enums
{
    public enum Status
    {
        DaIngest=1,//đã ingest
        ChoDuyet=0,//chờ duyệt
        DaNhan=3,//đã nhận
        DaTraThe=2//đã trả thẻ
    }
}
