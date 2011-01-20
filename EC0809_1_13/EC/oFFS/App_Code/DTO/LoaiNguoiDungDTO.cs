using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for LoaiNguoiDungDTO
/// </summary>
public class LoaiNguoiDungDTO
{
    private int _ma_loai_nguoi_dung;    
    private string _ten_loai_nguoi_dung;

    public string Ten_loai_nguoi_dung
    {
        get { return _ten_loai_nguoi_dung; }
        set { _ten_loai_nguoi_dung = value; }
    }
    public int Ma_loai_nguoi_dung
    {
        get { return _ma_loai_nguoi_dung; }
        set { _ma_loai_nguoi_dung = value; }
    }
	public LoaiNguoiDungDTO()
	{
        Ten_loai_nguoi_dung = "";
        Ma_loai_nguoi_dung = -1;
	}
}
