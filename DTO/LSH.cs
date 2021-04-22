using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3LAYER.DTO
{
    class LSH
    {
        public string TenLop { get; set; }
        public int ID_Lop { get; set; }
        public override string ToString()
        {
            return TenLop;
        }
    }
}
