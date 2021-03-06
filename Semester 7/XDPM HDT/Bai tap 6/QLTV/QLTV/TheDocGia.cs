using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using DAO;
using BUS;
namespace QLTV
{
    public partial class TheDocGia : Form
    {
        public TheDocGia()
        {
            InitializeComponent();
        }

        TheDocGiaDTO GetData()
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            DateTime dtBirth = dtpBirth.Value;
            LoaiDocGiaDTO loaidocgia = (LoaiDocGiaDTO)cmbType.SelectedItem;

            TheDocGiaDTO result = new TheDocGiaDTO();
            if (dgv.CurrentRow != null)
            {
                result.MaThe = ((TheDocGiaDTO)dgv.CurrentRow.DataBoundItem).MaThe;
                result.NgayLapThe = (DateTime) dgv.CurrentRow.Cells["NgayLapThe"].Value;
                result.NgayHetHan = (DateTime)dgv.CurrentRow.Cells["NgayHetHan"].Value;
            }

            result.HoTen = name;
            result.DiaChi = address;
            result.Email = email;
            result.NgaySinh = dtBirth;
            result.LoaiDocGia = loaidocgia;

            return result;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            TheDocGiaDTO thedocgia = GetData();
            new TheDocGiaBUS().Insert(thedocgia);
            BindingList<TheDocGiaDTO> bl = (BindingList<TheDocGiaDTO>)dgv.DataSource;
            bl.Add(thedocgia);
            MessageBox.Show("Đã thêm"); 
        }

        private void TheDocGia_Load(object sender, EventArgs e)
        {
            LoaiDocGiaBUS bus = new LoaiDocGiaBUS();
            List<LoaiDocGiaDTO> ListOfLoaiDocGia = (List<LoaiDocGiaDTO>)bus.GetAll();
            cmbType.DataSource = ListOfLoaiDocGia;
            cmbType.DisplayMember = "TenLoaiDocGia";
            cmbType.ValueMember = "MaLoaiDocGia";

            TheDocGiaBUS tdgBus = new TheDocGiaBUS();            
            List<TheDocGiaDTO> ListOfTheDocGia = (List<TheDocGiaDTO>)tdgBus.GetAll();
            BindingList<TheDocGiaDTO> bl = new BindingList<TheDocGiaDTO>(ListOfTheDocGia);
            dgv.DataSource = bl;
            bl.AllowNew = false;
            //bl.AllowRemove = false;
            //bl.AllowEdit = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                TheDocGiaDTO thedocgia = GetData();
                new TheDocGiaBUS().Delete(thedocgia);

                BindingList<TheDocGiaDTO> bl = (BindingList<TheDocGiaDTO>)dgv.DataSource;
                bl.RemoveAt(dgv.CurrentRow.Index);
                MessageBox.Show("Đã xóa");
            }
            else
                MessageBox.Show("Chọn 1 dòng để xóa");
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                TheDocGiaDTO thedocgia = GetData();
                new TheDocGiaBUS().Update(thedocgia);
                BindingList<TheDocGiaDTO> bl = (BindingList<TheDocGiaDTO>)dgv.DataSource;
                TheDocGiaDTO tdg = bl[dgv.CurrentRow.Index];


                dgv.CurrentRow.Cells["HoTen"].Value = thedocgia.HoTen;
                dgv.CurrentRow.Cells["LoaiDocGia"].Value = thedocgia.LoaiDocGia;
                dgv.CurrentRow.Cells["NgayLapThe"].Value = thedocgia.NgayLapThe;
                dgv.CurrentRow.Cells["DiaChi"].Value = thedocgia.DiaChi;
                dgv.CurrentRow.Cells["Email"].Value = thedocgia.Email;
                
                MessageBox.Show("Đã sửa");
            }
            else
                MessageBox.Show("Chọn 1 dòng để sửa");
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].DataPropertyName.Contains("LoaiDocGia"))
                e.Value = ((TheDocGiaDTO)dgv.Rows[e.RowIndex].DataBoundItem).LoaiDocGia.TenLoaiDocGia;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            txtName.Text = (string)dgv.CurrentRow.Cells["HoTen"].Value;
            txtAddress.Text = (string)dgv.CurrentRow.Cells["DiaChi"].Value;
            txtEmail.Text = (string)dgv.CurrentRow.Cells["Email"].Value;
            dtpBirth.Value = (DateTime)dgv.CurrentRow.Cells["NgaySinh"].Value;
            cmbType.SelectedItem = ((TheDocGiaDTO)dgv.CurrentRow.DataBoundItem).LoaiDocGia;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            new TraCuu().ShowDialog();
        }
    }
}