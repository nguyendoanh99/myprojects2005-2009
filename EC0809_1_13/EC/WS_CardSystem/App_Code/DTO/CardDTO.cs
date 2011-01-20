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
/// Summary description for CardDTO
/// </summary>
public class CardDTO
{
    #region "Attributes"
    private int _no;
    private string _owner;
    private string _code;    
    private DateTime _expried_date;
    private string _type;
    #endregion

    #region "Properties"
    public int No
    {
        get { return _no; }
        set { _no = value; }
    }
    public string Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }
    public string Code
    {
        get { return _code; }
        set { _code = value; }
    }
    public DateTime Expried_date
    {
        get { return _expried_date; }
        set { _expried_date = value; }
    }
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
    #endregion
}
