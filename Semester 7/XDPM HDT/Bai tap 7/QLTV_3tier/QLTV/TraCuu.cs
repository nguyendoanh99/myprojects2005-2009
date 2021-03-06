using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLTV.BUS_WS;
namespace QLTV
{
    public partial class TraCuu : Form
    {
        public TraCuu()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Lấy thông tin của các chuỗi điều kiện
            string strName = txtName.Text.Trim();
            string strAddress = txtAddress.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            LoaiDocGiaDTO loaidocgia = (LoaiDocGiaDTO)cmbType.SelectedItem;
            DateTime dtBegin = dtpBegin.Value;
            DateTime dtEnd = dtpEnd.Value;
            DateTime dtBirth = dtpBirth.Value;

            // Thêm điều kiện
            BUS_Service bus = new BUS_Service();

            List<string> lstKey = new List<string>();
            List<object> lstValue = new List<object>();
            List<bool> lstExact = new List<bool>();
            // Họ tên
            if (strName != "")
            {
                lstKey.Add("HoTen");
                lstValue.Add(strName);
                lstExact.Add(false);
            }
            // Số nhà
            if (strAddress != "")
            {
                lstKey.Add("SoNha");
                lstValue.Add(strAddress);
                lstExact.Add(false);
            }
            // Đường
            if (strEmail != "")
            {
                lstKey.Add("Email");
                lstValue.Add(strEmail);
                lstExact.Add(false);
            }

            lstKey.Add("MaLoaiDocGia");
            lstValue.Add(loaidocgia.MaLoaiDocGia);
            lstExact.Add(true);

            if (chkBegin.Checked == true)
            {
                lstKey.Add("NgayLapThe");
                lstValue.Add(dtBegin);
                lstExact.Add(true);
            }
            if (chkEnd.Checked == true)
            {
                lstKey.Add("NgayHetHan");
                lstValue.Add(dtEnd);
                lstExact.Add(true);
            }
            if (chkBirth.Checked == true)
            {
                lstKey.Add("NgaySinh");
                lstValue.Add(dtBirth);
                lstExact.Add(true);
            }

            TheDocGiaDTO[] result = bus.TheDocGia_GetByProperties(lstKey.ToArray(), lstValue.ToArray(), lstExact.ToArray());
            dgv.DataSource = result;

            // Thông báo
            if (result.Length == 0)
                MessageBox.Show("Không có thẻ độc giả tương ứng.");
            else
                MessageBox.Show(result.Length + " thẻ độc giả được tìm thấy.");

//            bus.Close();
        }

        private void chkBirth_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            dtpBirth.Enabled = obj.Checked;
        }

        private void chkBegin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            dtpBegin.Enabled = obj.Checked;
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            dtpEnd.Enabled = obj.Checked;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].DataPropertyName.Contains("LoaiDocGia"))
                e.Value = ((TheDocGiaDTO)dgv.Rows[e.RowIndex].DataBoundItem).LoaiDocGia.TenLoaiDocGia;
        }

        private void TraCuu_Load(object sender, EventArgs e)
        {
            BUS_Service bus = new BUS_Service();
            LoaiDocGiaDTO[] ListOfLoaiDocGia = bus.LoaiDocGia_GetAll();
            cmbType.DataSource = ListOfLoaiDocGia;
            cmbType.DisplayMember = "TenLoaiDocGia";
            cmbType.ValueMember = "MaLoaiDocGia";
        }

    }
}