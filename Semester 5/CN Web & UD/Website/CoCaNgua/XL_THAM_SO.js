// JScript File
function XL_THAM_SO(Ten, Gia_tri)
{
    this.Ten = Ten;
    this.Gia_tri = Gia_tri;
}

// Xử lý kết xuất
XL_THAM_SO.prototype.Chuoi = function()
{
    var kq = new String();
    kq = this.Ten + "=";
    kq += this.Gia_tri;
    return kq;
}

function XL_THAM_SO.Chuoi_danh_sach(Danh_sach)
{
    var kq = new String();
    kq = "";
    for (var i = 0; i < Danh_sach.length; i++)
    {
        kq += Danh_sach[i].Chuoi();
        if (i < Danh_sach.length - 1)
            kq += "&";
    }
    return kq;
}