<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
       

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occu//rs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
//         Session["CaptchaImageText"] = "";
         Session["User"] = null;         
         Session["LoaiNguoiDung"] = "";
         Session["MaNguoiDung"] = null;
         Session["FormDatHang"] = null;
         Session["FormDatHangDinhKy"] = null;
         Session["Gio_qua_tang"] = null;
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        Session["User"] = null;        
        Session["LoaiNguoiDung"] = null;
        Session["MaNguoiDung"] = null;
        Session["Gio_qua_tang"] = null;
        Session["FormDatHang"] = null;
        Session["FormDatHangDinhKy"] = null;
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
       
</script>
