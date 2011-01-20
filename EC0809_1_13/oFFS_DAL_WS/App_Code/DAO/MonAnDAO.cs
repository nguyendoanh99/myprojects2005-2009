using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MonAnDAO
/// </summary>
public class MonAnDAO : AbstractDAO
{
    public int ThemMonAn(MonAnDTO monan, String strTag)
    {
        int Kq = 0; //mã người dùng
        Connect();

        SqlCommand cmd = new SqlCommand("spThemMonAn", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tenmon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@hinhanhminhhoa", SqlDbType.NVarChar);
        cmd.Parameters.Add("@mota", SqlDbType.Text);
        cmd.Parameters.Add("@diembinhchon", SqlDbType.Int);
        cmd.Parameters.Add("@donvitinh", SqlDbType.NVarChar);
        cmd.Parameters.Add("@gia", SqlDbType.Money);
        cmd.Parameters.Add("@maloaimon", SqlDbType.Int);
        cmd.Parameters.Add("@tinhtrang", SqlDbType.Bit);
        cmd.Parameters.Add("@trangthaihienthi", SqlDbType.Bit);

        cmd.Parameters["@tenmon"].Value = monan.Ten_mon;
        cmd.Parameters["@hinhanhminhhoa"].Value = monan.Hinh_anh_minh_hoa;
        cmd.Parameters["@mota"].Value = monan.Mo_ta;
        cmd.Parameters["@diembinhchon"].Value = monan.Diem_binh_chon;
        cmd.Parameters["@donvitinh"].Value = monan.Don_vi_tinh;
        cmd.Parameters["@gia"].Value = monan.Gia;
        cmd.Parameters["@maloaimon"].Value = monan.Ma_loai_mon;
        cmd.Parameters["@tinhtrang"].Value = monan.Tinh_trang;
        cmd.Parameters["@trangthaihienthi"].Value = monan.Trang_thai_hien_thi;

        cmd.Parameters.Add("@mamon", SqlDbType.Int);
        cmd.Parameters["@mamon"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            int mamon = int.Parse(cmd.Parameters["@mamon"].Value.ToString());
            Kq = mamon;
            Disconnect();

            String[] dsTag = TagDAO.XuLyChuoiTag(strTag);
            TagDTO tagDTO = new TagDTO();
            TagMonAnDTO tagmonanDTO = new TagMonAnDTO();
            tagmonanDTO.Ma_mon = mamon;

            for (int i = 0; i < dsTag.Length; ++i)
            {
                tagDTO.Ten_tag = dsTag[i];
                int matag = (new TagDAO()).ThemTag(tagDTO);

                tagmonanDTO.Ma_tag = matag;
                (new TagMonAnDAO()).ThemTagMonAn(tagmonanDTO);
            }
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        return Kq;
    }


    public MonAnDTO[] DanhSachMonAn()
    {
        MonAnDTO[] kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachMonAn", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;        
        kq = new MonAnDTO[n];
        
        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        MonAnDTO monan = new MonAnDTO();
        monan.Ma_mon = int.Parse( dt.Rows[i]["MaMon"].ToString());
        monan.Ten_mon = dt.Rows[i]["TenMon"].ToString();
        monan.Hinh_anh_minh_hoa = dt.Rows[i]["HinhAnhMinhHoa"].ToString();
        monan.Mo_ta = dt.Rows[i]["MoTa"].ToString();
        monan.Diem_binh_chon = int.Parse(dt.Rows[i]["DiemBinhChon"].ToString());
        monan.Don_vi_tinh = dt.Rows[i]["DonViTinh"].ToString();
        monan.Gia = double.Parse( dt.Rows[i]["Gia"].ToString());
        monan.Ma_loai_mon = int.Parse(dt.Rows[i]["MaLoaiMon"].ToString());
        monan.Tinh_trang = bool.Parse( dt.Rows[i]["TinhTrang"].ToString());
        monan.Trang_thai_hien_thi = bool.Parse(dt.Rows[i]["TrangThaiHienThi"].ToString());

        return (object)monan;
    } 
}
