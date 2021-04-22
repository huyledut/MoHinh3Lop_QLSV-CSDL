using QLSV_3LAYER.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3LAYER.BLL
{
    class SVview
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public LSH Lop { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public static bool isCompareMSSV(SVview s1, SVview s2)
        {
            return String.Compare(s1.MSSV, s2.MSSV) < 0;
        }
        public static bool isCompareHoTen(SVview s1, SVview s2)
        {
            return String.Compare(s1.HoTen, s2.HoTen) < 0;
        }
        public static bool isCompareID_Lop(SVview s1, SVview s2)
        {
            return s1.Lop.ID_Lop < s2.Lop.ID_Lop;
        }
        public static bool isCompareNgaySinh(SVview s1, SVview s2)
        {
            return DateTime.Compare(s1.NgaySinh, s2.NgaySinh) < 0;
        }
        public static bool isCompareGioiTinh(SVview s1, SVview s2)
        {
            return String.Compare(s1.GioiTinh.ToString(), s2.GioiTinh.ToString()) < 0;
        }
    }
}
