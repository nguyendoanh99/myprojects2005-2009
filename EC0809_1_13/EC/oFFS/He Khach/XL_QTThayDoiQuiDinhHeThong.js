// JScript File
var flagGiaTriDiemSo = true;
var flagDiemKhachHangThanThiet = true;
var flagTiLeGiamGiaThucDon = true;
var flagThue = true;
var flagGiaTriDoiDiemKhuyenMai = true;
var flagGioiHanDoiDiemKhuyenMai = true;
function KiemTraDuLieu(obj, idError, min, max)
{
    var value = obj.value;
    var kq = CheckNumber(value, min, max);
    
    var objError = document.getElementById(idError);
    if (kq != "")
        objError.innerHTML = "(" + kq + ")";    
    else 
        objError.innerHTML = "";    
   
    return kq;
}
function CapNhatButLuu()
{
    var but = document.getElementById("butLuu");
    but.disabled = !(flagGiaTriDiemSo && flagDiemKhachHangThanThiet && flagTiLeGiamGiaThucDon
        && flagThue && flagGiaTriDoiDiemKhuyenMai && flagGioiHanDoiDiemKhuyenMai);
}
function OnChange(obj)
{   
    var idError = "E" + obj.id.substring(2, obj.id.length);
    
    if (obj.id == "idGiaTriDiemSo") 
        flagGiaTriDiemSo = KiemTraDuLieu(obj, idError, 1000, 1000000) == '';
    else if (obj.id == "idDiemKhachHangThanThiet") 
        flagDiemKhachHangThanThiet = KiemTraDuLieu(obj, idError, 0, 1000) == '';
    else if (obj.id == "idTiLeGiamGiaThucDon") 
        flagTiLeGiamGiaThucDon = KiemTraDuLieu(obj, idError, 0, 99) == '';
    else if (obj.id == "idThue") 
        flagThue = KiemTraDuLieu(obj, idError, 0, 99) == '';
    else if (obj.id == "idGiaTriDoiDiemKhuyenMai") 
        flagGiaTriDoiDiemKhuyenMai = KiemTraDuLieu(obj, idError, 1000, 100000) == '';
    else if (obj.id == "idGioiHanDoiDiemKhuyenMai") 
        flagGioiHanDoiDiemKhuyenMai = KiemTraDuLieu(obj, idError, 0, 99) == '';
    
    CapNhatButLuu();
}

function LoadData()
{
    var ham = new XL_HAM("He phuc vu/XL_QTThayDoiQuiDinhHeThong");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "LayThamSo"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var giaTriDiemSo = goc.getAttribute("GiaTriDiemSo");
        var diemKhachHangThanThiet = goc.getAttribute("DiemKhachHangThanThiet");
        var tiLeGiamGiaThucDon = goc.getAttribute("TiLeGiamGiaThucDon");
        var thue = goc.getAttribute("Thue");
        var giaTriDoiDiemKhuyenMai = goc.getAttribute("GiaTriDoiDiemKhuyenMai");
        var gioiHanDoiDiemKhuyenMai = goc.getAttribute("GioiHanDoiDiemKhuyenMai");
        
        var idGiaTriDiemSo = document.getElementById("idGiaTriDiemSo");
        var idDiemKhachHangThanThiet = document.getElementById("idDiemKhachHangThanThiet");
        var idTiLeGiamGiaThucDon = document.getElementById("idTiLeGiamGiaThucDon");
        var idThue = document.getElementById("idThue");
        var idGiaTriDoiDiemKhuyenMai = document.getElementById("idGiaTriDoiDiemKhuyenMai");
        var idGioiHanDoiDiemKhuyenMai = document.getElementById("idGioiHanDoiDiemKhuyenMai");        
        
        idGiaTriDiemSo.value = giaTriDiemSo;
        idDiemKhachHangThanThiet.value = diemKhachHangThanThiet;
        idTiLeGiamGiaThucDon.value = tiLeGiamGiaThucDon;
        idThue.value = thue;
        idGiaTriDoiDiemKhuyenMai.value= giaTriDoiDiemKhuyenMai;
        idGioiHanDoiDiemKhuyenMai.value = gioiHanDoiDiemKhuyenMai;        
    }
    else
        alert("Lỗi đường truyền");
}
function Luu()
{
    var GiaTriDiemSo = document.getElementById("idGiaTriDiemSo").value;
    var DiemKhachHangThanThiet = document.getElementById("idDiemKhachHangThanThiet").value;
    var TiLeGiamGiaThucDon = document.getElementById("idTiLeGiamGiaThucDon").value;
    var Thue = document.getElementById("idThue").value;
    var GiaTriDoiDiemKhuyenMai = document.getElementById("idGiaTriDoiDiemKhuyenMai").value;
    var GioiHanDoiDiemKhuyenMai = document.getElementById("idGioiHanDoiDiemKhuyenMai").value;        
    
    var ham = new XL_HAM("He phuc vu/XL_QTThayDoiQuiDinhHeThong");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "LuuThamSo"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("GiaTriDiemSo", GiaTriDiemSo));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("DiemKhachHangThanThiet", DiemKhachHangThanThiet));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("TiLeGiamGiaThucDon", TiLeGiamGiaThucDon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("Thue", Thue));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("GiaTriDoiDiemKhuyenMai", GiaTriDoiDiemKhuyenMai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("GioiHanDoiDiemKhuyenMai", GioiHanDoiDiemKhuyenMai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    if (goc != null)
    {
        var flag = parseInt(goc.getAttribute("kq"));
        if (flag == 0)
            alert("Không thực hiện được do lỗi server");
        else
            alert("Các qui định của hệ thống đã được cập nhật");
    }
    else
        alert("Lỗi đường truyền");
}