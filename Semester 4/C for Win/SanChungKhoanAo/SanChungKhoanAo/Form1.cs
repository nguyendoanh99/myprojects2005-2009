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
    public partial class Form1 : Form
    {
        public static OleDbConnection cnn;
        public static int phien;

        public Form1()
        {
            InitializeComponent();
        }

        private void butTaoKH_Click(object sender, EventArgs e)
        {
            frmTaoKhachHang frm = new frmTaoKhachHang();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            cnn = new OleDbConnection();
            cnn.ConnectionString = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = ChungKhoanDB.mdb";
            cnn.Open();
            dtp.Value = DateTime.Now;            
            cmbPhien.Text = "1";

            int time = dtp.Value.Hour * 100 + dtp.Value.Minute;
            
            if (7 * 100 + 30 <= time && time <= 8 * 100 + 30)
                phien = 1;
            else
                if (8 * 100 + 30 < time && time <= 9 * 100 + 30)
                    phien = 2;
                else
                    if (9 * 100 + 30 < time && time <= 10 * 100 + 30)
                        phien = 3;
                    else phien = -1;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmXoaKhachHang frm = new frmXoaKhachHang();
            frm.ShowDialog();
        }

        private void butDatLenh_Click(object sender, EventArgs e)
        {
            frmDatLenh frm = new frmDatLenh();
            frm.ShowDialog();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKetQuaLenhGiaoDich frm = new frmKetQuaLenhGiaoDich();
            frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmThongTinTaiKhoan frm = new frmThongTinTaiKhoan();
            frm.ShowDialog();
        }

        private void KetThucPhienGiaoDich(int phien, DateTime DT, string maCP)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select avg(Gia) from PhieuDatLenh where Phien = " + phien.ToString()
                +" and Ngay = #" + DT.ToShortDateString() + "# and maCP = '" + maCP +"'";
            OleDbDataReader rd;
            decimal giakhoplenh = (decimal) cmd.ExecuteScalar();


            cmd.CommandText = "select max(maKQGD) from KetQuaGiaoDich";
            int maKQGD;
            try
            {
                maKQGD = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                maKQGD = 0;
            }
            
            // Them ket qua giao dich cua co phien maCP
            cmd.CommandText = "insert into KetQuaGiaoDich(maKQGD, MaCP, Phien, Ngay, GiaKhopLenh)"
            + " values(@maKQGD, @MaCP, @Phien, @Ngay, @GiaKhopLenh)";
            OleDbParameter para = cmd.Parameters.Add("@maKQGD", OleDbType.Integer);
            para.Value = maKQGD + 1;
            
            para = cmd.Parameters.Add("@MaCP", OleDbType.VarWChar);
            para.Value = maCP;

            para = cmd.Parameters.Add("@Phien", OleDbType.Integer);
            para.Value = phien;

            para = cmd.Parameters.Add("@Ngay", OleDbType.Date);
            para.Value = DT.Date;
            
            para = cmd.Parameters.Add("@GiaKhopLenh", OleDbType.Currency);
            para.Value = giakhoplenh;

            cmd.ExecuteNonQuery();
            // Cap nhat lai phieu dat lenh
            cmd.CommandText = "update PhieuDatLenh set TrangThai = 'Khớp' where Phien = " + phien.ToString()
                + " and Ngay = #" + DT.ToShortDateString() + "# and maCP = '" + maCP + "' and ((LoaiLenh = 'Mua' and Gia >= " 
                + giakhoplenh + ") or (LoaiLenh = 'Bán' and Gia <= " + giakhoplenh +"))";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "update PhieuDatLenh set TrangThai = 'Không khớp' where Phien = " + phien.ToString()
                + " and Ngay = #" + DT.ToShortDateString() + "# and maCP = '" + maCP + "' and not ((LoaiLenh = 'Mua' and Gia >= "
                + giakhoplenh + ") or (LoaiLenh = 'Bán' and Gia <= " + giakhoplenh + "))";
            cmd.ExecuteNonQuery();
            // Them So huu
            cmd.CommandText = "select MaKH, SoLuong, Gia, TrangThai, LoaiLenh from PhieuDatLenh where Phien = " + phien.ToString()
                + " and Ngay = #" + DT.ToShortDateString() + "# and maCP = '" + maCP + "' and TrangThai = 'Khớp'";

            rd = cmd.ExecuteReader();
            
            while (rd.Read())
            {
                OleDbCommand cmd1 = new OleDbCommand();
                cmd1.Connection = cnn;
                
                if (string.Compare(rd.GetString(4), "Mua", true) == 0)
                {                    
                    cmd1.CommandText = "select count(*) from SoHuu where MaKH =" +rd.GetInt32(0).ToString()
                        +" and MaCP = '" + maCP +"'";
                    int t = (int)cmd1.ExecuteScalar();
                    // Chua so huu co phieu nao
                    if (t == 0)
                    {
                        // Them so huu
                        cmd1.CommandText = "insert into SoHuu(MaKH, MaCP, SoLuong) values(@MaKH, @MaCP, @SoLuong)";
                        para = cmd1.Parameters.Add("@MaKH", OleDbType.Integer);
                        para.Value = rd.GetInt32(0);
                        para = cmd1.Parameters.Add("@MaCP", OleDbType.VarWChar);
                        para.Value = maCP;
                        para = cmd1.Parameters.Add("@SoLuong", OleDbType.Integer);
                        para.Value = rd.GetInt32(1);
                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd1.CommandText = "update SoHuu set SoLuong = SoLuong + " + rd.GetInt32(1).ToString()
                            + " where MaKH =" + rd.GetInt32(0).ToString() + " and MaCP = '" + maCP + "'";
                        cmd1.ExecuteNonQuery();
                    }
                    // Giam tien
                    decimal temp = (decimal)rd.GetInt32(1) * rd.GetDecimal(2);
                    cmd1.CommandText = "update KhachHang set SoTien = SoTien - " + temp.ToString() + " where MaKH ="
                        + rd.GetInt32(0).ToString();
                    cmd1.ExecuteNonQuery();
                }
                else
                    if (string.Compare(rd.GetString(4), "Bán", true) == 0)
                    {
                        cmd1.CommandText = "update SoHuu set SoLuong = SoLuong - " + rd.GetInt32(1).ToString()
                            + " where MaKH =" + rd.GetInt32(0).ToString() + " and MaCP = '" + maCP + "'";
                        cmd1.ExecuteNonQuery();

                        cmd1.CommandText = "select SoLuong from SoHuu where MaKH =" + rd.GetInt32(0).ToString()
                            + " and MaCP = '" + maCP + "'";
                        
                        OleDbDataReader rd1 = cmd1.ExecuteReader();
                        rd1.Read();
                        if (rd1.GetInt32(0) <= 0)
                        {
                            // Xoa so huu
                            rd1.Close();
                            cmd1.CommandText = "delete from SoHuu where MaKH = " + rd.GetInt32(0).ToString() + " and MaCP = '" + maCP + "'";
                            cmd1.ExecuteNonQuery();
                        }
                        rd1.Close();
                        // Tang tien
                        decimal temp = (decimal)rd.GetInt32(1) * rd.GetDecimal(2);
                        cmd1.CommandText = "update KhachHang set SoTien = SoTien + " + temp.ToString() + " where MaKH ="
                            + rd.GetInt32(0).ToString();
                        
                        cmd1.ExecuteNonQuery();
                    }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtp.Value = dtp.Value.AddSeconds(1);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            int time = dtp.Value.Hour * 100 + dtp.Value.Minute;
            int phien1 = phien;
            if (7 * 100 + 30 <= time && time <= 8 * 100 + 30)
                phien = 1;
            else
                if (8 * 100 + 30 < time && time <= 9 * 100 + 30)
                    phien = 2;
                else
                    if (9 * 100 + 30 < time && time <= 10 * 100 + 30)
                        phien = 3;
                    else phien = -1;

            if (phien != phien1)
            {

                if (phien <= 0)
                {
                    butDatLenh.Enabled = false;
                    lblPhien.Text = "Hết phiên giao dịch";
                }
                else
                {
                    lblPhien.Text = "Phiên giao dịch " + phien.ToString();
                    if (butDatLenh.Enabled == false)
                        butDatLenh.Enabled = true;
                }

                if (phien1 <= 0)
                    return;

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "select macp from phieudatlenh where phien = " + phien1.ToString()
                    + " and Ngay = #" + dtp.Value.ToShortDateString() + "#"
                    + " group by macp";
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    KetThucPhienGiaoDich(phien1, dtp.Value, rd.GetString(0));
                }
            }       
        }

        private void butDongY_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Form1.cnn;
            cmd.CommandText = "select MaCP, GiaKhopLenh from KetQuaGiaoDich where Phien = @Phien and Ngay = #" +
                dtpNgayGD.Value.ToShortDateString() + "#";

            OleDbParameter para = cmd.Parameters.Add("@Phien", OleDbType.Integer);
            para.Value = int.Parse(cmbPhien.Text);

            OleDbDataReader rd = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                ListViewItem item = new ListViewItem();
                if (!rd.IsDBNull(0))
                    item.Text = rd.GetString(0);
                else
                    item.Text = "";

                if (!rd.IsDBNull(1))
                    item.SubItems.Add(rd.GetDecimal(1).ToString());
                else
                    item.SubItems.Add("");

                listView1.Items.Add(item);
            }
        }
    }
}