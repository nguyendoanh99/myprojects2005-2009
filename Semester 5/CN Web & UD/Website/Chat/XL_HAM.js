﻿// JScript File

function XL_HAM(Ten)
{
    this.Ten = Ten;
    this.Danh_sach_tham_so = new Array();
}

XL_HAM.URL = "http://localhost:49251/Chat";
XL_HAM.Kieu = ".aspx";

// Xử lý nghiệp vụ
XL_HAM.prototype.Thuc_hien = function()
{
    var kq = null;
    var Tai_lieu = new ActiveXObject("Microsoft.XMLDOM");
    Tai_lieu.async = false;
    
    var Tham_so = XL_THAM_SO.Chuoi_danh_sach(this.Danh_sach_tham_so);    
    Tai_lieu.load(encodeURI(XL_HAM.URL + "/" + this.Ten + XL_HAM.Kieu + "?" +Tham_so));
    
    if (Tai_lieu.xml != "")
        kq = Tai_lieu.documentElement;
        
    return kq;
}