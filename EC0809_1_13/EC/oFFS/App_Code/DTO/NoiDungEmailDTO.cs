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
/// Summary description for Email
/// </summary>
public class NoiDungEmailDTO
{
    private int _MaMail;
    public int MaMail
    {
        get { return _MaMail; }
        set { _MaMail = value; }
    }
    private string _Username;
    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    private string _Email;
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private DateTime _NgayGui;
    public System.DateTime NgayGui
    {
        get { return _NgayGui; }
        set { _NgayGui = value; }
    }
    private string _TieuDe;
    public string TieuDe
    {
        get { return _TieuDe; }
        set { _TieuDe = value; }
    }
    private string _NoiDung;
    public string NoiDung
    {
        get { return _NoiDung; }
        set { _NoiDung = value; }
    }
    public NoiDungEmailDTO()
	{
        MaMail = -1;
        Username = "";
        Email = "";
        NgayGui = DateTime.Now;
        TieuDe = "";
        NoiDung = "";
		//
		// TODO: Add constructor logic here
		//
	}
}
