<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["LuotDi"] = 0; // Cho biet den phien ai
        Application["QUANLY"] = new QUANLY();   
        // Dung cho chat
        Application["DanhSachNoiDung"] = new ArrayList();
        Application["SoCauDaChat"] = 0;
        Application["CauLuuTruHienTai"] = 0; // hien dang luu cau thu bao nhieu     
    }

    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        // Dung cho chat
        Session["CauBatDau"] = Application["SoCauDaChat"]; // Cau bat dau chat la cau thu
        Session["SoCauDaLay"] = Application["SoCauDaChat"];
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        QUANLY ql = (QUANLY)Application["QUANLY"];
        int NguoiChoiThu = (int) Session["NguoiChoiThu"];
        if (NguoiChoiThu == -1) // Nguoi xem
            ql.SoNguoiXem--;
        
        // Dung cho chat
        Application.Lock();
        ArrayList lst = (ArrayList)Application["DanhSachNoiDung"];
        int CauLuuTruHienTai = (int)Application["CauLuuTruHienTai"];
        int SoCauDaChat = (int)Application["SoCauDaChat"];
        int SoCauDaLay = (int)Session["SoCauDaLay"];

        XL_THE The = new XL_THE("Goc");
        for (int i = Math.Max(SoCauDaLay, CauLuuTruHienTai); i < SoCauDaChat; ++i)
        {
            NoiDungChat ndc = (NoiDungChat)lst[i - CauLuuTruHienTai];
            String NoiDung = ndc.NoiDung;
            ndc.SoNguoiDungHienTai--;
        }
        Application.UnLock();
    }
       
</script>
