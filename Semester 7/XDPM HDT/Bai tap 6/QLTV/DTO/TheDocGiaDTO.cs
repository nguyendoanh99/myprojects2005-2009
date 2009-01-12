using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TheDocGiaDTO
    {
        private int _maThe;
        public int MaThe
        {
            get { return _maThe; }
            set { _maThe = value; }
        }
        private string _hoTen;

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }
        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private DateTime _ngaySinh;
        public System.DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private DateTime _ngayLapThe;
        public System.DateTime NgayLapThe
        {
            get { return _ngayLapThe; }
            set { _ngayLapThe = value; }
        }
        private DateTime _ngayHetHan;
        public System.DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }
        private LoaiDocGiaDTO _loaiDocGia;
        public LoaiDocGiaDTO LoaiDocGia
        {
            get { return _loaiDocGia; }
            set { _loaiDocGia = value; }
        }
    }
}
