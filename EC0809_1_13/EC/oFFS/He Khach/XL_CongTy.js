// JScript File
function XL_CongTy()
{
    this.TenCongTy = "";
    this.DienThoai = "";
    this.DienThoaiAdmin = "";
    this.DiaChi = "";
    this.Logo = "";
    this.Banner = "";
    this.MoTa = "";
}

function XL_CongTy.radLogo1_change()
{
    if(document.getElementById("radLogo1").checked == false)
    {
        document.getElementById("radLogo1").checked = true;
        document.getElementById("txtLogo1").value = "";
        document.getElementById("txtLogo1").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload2").disabled = false;
        document.getElementById("radLogo2").checked = false;
    }
}

function XL_CongTy.radLogo2_change()
{
    if(document.getElementById("radLogo2").checked == false)
    {  
        document.getElementById("radLogo2").checked = true;      
        document.getElementById("radLogo1").checked = false;
        document.getElementById("txtLogo1").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload2").disabled = true;
    }
}

function XL_CongTy.radBanner1_change()
{
    if(document.getElementById("radBanner1").checked == false)
    {
        document.getElementById("radBanner1").checked = true;
        document.getElementById("txtBanner").value = "";
        document.getElementById("txtBanner").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload3").disabled = false;
        document.getElementById("radBanner2").checked = false;
    }
}

function XL_CongTy.radBanner2_change()
{
    if(document.getElementById("radBanner2").checked == false)
    {  
        document.getElementById("radBanner2").checked = true;      
        document.getElementById("radBanner1").checked = false;
        document.getElementById("txtBanner").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload3").disabled = true;
    }
}

function XL_CongTy.HienThiThongTin()
{
    var CT = new XL_CongTy();
        
    CT = ThongTinCongTy();
    
    document.getElementById("LabTenCongTy").innerText = CT.TenCongTy;
    document.getElementById("LabDienThoai").innerText = CT.DienThoai;
    document.getElementById("LabDienThoaiAdmin").innerText = CT.DienThoaiAdmin;
    document.getElementById("LabDiaChi").innerText = CT.DiaChi;
    document.getElementById("picLogo").src = CT.Logo;
    document.getElementById("picBanner").src = CT.Banner;
    document.getElementById("LabMoTa").innerText = CT.MoTa;
}

function XL_CongTy.HienThiThongTinLienHe()
{
    var CT = new XL_CongTy();
        
    CT = ThongTinCongTy();
    
    document.getElementById("div_ten_cong_ty").innerText = CT.TenCongTy;
    document.getElementById("div_dia_chi").innerText = CT.DiaChi;
    document.getElementById("div_dien_thoai").innerText = CT.DienThoai;    
}

function XL_CongTy.HienThiCapNhat()
{
    var CT = new XL_CongTy();
    
    CT = ThongTinCongTy();
    
    document.getElementById("txtTenCongTy").value = CT.TenCongTy;
    document.getElementById("txtDienThoai").value = CT.DienThoai;
    document.getElementById("txtDienThoaiAdmin").value = CT.DienThoaiAdmin;
    document.getElementById("txtDiaChi").value = CT.DiaChi;
    document.getElementById("picLogo").src = CT.Logo;
    document.getElementById("picBanner").src = CT.Banner;
    //LabLogo.Text = Ct.Logo;
    //LabBanner.Text = Ct.Banner;
    document.getElementById("txtMoTa").value = CT.MoTa;
}

function ThongTinCongTy()
{
    var CT = new XL_CongTy();
    var Ham = new XL_HAM("He Phuc Vu/XL_CongTy");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Thong_Tin_Cong_Ty");
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {  
        CT.TenCongTy = Goc.getAttribute("Ten_cong_ty");
        CT.DienThoai = Goc.getAttribute("Dien_thoai");
        CT.DienThoaiAdmin = Goc.getAttribute("Dien_thoai_admin");
        CT.DiaChi = Goc.getAttribute("Dia_chi");
        CT.Logo = Goc.getAttribute("Logo");
        CT.Banner = Goc.getAttribute("Banner");
        CT.MoTa = Goc.getAttribute("Mo_ta");        
    }
    
    return CT;
}
XL_CongTy.KiemTraDuLieuNhap = function(data, Th_kqKiemTra, type)
{
    if(data == "")
    {
        //alert(Th_kqKiemTra);
        document.getElementById(Th_kqKiemTra).innerText = "Invalid";
        }
    else if(type == 1)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_CongTy");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Kiem_Tra_Du_Lieu_Nhap");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Du_lieu_nhap", data);
        Ham.Danh_sach_tham_so.push(Tham_so);
        
        var Goc = Ham.Thuc_hien();
        if(Goc != null)        
            document.getElementById(Th_kqKiemTra).innerText = "Valid";
        else
            document.getElementById(Th_kqKiemTra).innerText = "Invalid";
    }
    else
        document.getElementById(Th_kqKiemTra).innerText = "Valid";
}

function XL_CongTy.CapNhatThongTin()
{
    if(document.getElementById("divTenCongTy").innerText == "Invalid" || document.getElementById("divDiaChi").innerText == "Invalid" || document.getElementById("divDienThoai").innerText == "Invalid" || document.getElementById("divDienThoaiAdmin").innerText == "Invalid" || document.getElementById("divMoTa").innerText == "Invalid")
    {
        alert("Thông Tin Không Hợp Lệ");
        return;
    }
    
    
    var logo = document.getElementById("txtLogo1").value;
    var Banner = document.getElementById("txtBanner").value;
    
    var CT = new XL_CongTy();
    var Ham = new XL_HAM("He Phuc Vu/XL_CongTy");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_Nhat_Thong_Tin");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ten_cong_ty", document.getElementById("txtTenCongTy").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Dien_thoai",document.getElementById("txtDienThoai").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Dien_thoai_admin",document.getElementById("txtDienThoaiAdmin").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Dia_chi",document.getElementById("txtDiaChi").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    if(logo != "")
    {
        Tham_so = new XL_THAM_SO("Logo", logo);
        Ham.Danh_sach_tham_so.push(Tham_so);   
    }
    if(Banner != "")       
    {
        Tham_so = new XL_THAM_SO("Banner", Banner);
        Ham.Danh_sach_tham_so.push(Tham_so);    
    }
    Tham_so = new XL_THAM_SO("Mo_ta",document.getElementById("txtMoTa").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {        
        alert("Cap nhat thanh cong");
    }
    
    return CT;        
}

function XL_CongTy.HienThiDuongDanFileLogo(gia_tri)
{
    document.getElementById("LabLogo").innerText = gia_tri;
}
function XL_CongTy.HienThiDuongDanFileBanner(gia_tri)
{
    document.getElementById("LabBanner").innerText = gia_tri;
}
