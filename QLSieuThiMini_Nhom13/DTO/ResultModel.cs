using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResultModel
    {
        [ColumnName("Score")]
        public float SoLuongBan { get; set; }
    }
}
