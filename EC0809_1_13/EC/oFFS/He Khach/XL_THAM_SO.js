// JScript File
function XL_THAM_SO(Ten,Gia_tri)
{
    this.Ten = Ten;
    this.Gia_tri = Gia_tri;
}
XL_THAM_SO.prototype.Chuoi=function()
{
    var Kq = new String();
    Kq = this.Ten + "=";
    Kq +=this.Gia_tri;
    return Kq;
}
function XL_THAM_SO.Chuoi_danh_sach(Danh_sach)
{
    var Kq = new String();
    Kq = "";
    for(var i = 0;i<Danh_sach.length;i++)
        {
            Kq +=Danh_sach[i].Chuoi();
            if(i<Danh_sach.length - 1)
                Kq+="&";
        }
    return Kq;
}   
