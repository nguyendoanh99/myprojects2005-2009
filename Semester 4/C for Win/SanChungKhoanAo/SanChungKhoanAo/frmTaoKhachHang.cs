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
    public partial class frmTaoKhachHang : Form
    {
        public frmTaoKhachHang()
        {
            InitializeComponent();
        }

        private void frmTaoKhachHang_Load(object sender, EventArgs e)
        {
            KhoiTao();    
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void KiemTra()
        {
            try
            {
                int t = int.Parse(txtCMND.Text);
                decimal t1 = decimal.Parse(txtSoTien.Text);
                if (t >= 0 && t1 >= 0)
                {
                    if (butDongY.Enabled != true)
                        butDongY.Enabled = true;
                }
                else
                {
                    if (butDongY.Enabled == true)
                        butDongY.Enabled = false;
                }
            }
            catch (Exception e1)
            {
                if (butDongY.Enabled == true)
                    butDongY.Enabled = false;
            }
        }

        private void KhoiTao()
        {
            txtCMND.Text = "";
            txtTenKH.Text = "";
            txtSoTien.Text = "";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select max(makh) from khachhang";
            int makh;
            try
            {
                makh = (int)cmd.ExecuteScalar();
            }
            catch (Exception e1)
            {
                makh = 0;
            }

            makh++;
            txtMaKH.Text = makh.ToString();
            txtTenKH.Focus();
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Form1.cnn;
                cmd.CommandText = "insert into KhachHang(MaKH, TenKH, CMND, SoTien) values(@MaKH, @TenKH, @CMND, @SoTien)";

                OleDbParameter para = cmd.Parameters.Add("@MaKH", OleDbType.Integer);
                para.Value = int.Parse(txtMaKH.Text);

                para = cmd.Parameters.Add("@TenKH", OleDbType.VarWChar);
                para.Value = txtTenKH.Text;

                para = cmd.Parameters.Add("@CMND", OleDbType.Integer);
                para.Value = int.Parse(txtCMND.Text);

                para = cmd.Parameters.Add("@SoTien", OleDbType.Currency);
                para.Value = decimal.Parse(txtSoTien.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return;
            }
            MessageBox.Show("Tạo khách hàng thành công.\nKhách hàng vừa được tạo có mã KH là \""+ txtMaKH.Text +"\"", "Thông báo");
            KhoiTao();            
        }
    }
}