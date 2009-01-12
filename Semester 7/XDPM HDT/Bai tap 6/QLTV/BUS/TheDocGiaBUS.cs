using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;
using System.Collections;
namespace BUS
{
    public class TheDocGiaBUS:AbstractBUS
    {
        public TheDocGiaBUS()
        {
            dp = new TheDocGiaDAO();
        }
        public void Insert(TheDocGiaDTO dto)
        {
            dto.NgayLapThe = DateTime.Now.Date;
            dto.NgayHetHan = dto.NgayLapThe.AddMonths(6).Date;
            ((TheDocGiaDAO)dp).Insert(dto);
        }
        public void Delete(TheDocGiaDTO dto)
        {
            ((TheDocGiaDAO)dp).Delete(dto);
        }
        public void Update(TheDocGiaDTO dto)
        {
            ((TheDocGiaDAO)dp).Update(dto);
        }

    }
}
