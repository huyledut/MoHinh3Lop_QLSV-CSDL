using QLSV_3LAYER.BLL;
using QLSV_3LAYER.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3LAYER.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCBB_LSH();
            setCBB_Sort();
            setDGV("");
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            if(cbbLSH.SelectedIndex >= 0)
            {
                int id_lop = ((CBB)(cbbLSH.SelectedItem)).Value;
                dataGridView1.DataSource = BLL_QLSV.Instance.getListSVview(id_lop);
            }
            else
            {
                MessageBox.Show("Phuong thuc hien thi khong hop le");
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Option("");
            f2.Option += setDGV;
            f2.ShowDialog();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) MessageBox.Show("Ban can chon 1 sinh vien de thuc hien!", "Thong bao");
            else
            {
                Form2 f2 = new Form2();
                string mssv = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
                f2.Option(mssv);
                f2.Option += setDGV;
                f2.ShowDialog();
            }
        }
        private void setCBB_LSH()
        {
            if(cbbLSH.Items != null)
            {
                cbbLSH.Items.Clear();
            }
            cbbLSH.Items.Add(new CBB{ Value = 0,Text = "ALL"});
            foreach(LSH i in BLL_QLSV.Instance.ListLSH_BLL())
            {
                cbbLSH.Items.Add(new CBB
                {
                    Text = i.TenLop,
                    Value = i.ID_Lop
                });
            }
        }
        private void setCBB_Sort()
        {
            if (cbboxSort.Items != null)
            {
                cbboxSort.Items.Clear();
            }
            cbboxSort.Items.Add("MSSV");
            cbboxSort.Items.Add("HoTen");
            cbboxSort.Items.Add("ID_Lop");
            cbboxSort.Items.Add("GioiTinh");
            cbboxSort.Items.Add("NgaySinh");
        }
        private void btSort_Click(object sender, EventArgs e)
        {           
            List<string> ds = new List<string>();
            int indexLop = ((CBB)cbbLSH.SelectedItem).Value;
            foreach (SV i in BLL_QLSV.Instance.ListSV_BLL(indexLop))
                ds.Add(i.MSSV);
            if (cbboxSort.SelectedItem != null)
            {
                dataGridView1.DataSource = null;
                string Menu = cbboxSort.Text;
                switch (Menu)
                {
                    case "MSSV":
                        dataGridView1.DataSource = BLL_QLSV.Instance.SortSV(SVview.isCompareMSSV, ds);
                        break;
                    case "HoTen":
                        dataGridView1.DataSource = BLL_QLSV.Instance.SortSV(SVview.isCompareHoTen, ds);
                        break;
                    case "ID_Lop":
                        dataGridView1.DataSource = BLL_QLSV.Instance.SortSV(SVview.isCompareID_Lop, ds);
                        break;
                    case "NgaySinh":
                        dataGridView1.DataSource = BLL_QLSV.Instance.SortSV(SVview.isCompareNgaySinh, ds);
                        break;
                    case "GioiTinh":
                        dataGridView1.DataSource = BLL_QLSV.Instance.SortSV(SVview.isCompareGioiTinh, ds);
                        break;
                }
                dataGridView1.Columns["MSSV"].Visible = false;
            }
            else
            {
                MessageBox.Show("Phuong thuc sap xep khong hop le!", "Thong bao");
            }
        }
        public void setDGV(string msv)
        {
            dataGridView1.DataSource = BLL_QLSV.Instance.getListSVview(0);
            cbbLSH.SelectedIndex = 0;
            dataGridView1.Columns["MSSV"].Visible = false;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Ban chua chon sinh vien can xoa");
            else                    
            {
                string mssv = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
                BLL_QLSV.Instance.DeleteSV_BLL(mssv);
                setDGV("");
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int ID = ((CBB)(cbbLSH.SelectedItem)).Value;
            dataGridView1.DataSource = BLL_QLSV.Instance.SearchSV_BLL(text, ID);
        }
    }
}
