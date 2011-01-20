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
/// Summary description for XL_QuangCao
/// </summary>
public class XL_QuangCao
{
    #region "Attributes"
    private int _ma_quang_cao;
    private int _vi_tri_dat;
    private string _ten_cong_ty_dat_quang_cao;
    private string _dia_chi_cong_ty_dat_quang_cao;
    private string _logo_quang_cao;
    private string _website_cong_ty_quang_cao;    
    private string _website_lien_ket;
    #endregion

    #region "Properties"
    public int Ma_quang_cao
    {
        get { return _ma_quang_cao; }
        set { _ma_quang_cao = value; }
    }
    public int Vi_tri_dat
    {
        get { return _vi_tri_dat; }
        set { _vi_tri_dat = value; }
    }
    public string Ten_cong_ty_dat_quang_cao
    {
        get { return _ten_cong_ty_dat_quang_cao; }
        set { _ten_cong_ty_dat_quang_cao = value; }
    }
    public string Dia_chi_cong_ty_dat_quang_cao
    {
        get { return _dia_chi_cong_ty_dat_quang_cao; }
        set { _dia_chi_cong_ty_dat_quang_cao = value; }
    }
    public string Logo_quang_cao
    {
        get { return _logo_quang_cao; }
        set { _logo_quang_cao = value; }
    }
    public string Website_cong_ty_quang_cao
    {
        get { return _website_cong_ty_quang_cao; }
        set { _website_cong_ty_quang_cao = value; }
    }
    public string Website_lien_ket
    {
        get { return _website_lien_ket; }
        set { _website_lien_ket = value; }
    }
    #endregion

    #region "Constructor"
    public XL_QuangCao()
    {
        Ma_quang_cao = -1;
        Vi_tri_dat = -1;
        Ten_cong_ty_dat_quang_cao = "";
        Dia_chi_cong_ty_dat_quang_cao = "";
        Logo_quang_cao = "";
        Website_cong_ty_quang_cao = "";
        Website_lien_ket = "";
    }
    #endregion
}
