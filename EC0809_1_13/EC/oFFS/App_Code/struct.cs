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
/// <summary>
/// Summary description for struct
/// </summary>
public struct Item_online
{
    public int Ma_item;
    public string Ten_item;
    public int Loai_item;
    public string Hinh_anh_minh_hoa;
    public decimal Gia;
    public int So_luong;
}

public struct Gio_hang_online
{
    public ArrayList DsMonAn;
    public string username;
    public decimal gia_tri;
}

public struct ThongKeDoanhThu
{
    public DateTime NgayBatDau;
    public DateTime NgayKetThuc;
    public Double DoanhThu;
}

public struct ThongKeItem
{
    public int MaItem;
    public DateTime NgayBatDau;
    public DateTime NgayKetThuc;
    public int SoLuongBan;
}

public struct LoaiMonItem
{
    public int MaLoaiMon;
    public string TenLoaiMon;
    public int MaLoaiMonCha;
    public Boolean LaLoaiMonLa;
    public int SoLuongMonCon;
}


public struct FormDatHang
{
    public int cmbDiemSD;
    public string lbSoTien;
    public int cmbHTKM;
    public int cmbHTTT;
    public string rdThe;
    public int nodeLoaiThe;
    public string nodeSoThe;
    public int nodeNgayHH;
    public int nodeThangHH;
    public int nodeNamHH;
    public string txtNguoiNhan;
    public string txtDiaChiNhan;
    public int cmbNgayGH;
    public int cmbThangGH;
    public int cmbNamGH;
    public int cmbGioGH;
    public int cmbPhutGH;
    public int cmbBuoiGH;
}

public struct FormDatHangDinhKy
{
    public int cmbDiemSD;
    public string lbSoTien;
    public int cmbHTKM;
    public int cmbHTTT;
    public string rdThe;
    public int nodeLoaiThe;
    public string nodeSoThe;
    public int nodeNgayHH;
    public int nodeThangHH;
    public int nodeNamHH;
    public string txtNguoiNhan;
    public string txtDiaChiNhan;
  
    public int cmbGioGH;
    public int cmbPhutGH;
    public int cmbBuoiGH;

    public int cmbLoaiDK;
    public int cmbNgayBD;
    public int cmbThangBD;
    public int cmbNamBD;
    public int cmbNgayKT;
    public int cmbThangKT;
    public int cmbNamKT;

    public string chuoiDS;
    public string chuoiDSChon;
}

 