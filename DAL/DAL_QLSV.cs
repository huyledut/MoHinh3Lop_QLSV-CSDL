using QLSV_3LAYER.DAL;
using QLSV_3LAYER.DTO;
using QLSV_3LAYER.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3LAYER.DAL
{
    class DAL_QLSV
    {
        private static DAL_QLSV _Instance;
        public static DAL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLSV();
                }
                return _Instance;
            }
            private set { }
        }
        public List<SV> GetListSV_DAL(int id)
        {
            List<SV> data = new List<SV>();
            string query;
            if (id == 0) query = "Select * from SV";
            else query = "select * from SV where ID_Lop= '" + id + "'";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetSV(i));
            }
            return data;
        }
        public SV GetSV(DataRow i)
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                HoTen = i["NameSV"].ToString(),
                GioiTinh = Convert.ToBoolean(i["Gender"].ToString()),
                NgaySinh = Convert.ToDateTime(i["NS"]),
                ID_Lop = Convert.ToInt32(i["ID_Lop"])
            };
        }

        public void AddSV_Dal(SV s)
        {
            string query = "insert into SV values ('"
                            + s.MSSV + "','" + s.HoTen + "','"
                            + s.GioiTinh.ToString()
                            + "','" + s.NgaySinh.ToString() + "','"
                            + s.ID_Lop.ToString() + "')";
            DBHelper.Instance.ExecuteDB(query);
        }
        public LSH getLSH(DataRow i)
        {
            return new LSH
            {
                ID_Lop = Convert.ToInt32(i["ID_Lop"]),
                TenLop = i["NameLop"].ToString()
            };
        }
       public List<LSH> getListLSH_DAL()
       {
            string query = "select * from LopSH";
            List<LSH> ds = new List<LSH>();
            foreach(DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                ds.Add(getLSH(i));
            }
            return ds;
       }
       public SV getSVbyMSSV(string MSSV)
       {
            string query = "select * from SV where MSSV='" + MSSV + "'";
            DataRow dr = DBHelper.Instance.GetRecords(query).Rows[0];
            return GetSV(dr);
       }
       public void EditSV_DAL(SV s)
        {
            string query = "UPDATE SV SET "
                            +"NameSV = '" + s.HoTen +"'"
                            + " ,ID_Lop= " + s.ID_Lop.ToString() 
                            + " ,NS= '" + s.NgaySinh.ToString() +"'"
                            + " ,Gender= '"+ s.GioiTinh.ToString()                         
                            +"' Where MSSV='"+s.MSSV+"';";
                            
            DBHelper.Instance.ExecuteDB(query);
        }

        public void Delete_DAL(string mssv)
        {
            string query ="DELETE FROM SV WHERE MSSV= '"+mssv+"';";
            DBHelper.Instance.ExecuteDB(query);
        }

        public List<SV> SearchSV_DAL(string text, int ID)
        {
            List<SV> data = new List<SV>();
            foreach(SV i in GetListSV_DAL(ID))
            {
                if (i.MSSV.Contains(text) || i.HoTen.Contains(text) ||
                    i.ID_Lop.ToString().Contains(text))
                    data.Add(i);
            }
            return data;
        }
    }
}
