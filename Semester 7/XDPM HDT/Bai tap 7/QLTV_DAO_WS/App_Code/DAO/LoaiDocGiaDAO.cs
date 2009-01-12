using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using DTO;

namespace DAO
{
    public class LoaiDocGiaDAO: DataProvider
    {
//         public IList getAll()
//         {
//             string sql = "select * from LoaiDocGia";
//             DataTable dt = executeQuery(sql);
// 
//             List<LoaiDocGiaDTO> result = new List<LoaiDocGiaDTO>(dt.Rows.Count);
//             foreach (DataRow dr in dt.Rows)
//             {
//                 result.Add(GetDataFromDataRow(dr));
//             }
//             return result;
//         }
        protected override object GetDataFromDataRow(DataRow dr)
        {
            LoaiDocGiaDTO dto = new LoaiDocGiaDTO();
            dto.MaLoaiDocGia = (int) dr["MaLoaiDocGia"];
            dto.TenLoaiDocGia = (string)dr["TenLoaiDocGia"];
            return dto;
        }
        protected override string GetTableName()
        {
            return "LoaiDocGia";
        }
        protected override IList GetRelatedList()
        {
            return new List<LoaiDocGiaDTO>();
        }

    }
}
