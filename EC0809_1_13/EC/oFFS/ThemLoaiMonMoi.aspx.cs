using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ThemLoaiMonMoi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["LoaiNguoiDung"] != "QuanLy" && Session["LoaiNguoiDung"] != "NhanVien")
       // {
            //Response.Redirect("ErrorPage.aspx");
        //}
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript1(), true);
        LoadLoaiMonCha();
    }

    //private string GetJavaScript1()
    //{
    //    StringBuilder JavaScript = new StringBuilder();

    //    JavaScript.Append("<script type='text/javascript'>");
    //    JavaScript.AppendFormat("var tenloaimon = document.getElementById('{0}');\n", txtTenLoaiMon.ClientID);
    //    JavaScript.AppendFormat("var maloaimoncha = document.getElementById('{0}');\n", cmbLoaiMonCha.ClientID);
    //    JavaScript.AppendFormat("var laloaimonla = document.getElementById('{0}');\n", optLa.ClientID);
    //    JavaScript.Append("</script>");

    //    return JavaScript.ToString();
    //}

    public void LoadLoaiMonCha()
    {
        cmbLoaiMonCha.Items.Clear();

        cmbLoaiMonCha.Items.Add("Mặc định - Là loại món gốc");
        cmbLoaiMonCha.Items[0].Value = "-1";

        LoadLoaiMonDeQui(-1, 0);
    }

    private void LoadLoaiMonDeQui(int MaLMCha, int cap)
    {
        LoaiMonDTO[] dsloaimoncon = new LoaiMonBUS().DanhSachLoaiMonCon(MaLMCha);
       
        foreach (LoaiMonDTO lmDto in dsloaimoncon)
        {
            if (lmDto.La_loai_mon_la == false)   // chi hiển thị những loại món không là loại món lá
            {
                string chuoi = "";
                for (int i = 0; i < cap; i++)
                    chuoi += "___";
                chuoi += lmDto.Ten_loai_mon;

                cmbLoaiMonCha.Items.Add(chuoi);
                cmbLoaiMonCha.Items[cmbLoaiMonCha.Items.Count-1].Value = lmDto.Ma_loai_mon.ToString();

                cap++;
                LoadLoaiMonDeQui(lmDto.Ma_loai_mon, cap);
                cap--;
            }
        }
    }
}
