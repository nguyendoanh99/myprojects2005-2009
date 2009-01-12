using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LoaiDocGiaDTO
    {
        private int _maLoaiDocGia;
        public int MaLoaiDocGia
        {
            get { return _maLoaiDocGia; }
            set { _maLoaiDocGia = value; }
        }
        private string _tenLoaiDocGia;
        public string TenLoaiDocGia
        {
            get { return _tenLoaiDocGia; }
            set { _tenLoaiDocGia = value; }
        }
        public override bool Equals(object obj)
        {
            LoaiDocGiaDTO temp = obj as LoaiDocGiaDTO;
            if (temp == null)
                return false;

            return temp.MaLoaiDocGia == this.MaLoaiDocGia;
        }
//         public override string ToString()
//         {
//             return TenLoaiDocGia;
//         }
    }
}
