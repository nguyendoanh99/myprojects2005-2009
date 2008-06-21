using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxRoundPanel;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    void ChangeTheme(ControlCollection cc, string strCssFilePath, string strCssPostfix)
    {
        foreach (Control control in cc)
        {
            ASPxWebControl Webcontrol = control as ASPxWebControl;
            if (Webcontrol != null)
            {                
                Webcontrol.CssFilePath = strCssFilePath;
                Webcontrol.CssPostfix = strCssPostfix;
                ASPxPageControl temp = control as ASPxPageControl;
                if (temp != null)
                {
                    //ASPxPageControl1.TabPages[0].Controls
                    foreach (TabPage tp in temp.TabPages)
                    {
                        ChangeTheme(tp.Controls, strCssFilePath, strCssPostfix);
                    }
                    
                }
                else
                {
                    ASPxPanelBase temp2 = control as ASPxPanelBase;
                    if (temp2 != null)
                        ChangeTheme(temp2.Controls, strCssFilePath, strCssPostfix);
                }
            }
        }
    }
    protected void ASPxMenu1_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
    {
        string strCssFilePath = "";
        string strCssPostfix = "";
        switch (e.Item.Name)
        {
            case "BlackGlass":
                strCssFilePath="~/App_Themes/BlackGlass/{0}/styles.css";
                strCssPostfix="BlackGlass";
                break;
            case "Blue":
                strCssFilePath="~/App_Themes/Blue/{0}/styles.css";
                strCssPostfix="Blue";
                break;
            case "Glass":
                strCssFilePath="~/App_Themes/Glass/{0}/styles.css";
                strCssPostfix="Glass";
                break;
            case "Office2003Blue":
                strCssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css";
                strCssPostfix="Office2003_Blue";
                break;
            case "Office2003Olive":
                strCssFilePath = "~/App_Themes/Office2003 Olive/{0}/styles.css";
                strCssPostfix="Office2003_Olive";
                break;
            case "Office2003Silver":
                strCssFilePath="~/App_Themes/Office2003 Silver/{0}/styles.css";
                strCssPostfix="Office2003_Silver";
                break;
            case "PlasticBlue":
                strCssFilePath="~/App_Themes/Plastic Blue/{0}/styles.css"; 
                strCssPostfix="PlasticBlue";
                break;
            case "RedWine":
                strCssFilePath="~/App_Themes/Red Wine/{0}/styles.css";
                strCssPostfix = "RedWine";
                break;
            case "SoftOrange":
                strCssFilePath="~/App_Themes/Soft Orange/{0}/styles.css";
                strCssPostfix = "Soft_Orange";
                break;
            case "Youthful":
                strCssFilePath = "~/App_Themes/Youthful/{0}/styles.css";
                strCssPostfix = "Youthful";
                break;
            default:
                return;
        }
        ChangeTheme(this.Form.Controls, strCssFilePath, strCssPostfix);       
    }
}
