using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DTO;
using System.Data;
using System.Collections;
namespace DAO
{
    public class TheDocGiaDAO:DataProvider
    {
        List<LoaiDocGiaDTO> lstLoaiDocGiaDTO;
        public TheDocGiaDAO()
        {
            LoaiDocGiaDAO dao = new LoaiDocGiaDAO();
            lstLoaiDocGiaDTO = (List<LoaiDocGiaDTO>)dao.GetAll();
        }
        public void Insert(TheDocGiaDTO dto)
        {
            string sql = "insert into TheDocGia(HoTen, DiaChi, Email, NgaySinh, NgayLapThe, NgayHetHan, MaLoaiDocGia) values ('"
                        + dto.HoTen + "','"
                        + dto.DiaChi + "','"
                        + dto.Email + "','"
                        + dto.NgaySinh.ToShortDateString() +"','"
                        + dto.NgayLapThe.ToShortDateString() + "','"
                        + dto.NgayHetHan.ToShortDateString() + "','"
                        + dto.LoaiDocGia.MaLoaiDocGia + "')";
            executeNonQuery(sql);
            sql = "select @@IDENTITY";
            dto.MaThe = (int) executeScalar(sql);
        }
        public void Update(TheDocGiaDTO dto)
        {
            string sql = "update TheDocGia set "
                        + "HoTen = '" + dto.HoTen + "', "
                        + "DiaChi = '" + dto.DiaChi + "', "
                        + "Email = '" + dto.Email + "', "
                        + "NgaySinh = '" + dto.NgaySinh.ToShortDateString() + "', "
                        + "NgayLapThe = '" + dto.NgayLapThe.ToShortDateString() + "', "
                        + "NgayHetHan = '" + dto.NgayHetHan.ToShortDateString() + "', "
                        + "MaLoaiDocGia = '" + dto.LoaiDocGia.MaLoaiDocGia + "' "
                        + "where MaThe = " + dto.MaThe + "";
            executeNonQuery(sql);
        }
        public void Delete(TheDocGiaDTO dto)
        {
            string sql = "delete from TheDocGia where MaThe = " + dto.MaThe + "";
            executeNonQuery(sql);
        }
        protected override object GetDataFromDataRow(System.Data.DataRow dr)
        {
            TheDocGiaDTO dto = new TheDocGiaDTO();
            dto.HoTen = (string) dr["HoTen"];
            dto.MaThe = (int)dr["MaThe"];
            dto.DiaChi = (string)dr["DiaChi"];
            dto.Email = (string)dr["Email"];
            dto.NgaySinh = (DateTime)dr["NgaySinh"];
            dto.NgayLapThe = (DateTime)dr["NgayLapThe"];
            dto.NgayHetHan = (DateTime)dr["NgayHetHan"];

            LoaiDocGiaDTO temp = new LoaiDocGiaDTO();
            temp.MaLoaiDocGia = (int)dr["MaLoaiDocGia"];
            temp.TenLoaiDocGia = lstLoaiDocGiaDTO[lstLoaiDocGiaDTO.IndexOf(temp)].TenLoaiDocGia;
            dto.LoaiDocGia = temp;

            return dto;
        }
        protected override System.Collections.IList GetRelatedList()
        {
            return new List<TheDocGiaDTO>();
        }
        protected override string GetTableName()
        {
            return "TheDocGia";
        }

        
    }
}
