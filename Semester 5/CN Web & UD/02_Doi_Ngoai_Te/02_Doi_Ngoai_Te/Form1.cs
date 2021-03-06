using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _2_Doi_Ngoai_Te
{
    public partial class Form1 : Form
    {
        private bool BienDung = false; // Dung de tuong tac giua lsVBangTiGia voi cmbLoaiNgoaiTe
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        public void KhoiTao()
        {
            XL_YEU_CAU.BangTiGia = new XL_BANG_TI_GIA("BangTiGia.txt");
            if (XL_BANG_TI_GIA.XemLoi() == "")
            {
                XL_TI_GIA dong;
                for (int i = 0; i < XL_YEU_CAU.BangTiGia.LaySoDong(); ++i)
                {
                    dong = XL_YEU_CAU.BangTiGia.LayDong(i);

                    {
                        // Them item vao listview
                        ListViewItem item = new ListViewItem(dong.KyHieu);
                        item.SubItems.Add(dong.TenNgoaiTe);
                        item.SubItems.Add(dong.MuaVao.ToString());
                        item.SubItems.Add(dong.ChuyenKhoan.ToString());
                        item.SubItems.Add(dong.BanRa.ToString());
                        lsVBangTiGia.Items.Add(item);
                        // Them item vao cmbLoaiNgoaiTe
                        cmbLoaiNgoaiTe.Items.Add(dong.KyHieu);
                        // Mac dinh chon mot so muc
                        cmbLoaiNgoaiTe.SelectedIndex = 0;
                        cmbHinhThucDoi.SelectedIndex = 0;
                    }

                }
            }
            else
                butDoi.Enabled = false;
        }

        private void cmbLoaiNgoaiTe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BienDung == false)
            {
                BienDung = true;
                int index = cmbLoaiNgoaiTe.SelectedIndex;
                lsVBangTiGia.Items[index].Selected = true;                
            }
            else
                BienDung = false;
        }
        private void lsVBangTiGia_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (BienDung == false)
            {                
                ListView.SelectedIndexCollection indexes = lsVBangTiGia.SelectedIndices;
                if (indexes.Count > 0)
                {
                    BienDung = true;
                    cmbLoaiNgoaiTe.SelectedIndex = indexes[0];
                }
            }
            else
                BienDung = false;
        }

        private void butDoi_Click(object sender, EventArgs e)
        {
            String szSoTienCanDoi = txtSoTienCanDoi.Text;
            String szLoaiNgoaiTe = cmbLoaiNgoaiTe.Text;
            String szHinhThucDoi = "";
            String ChuoiLoi = XL_LOI.Loi(szSoTienCanDoi);
            switch (cmbHinhThucDoi.Text)
            {
                case "Mua vào":
                    szHinhThucDoi = "MUA_VAO";
                    break;
                case "Chuyển khoản":
                    szHinhThucDoi = "CHUYEN_KHOAN";
                    break;
                case "Bán ra":
                    szHinhThucDoi = "BAN_RA";
                    break;
            }

            if (ChuoiLoi == "")
            {
                XL_YEU_CAU yc;
                double dSoTienSauKhiDoi;
                double dSoTienCanDoi = double.Parse(szSoTienCanDoi);

                yc = new XL_YEU_CAU(dSoTienCanDoi, szLoaiNgoaiTe, szHinhThucDoi);
                dSoTienSauKhiDoi = yc.QuiDoi();

                String Chuoi = dSoTienSauKhiDoi.ToString() + "VNĐ";
                lblSoTienSauKhiDoi.Text = Chuoi;
            }
            else
            {
                MessageBox.Show(ChuoiLoi, "LOI");
            }

        }
    }
}