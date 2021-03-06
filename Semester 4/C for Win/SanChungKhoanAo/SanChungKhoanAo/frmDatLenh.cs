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
    public partial class frmDatLenh : Form
    {
        public frmDatLenh()
        {
            InitializeComponent();
        }

        private void frmDatLenh_Load(object sender, EventArgs e)
        {
            KhoiTao();
            cmbLoai.SelectedIndex = 0;
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLoai.SelectedIndex)
            {
                case 0:
                    label6.Text = "Giá mua";
                    break;
                case 1:
                    label6.Text = "Giá bán";
                    break;
            }
            KiemTra();
        }
        private void KiemTra()
        {
            try
            {
                int gia = int.Parse(txtGia.Text);
                int soluong = int.Parse(txtSoLuong.Text);
                int.Parse(txtMaKH.Text);
                if (gia > 0 && soluong > 0)
                {
                    butDongY.Enabled = true;
                }
                else
                {
                    butDongY.Enabled = false;
                    return;
                }
            }
            catch (Exception e)
            {
                butDongY.Enabled = false;
                return;
            }
        }

        private void KhoiTao()
        {
            txtMaKH.Text = "";
            txtMaCP.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            cmbLoai.Text = "1";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select max(maphieu) from phieudatlenh";
            int maphieu;
            try
            {
                maphieu = (int)cmd.ExecuteScalar();
            }
            catch (Exception e1)
            {
                maphieu = 0;
            }

            maphieu++;
            txtMaPhieu.Text = maphieu.ToString();
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            OleDbDataReader rd1;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "insert into PhieuDatLenh(MaPhieu, MaKH, MaCP, SoLuong, LoaiLenh, Phien, Ngay,TrangThai, Gia) "
                +"values (@MaPhieu, @MaKH, @MaCP, @SoLuong, @LoaiLenh, @Phien, @Ngay, @TrangThai, @Gia)";

            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = Form1.cnn;
            cmd1.CommandText = "select count(*) from KhachHang where MaKH = " + txtMaKH.Text;
            int temp = (int)cmd1.ExecuteScalar();
            if (temp == 0)
            {
                MessageBox.Show("Không có mã khách hàng \"" + txtMaKH.Text + "\" trong hệ thống");
                return;
            }

            cmd1.CommandText = "select count(*) from CoPhieu where MaCP = '" + txtMaCP.Text +"'";
            temp = (int)cmd1.ExecuteScalar();
            if (temp == 0)
            {
                MessageBox.Show("Không có mã cổ phiếu \"" + txtMaCP.Text + "\" trong hệ thống");
                return;
            }

            if (Form1.phien <= 0)
            {
                MessageBox.Show("Không thể đặt lệnh được nữa vì đã phiên giao dịch");
                Close();
            }

            switch (cmbLoai.SelectedIndex)
            {
                case 0: // Mua
                    cmd1.CommandText = "select SoTien from KhachHang where MaKH = " + txtMaKH.Text;
                    rd1 = cmd1.ExecuteReader();
                    rd1.Read();
                    if (rd1.GetDecimal(0) < decimal.Parse(txtGia.Text) * decimal.Parse(txtSoLuong.Text))
                    {
                        MessageBox.Show("Không thể thực hiện lệnh mua vì số tiền trong tài khoản của khách hàng không đủ");
                        return;
                    }
                    break;
                case 1: // Ban
                    cmd1.CommandText = "select SoLuong from SoHuu where MaKH = " + txtMaKH.Text
                        + " and MaCP = '" + txtMaCP.Text + "'";
                    rd1 = cmd1.ExecuteReader();
                    if (rd1.Read())
                    {
                        if (rd1.GetInt32(0) < int.Parse(txtSoLuong.Text))
                        {
                            MessageBox.Show("Không thể thực hiện lệnh bán vì số cổ phiếu mà khách hàng nắm giữ không đủ");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể thực hiện lệnh bán vì khách hàng không có cổ phiếu loại này");
                        return;
                    }
                    break;
            }

            OleDbParameter para = cmd.Parameters.Add("@MaPhieu", OleDbType.Integer);
            para.Value = int.Parse(txtMaPhieu.Text);         

            para = cmd.Parameters.Add("@MaKH", OleDbType.VarWChar);
            para.Value = txtMaKH.Text;
            
            para = cmd.Parameters.Add("@MaCP", OleDbType.VarWChar);
            para.Value = txtMaCP.Text;
            
            para = cmd.Parameters.Add("@SoLuong", OleDbType.Integer);
            para.Value = int.Parse(txtSoLuong.Text);

            para = cmd.Parameters.Add("@LoaiLenh", OleDbType.VarWChar);
            para.Value = cmbLoai.Text;

            para = cmd.Parameters.Add("@Phien", OleDbType.Integer);
            para.Value = Form1.phien;

            para = cmd.Parameters.Add("@Ngay", OleDbType.Date);
            para.Value =  Program.frm1.dtp.Value.Date;

            para = cmd.Parameters.Add("@TrangThai", OleDbType.VarWChar);
            para.Value = "Chờ";

            para = cmd.Parameters.Add("@Gia", OleDbType.Integer);
            para.Value = int.Parse(txtGia.Text);

            cmd.ExecuteNonQuery();
            this.Close();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void txtMaCP_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void butHuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}