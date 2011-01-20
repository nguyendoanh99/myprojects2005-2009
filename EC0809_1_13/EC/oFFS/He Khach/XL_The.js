// JScript File


function XL_The()
{
    //this.LoaiThe = "";
    //this.SoThe = "";
    //this.NgayHetHan = "";
}
/*
function XL_The.LayTheKhachHang()
{
    var Ham = new XL_HAM("He phuc vu/XL_The");
    var Tham_so = new XL_THAM_SO("Xac_nhan","LayTheKhachHang");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
   
    var Goc = Ham.Thuc_hien();
    var the = new XL_The();
    if(Goc != null)
    {        
        the = XL_The.Khoi_tao_the(Goc)
    }
    else
    {
        return;
    }
    
}

function XL_The.Khoi_tao_the(Nut)
{
    var the = new XL_The();
    var M = Nut.childNodes;
    //alert(M.length);
    for(var i =0; i<M.length; i++)
    {       
        the.LoaiThe = M[i].getAttribute("Ma_mon") 
        gh.TenMon = M[i].getAttribute("Ten_mon");
	    gh.SoLuong = M[i].getAttribute("So_luong") ;
	    gh.Gia = M[i].getAttribute("Gia") ;
	    gh.TongGiaMonAn = M[i].getAttribute("Tong_gia_tri_mon_an") ;
	        
        the.push(gh);
    }
    TongSoItems = M[i]. getAttribute("TongSoItem") ;
    TongGiaTri = M[i + 1]. getAttribute("TongGiaTri") ;    
    return the;
}
*/
function XL_The.KiemTraTheTonTai(tenloaithe, sothe, ngayhethan)
{
    var Ham = new XL_HAM("He phuc vu/XL_The");
    var Tham_so = new XL_THAM_SO("Xac_nhan","KiemTraTheTonTai");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("tenloaithe", tenloaithe));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("sothe", sothe));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngayhethan", ngayhethan));
    
    Ham.Danh_sach_tham_so.push(Tham_so);
    Ham.Thuc_hien();
    var goc = Ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "true")
    {
        return 1;
    }
    else
    {
        //alert("Thẻ tín dụng không có thực hoặc đã hết hạn");
        return 0;
    }
    
}