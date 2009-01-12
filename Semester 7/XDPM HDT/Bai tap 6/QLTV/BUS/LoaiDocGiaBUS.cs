using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DAO;
namespace BUS
{
    public class LoaiDocGiaBUS:AbstractBUS
    {
        public LoaiDocGiaBUS()
        {
            dp = new LoaiDocGiaDAO();
        }
    }
}
