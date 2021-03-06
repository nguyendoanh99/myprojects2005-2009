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
    public partial class frmXoaKhachHang : Form
    {
        public frmXoaKhachHang()
        {
            InitializeComponent();
        }
      
        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            KhoiTao();
            if (txtMaKH.Text.Length == 0)
                return;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select TenKH, cmnd, sotien from khachhang where makh = " + txtMaKH.Text;

            try
            {
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (!rd.IsDBNull(0))
                        lblTenKH.Text = rd.GetString(0);

                    if (!rd.IsDBNull(1))
                        lblCMND.Text = rd.GetInt32(1).ToString();

                    if (!rd.IsDBNull(2))
                        lblSoTien.Text = rd.GetDecimal(2).ToString();

                    if (butDongY.Enabled == false)
                        butDongY.Enabled = true;
                }
                else
                    if (butDongY.Enabled == true)
                        butDongY.Enabled = false;
            }
            catch (Exception e1)
            {
                if (butDongY.Enabled == true)
                    butDongY.Enabled = false;
            }
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng có mã KH là \"" + txtMaKH.Text + "\" không ?", "Thông báo",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Form1.cnn;
                cmd.CommandText = "delete from KhachHang where MaKH = @MaKH";
                OleDbParameter para = cmd.Parameters.Add("@MaKH", OleDbType.Integer);
                para.Value = int.Parse(txtMaKH.Text);
                cmd.ExecuteNonQuery();

                KhoiTao();
                txtMaKH.Text = "";
            }
        }

        private void KhoiTao()
        {
            lblSoTien.Text = "";
            lblCMND.Text = "";
            lblTenKH.Text = "";
            butDongY.Enabled = false;
        }
    }
}