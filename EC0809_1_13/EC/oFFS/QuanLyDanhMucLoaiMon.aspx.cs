using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class QuanLyDanhMucLoaiMon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["LoaiNguoiDung"] != "QuanTri" && Session["LoaiNguoiDung"] != "NhanVien")
        //{
            //Response.Redirect("ErrorPage.aspx");
        //}

        //LoadDanhSachLoaiMon();
    }
    /*
    protected void LoadDanhSachLoaiMon()
    {
        LoadLoaiMonDeQui(-1, 0);
    }
    
    private void LoadLoaiMonDeQui(int MaLMCha, int cap)
    {
        LoaiMonDTO[] dsloaimoncon = new LoaiMonBUS().DanhSachLoaiMonCon(MaLMCha);

        foreach (LoaiMonDTO lmDto in dsloaimoncon)
        {
            string chuoi = "";
            for (int i = 0; i < cap; i++)
                chuoi += "___";
            chuoi += lmDto.Ten_loai_mon;

            HtmlTableRow row = new HtmlTableRow();
            tab.Rows.Add(row);

            int k = tab.Rows.Count-1;
            for (int i = 0; i < 6; i++)
            {
                HtmlTableCell cell = new HtmlTableCell();
                tab.Rows[k].Cells.Add(cell);
            }

            tab.Rows[k].Cells[0].InnerHtml = k.ToString();
            tab.Rows[k].Cells[1].InnerText = lmDto.Ma_loai_mon.ToString();
            tab.Rows[k].Cells[2].InnerHtml = chuoi;//"<div id=div_Ten class=formlm> <a href=ThemLoaiMonMoi.aspx>" + chuoi + "</a> </div>"; 
            tab.Rows[k].Cells[3].InnerHtml = lmDto.La_loai_mon_la.ToString();

            //neu la mon la, hien thi so luong mon con
            int somoncon = -1;
            if(lmDto.La_loai_mon_la == true)    
            {
                somoncon = new MonAnBUS().TinhSoLuongMonAnThuocLoaiMon(lmDto.Ma_loai_mon);
                tab.Rows[k].Cells[4].InnerHtml = "<div id=div_HT class=formlm> <a href=CapNhatThongTinMatKhau.aspx>[" + somoncon.ToString() + "]</a> </div>";
            }
            else
                tab.Rows[k].Cells[4].InnerHtml = "-";
             
            int maloaimon = lmDto.Ma_loai_mon;
            bool lamonla = lmDto.La_loai_mon_la;
            int kthople = 1;
            //khong cho xoa loai mon ko phai la or loai mon la nhung co chua mon con
            if (lamonla == false || somoncon != 0)  
                kthople = 0;
            tab.Rows[k].Cells[5].InnerHtml = "<div id=div_Xoa class=formlm> <a onclick=XoaLoaiMon(" + maloaimon + "," + kthople + ")>[Xóa]</a> </div>";

            cap++;
            LoadLoaiMonDeQui(lmDto.Ma_loai_mon, cap);
            cap--;
        }
    }
     */
}
