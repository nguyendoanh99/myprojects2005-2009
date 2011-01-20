using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ThongKeDAO
/// </summary>
public class ThongKeDAO : AbstractDAO
{
    public ArrayList ThongKeDoanhThu(String loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        String strProc = "";

        switch (loaithongke)
        {
            case "Ngày" :
            case "Ngay":
                strProc = "spThongKeDoanhThuTheoNgay";
                break;
            case "Tuần" :
            case "Tuan":
                strProc = "spThongKeDoanhThuTheoTuan";
                break;
            case "Tháng" :
            case "Thang":
                strProc = "spThongKeDoanhThuTheoThang";
                break;
            case "Quý" :
            case "Quy":
                strProc = "spThongKeDoanhThuTheoQuy";
                break;
            case "Năm" :
            case "Nam":
                strProc = "spThongKeDoanhThuTheoNam";
                break;
            default:
                strProc = "spThongKeDoanhThuTheoNgay";
                break;
        }
        
        ArrayList Kq = new ArrayList(); // ThongKeDoanhThu[]

        Connect();
        SqlCommand cmd = new SqlCommand(strProc, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ngaybatdau", SqlDbType.DateTime);
        cmd.Parameters.Add("@ngayketthuc", SqlDbType.DateTime);

        cmd.Parameters["@ngaybatdau"].Value = ngaybatdau;
        cmd.Parameters["@ngayketthuc"].Value = ngayketthuc;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            object tk = GetDataFromDataRow(dt, i);
            Kq.Add(tk);
        }


        /*
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ThongKeDoanhThu tk = new ThongKeDoanhThu();
            tk.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
            tk.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
            tk.DoanhThu = Double.Parse(dr["DoanhThu"].ToString());

            Kq.Add(tk);
        }
        */


        Disconnect();
        return Kq;
    }


    public ArrayList ThongKeMonAn(int mamon, string loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        String strProc = "";

        switch (loaithongke)
        {
            case "Ngày":
            case "Ngay":
                strProc = "spThongKeMonAnTheoNgay";
                break;
            case "Tuần":
            case "Tuan":
                strProc = "spThongKeMonAnTheoTuan";
                break;
            case "Tháng":
            case "Thang":
                strProc = "spThongKeMonAnTheoThang";
                break;
            case "Quý":
            case "Quy":
                strProc = "spThongKeMonAnTheoQuy";
                break;
            case "Năm":
            case "Nam":
                strProc = "spThongKeMonAnTheoNam";
                break;
            default:
                strProc = "spThongKeMonAnTheoNgay";
                break;
        }
        
        ArrayList Kq = new ArrayList(); // ThongKeItem[]

        Connect();
        SqlCommand cmd = new SqlCommand(strProc, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@mamon", SqlDbType.Int);
        cmd.Parameters.Add("@ngaybatdau", SqlDbType.DateTime);
        cmd.Parameters.Add("@ngayketthuc", SqlDbType.DateTime);

        cmd.Parameters["@mamon"].Value = mamon;
        cmd.Parameters["@ngaybatdau"].Value = ngaybatdau;
        cmd.Parameters["@ngayketthuc"].Value = ngayketthuc;

        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ThongKeItem tk = new ThongKeItem();
            tk.MaItem = mamon;
            tk.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
            tk.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
            tk.SoLuongBan = int.Parse(dr["SoLuongBan"].ToString());

            Kq.Add(tk);
        }

        Disconnect();
        return Kq;
    }


    public ArrayList ThongKeThucDon(int mathucdon, string loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        String strProc = "";

        switch (loaithongke)
        {
            case "Ngày":
            case "Ngay":
                strProc = "spThongKeThucDonTheoNgay";
                break;
            case "Tuần":
            case "Tuan":
                strProc = "spThongKeThucDonTheoTuan";
                break;
            case "Tháng":
            case "Thang":
                strProc = "spThongKeThucDonTheoThang";
                break;
            case "Quý":
            case "Quy":
                strProc = "spThongKeThucDonTheoQuy";
                break;
            case "Năm":
            case "Nam":
                strProc = "spThongKeThucDonTheoNam";
                break;
            default:
                strProc = "spThongKeThucDonTheoNgay";
                break;
        }

        ArrayList Kq = new ArrayList(); // ThongKeItem[]

        Connect();
        SqlCommand cmd = new SqlCommand(strProc, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);
        cmd.Parameters.Add("@ngaybatdau", SqlDbType.DateTime);
        cmd.Parameters.Add("@ngayketthuc", SqlDbType.DateTime);

        cmd.Parameters["@mathucdon"].Value = mathucdon;
        cmd.Parameters["@ngaybatdau"].Value = ngaybatdau;
        cmd.Parameters["@ngayketthuc"].Value = ngayketthuc;

        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ThongKeItem tk = new ThongKeItem();
            tk.MaItem = mathucdon;
            tk.NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
            tk.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
            tk.SoLuongBan = int.Parse(dr["SoLuongBan"].ToString());

            Kq.Add(tk);
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        ThongKeDoanhThu tk = new ThongKeDoanhThu();
        tk.NgayBatDau = DateTime.Parse(dt.Rows[i]["NgayBatDau"].ToString());
        tk.NgayKetThuc = DateTime.Parse(dt.Rows[i]["NgayKetThuc"].ToString());
        tk.DoanhThu = Double.Parse(dt.Rows[i]["DoanhThu"].ToString());

        return (object)tk;
    }  
}
