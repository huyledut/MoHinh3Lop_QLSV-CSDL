
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV_3LAYER.BLL;
using QLSV_3LAYER.DAL;
using QLSV_3LAYER.DTO;

namespace QLSV_3LAYER.BLL
{
    class BLL_QLSV
    {
        private static BLL_QLSV _Instance;
        public delegate bool MyDel_Sort(SVview s1, SVview s2);
        public static BLL_QLSV Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set { }
        }
        public List<SV> ListSV_BLL(int id)
        {          
            return DAL_QLSV.Instance.GetListSV_DAL(id);
        }
        public bool AddSV_BLL(SV s)
        {
            foreach(SV st in ListSV_BLL(0))
            {
                if (st.MSSV == s.MSSV) return false;
            }
            DAL_QLSV.Instance.AddSV_Dal(s);
            return true;
        }
        public List<LSH> ListLSH_BLL()
        {          
            return DAL_QLSV.Instance.getListLSH_DAL();
        }
        //public List<SV> getListSVbyMSSV(List<string> ds)
        //{
        //    List<SV> lsv = new List<SV>();
        //    foreach(string i in ds)
        //    {
        //        lsv.Add(DAL_QLSV.Instance.getSVbyMSSV(i));
        //    }
        //    return lsv;
        //}
        private LSH getLSH(int ID)
        {
            LSH lop = new LSH();
            foreach (LSH c in DAL_QLSV.Instance.getListLSH_DAL())
            {
                if (c.ID_Lop==ID) lop = c;
            }
            return lop;
        }
        private SVview getSVviewBySV(SV s)
        {
            return new SVview
            {
                MSSV = s.MSSV,
                GioiTinh = s.GioiTinh,
                HoTen = s.HoTen,
                Lop = getLSH(s.ID_Lop),
                NgaySinh = s.NgaySinh
            };
        }
        public List<SVview> getListSVviewbyMSSV(List<string> ds)
        {
            List<SVview> lsv = new List<SVview>();
            foreach (string i in ds)
            {
                lsv.Add( getSVviewBySV(DAL_QLSV.Instance.getSVbyMSSV(i)) );
            }
            return lsv;
        }

        public List<SVview> SortSV(MyDel_Sort d, List<string> ds)
        {
            List<SVview> data = getListSVviewbyMSSV(ds);
            for(int i=0;i< data.Count -1;i++)
                for(int j=i+1;j<data.Count;j++)
                {
                    if(d(data[i],data[j]))
                    {
                        SVview tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                }
            return data;
        }
        public SV getSVbyMSSV(string mssv)
        {
            return DAL_QLSV.Instance.getSVbyMSSV(mssv);
        }
        public void EditSV_BLL(SV s)
        {
            DAL_QLSV.Instance.EditSV_DAL(s);
        }
        public void DeleteSV_BLL(string mssv)
        {
            DAL_QLSV.Instance.Delete_DAL(mssv);
        }
        public List<SVview> SearchSV_BLL(string text, int ID)
        {
            List<SV> data = DAL_QLSV.Instance.SearchSV_DAL(text,ID);/***/
            List<SVview> DSview = new List<SVview>();
            foreach(SV i in data)
            {
                DSview.Add(getSVviewBySV(i));
            }
            return DSview;
        }
        public List<SVview> getListSVview(int index)
        {
            //index la id_lop can lay
            List<SVview> data = new List<SVview>();
            foreach (SV s in DAL_QLSV.Instance.GetListSV_DAL(index))
                data.Add(getSVviewBySV(s));
            return data;
        }
    }
}
