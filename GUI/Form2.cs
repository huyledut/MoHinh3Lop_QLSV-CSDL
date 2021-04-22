using QLSV_3LAYER.BLL;
using QLSV_3LAYER.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3LAYER.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Option = new MyDel(setDelegate);
            radioButton1.Checked = true;
            setCBB_LSH();
        }
        static bool Status = false;
        public delegate void MyDel(string MSSV);
        public MyDel Option;
        private static string IDSV = "";
        public static void setDelegate(string MSSV)
        {
            IDSV = MSSV;
        }
        private SV getInform()
        {
            SV s = new SV();
            s.HoTen = tbHoTen.Text.ToString();
            s.MSSV = tbMSSV.Text.ToString();
            s.ID_Lop = ((CBB)cbbLSH.SelectedItem).Value;
            s.NgaySinh = Convert.ToDateTime(dateTimePicker1.Value);
            if (radioButton1.Checked) s.GioiTinh = true;
            else s.GioiTinh = false;
            return s;
        }
        private void btOK_Click(object sender, EventArgs e)
        {            
            if (tbHoTen.Text != "" && tbMSSV.Text != "" && cbbLSH.SelectedItem != null)
            {
                if (IDSV != "")
                {
                    try
                    {
                        BLL_QLSV.Instance.EditSV_BLL(getInform());
                        Status = true;
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Status = false;
                    }                   
                }
                else
                {
                    try
                    {
                        if (BLL_QLSV.Instance.AddSV_BLL(getInform()))
                        {
                            this.Close();
                            Status = true;
                        }
                        else
                        {
                            Status = false;
                            MessageBox.Show("Ma so sinh vien da trung!!");
                        }
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Status = false;
                    }
                }
                if (Status == true)
                {
                    this.Close();
                    Option("");
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
            }
        }

        private void setCBB_LSH()
        {
            if (cbbLSH.Items != null)
            {
                cbbLSH.Items.Clear();
            }
            foreach (LSH i in BLL_QLSV.Instance.ListLSH_BLL())
            {
                cbbLSH.Items.Add(new CBB
                {
                    Text = i.TenLop,
                    Value = i.ID_Lop
                });
            }
        }
        private void showEdit()
        {
            SV s = BLL_QLSV.Instance.getSVbyMSSV(IDSV);
            tbMSSV.Text = s.MSSV;
            tbHoTen.Text = s.HoTen;
            cbbLSH.SelectedIndex = s.ID_Lop - 1;
            dateTimePicker1.Value = s.NgaySinh;
            if (radioButton1.Checked) s.GioiTinh = true;
            else s.GioiTinh = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (IDSV != "")
            {
                tbMSSV.Enabled = false;
                showEdit();
            }
            else tbMSSV.Enabled = true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
