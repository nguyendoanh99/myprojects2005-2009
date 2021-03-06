using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SanChungKhoanAo
{
    public partial class frmThongTinTaiKhoan : Form
    {
        public frmThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select TenKH, SoTien from KhachHang where MaKH= @MaKH";

            OleDbParameter para = cmd.Parameters.Add("@MaKH", OleDbType.Integer);
            para.Value = int.Parse(txtMaKH.Text);

            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                if (!rd.IsDBNull(0))
                    lblTenKH.Text = rd.GetString(0);
                else
                {
                    lblTenKH.Text = "";
                }

                if (!rd.IsDBNull(1))
                    lblSoTien.Text = rd.GetDecimal(1).ToString();
                else
                    lblSoTien.Text = "";
            }
            else
            {
                MessageBox.Show("Không có khách hàng có mã là \"" + txtMaKH.Text + "\"", "Thông báo");
                txtMaKH.Focus();
            }

            cmd.CommandText = "select S.MaCP, TenCongTy, SoLuong from SoHuu S, CoPhieu C where S.MaCP = C.MaCP and MaKH= @MaKH";

            para = cmd.Parameters.Add("@MaKH", OleDbType.VarWChar);
            para.Value = txtMaKH.Text;

            listView1.Items.Clear();
            rd.Close();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem item = new ListViewItem();
                if (!rd.IsDBNull(0))
                    item.Text = rd.GetString(0);
                else
                    item.Text = "";

                if (!rd.IsDBNull(1))
                    item.SubItems.Add(rd.GetString(1));
                else
                    item.SubItems.Add("");

                if (!rd.IsDBNull(2))
                    item.SubItems.Add(rd.GetInt32(2).ToString());
                else
                    item.SubItems.Add("");

                listView1.Items.Add(item);
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int t = int.Parse(txtMaKH.Text);
                if (t > 0)
                    butDongY.Enabled = true;
                else
                    butDongY.Enabled = false;
            }
            catch (Exception e1)
            {
                butDongY.Enabled = false;
            }
        }

        private void KhoiTao()
        {
            lblSoTien.Text = "";
            lblTenKH.Text = "";
            listView1.Items.Clear();
        }
           
    }
}