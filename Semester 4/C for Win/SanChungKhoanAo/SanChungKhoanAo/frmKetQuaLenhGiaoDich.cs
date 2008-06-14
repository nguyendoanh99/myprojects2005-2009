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
    public partial class frmKetQuaLenhGiaoDich : Form
    {
        public frmKetQuaLenhGiaoDich()
        {
            InitializeComponent();
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select MaPhieu, SoLuong, LoaiLenh, TrangThai, Gia, MaKH, MaCP, Ngay, Phien from PhieuDatLenh where MaKH = @MaKH and MaCP = @MaCP and Phien = @Phien and Ngay = #" +
                dtpNgayGD.Value.ToShortDateString() + "#";

            OleDbParameter para = cmd.Parameters.Add("@MaKH", OleDbType.Integer);
            para.Value = txtMaKH.Text;

            para = cmd.Parameters.Add("@MaCP", OleDbType.VarWChar);
            para.Value = txtMaCP.Text;

            para = cmd.Parameters.Add("@Phien", OleDbType.Integer);
            para.Value = int.Parse(cmbPhien.Text);

            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                lblMaPhieu.Text = rd.GetInt32(0).ToString();
                lblSoLuong.Text = rd.GetInt32(1).ToString();
                lblLoai.Text = rd.GetString(2);
                lblTrangThai.Text = rd.GetString(3);
                lblGia.Text = rd.GetDecimal(4).ToString();
                lblMaKH.Text = rd.GetInt32(5).ToString();
                lblMaCP.Text = rd.GetString(6);
                lblNgay.Text = rd.GetDateTime(7).ToShortDateString();
                lblPhien.Text = rd.GetInt32(8).ToString();
            }
        }

        private void butHuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmKetQuaLenhGiaoDich_Load(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void KiemTra()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Form1.cnn;
                cmd.CommandText = "select count(*) from PhieuDatLenh where MaKH = @MaKH and MaCP = @MaCP and Phien = @Phien and Ngay = #" +
                    dtpNgayGD.Value.ToShortDateString() + "#";

                OleDbParameter para = cmd.Parameters.Add("@MaKH", OleDbType.Integer);
                para.Value = int.Parse(txtMaKH.Text);

                para = cmd.Parameters.Add("@MaCP", OleDbType.VarWChar);
                para.Value = txtMaCP.Text;

                para = cmd.Parameters.Add("@Phien", OleDbType.Integer);
                para.Value = int.Parse(cmbPhien.Text);

                int temp = (int)cmd.ExecuteScalar();
                if (temp == 1)
                {
                    butDongY.Enabled = true;
                }
                else
                    butDongY.Enabled = false;
            }
            catch (Exception e)
            {
                butDongY.Enabled = false;
            }
        }

        private void txtMaCP_TextChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void dtpNgayGD_ValueChanged(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void cmbPhien_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTra();
        }
            
    }
}