// JScript File

function XL_NguoiDung()
{

}

function XL_NguoiDung.XacNhanCode(strCode)
{
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "XacNhanCode"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("code", strCode));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        if(goc.getAttribute("kq") == "true")
        {
           return "1";
        }
        else
            return "0";
    }
    else
         alert("Lỗi khi xác nhận mã bảo vệ");
    
}

function XL_NguoiDung.LoadCmbNum(nodename, canduoi, cantren)
{
    /*
    var t1 = SHA1("5101385022504098");
    var t2 = SHA1("5379576900039885");
    var t3 = SHA1("5570202807894424");
    var t4 = SHA1("5570074062441963");
    
    var t5 = SHA1("4024007159448371");
    var t7 = SHA1("4024007121975014");
    var t8 = SHA1("4916447367282223");
    var t9 = SHA1("4556642861273463");
    
    XL_The.KiemTraTheTonTai("MasterCard", t1, '21/12/2009');
    */
    
    var node = document.getElementById(nodename);
    
    for(var i = canduoi; i <= cantren; ++i)
    {
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = i;
        nodeOpt.value = i;
        node.appendChild(nodeOpt);
    }
}

function XL_NguoiDung.LoadLoaiThe(nodename)
{
    var nodeCmb = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiThe");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiThe"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        for(var i =0; i<M.length; i++)
        {
            var maloaithe = M[i].getAttribute("MaLoaiThe");
            var tenloaithe = M[i].getAttribute("TenLoaiThe");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenloaithe;
            nodeOpt.value = maloaithe;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load loại thẻ");
}

function XL_NguoiDung.LoadLoaiNguoiDung(nodename)
{
    var nodeCmb = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiNguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LoadDSLoaiNguoiDung"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        for(var i =0; i<M.length; i++)
        {
            var maloaithe = M[i].getAttribute("MaLoaiNguoiDung");
            var tenloaithe = M[i].getAttribute("TenLoaiNguoiDung");
            if(tenloaithe != "Khách hàng" && tenloaithe != "Người quản trị")
            {
                var nodeOpt = document.createElement("option");
                nodeOpt.innerHTML = tenloaithe;
                nodeOpt.value = maloaithe;
                nodeCmb.appendChild(nodeOpt);
            }
        }
    }
    else
        alert("Lỗi khi load loại người dùng");
}


function XL_NguoiDung.ThemKhachHang()
{  
    //Dùng hàm của file XL_DKTaiKhoan.js
    var Kq = "";
    Kq += KiemTraHoTen();
    //Kq += KiemTraDienThoai();
    Kq += KiemTraEmail();
    Kq += KiemTraAcc();
    Kq += KiemTraPass();
    
    var ThongBaoRePass = KiemTraRePass();
    Kq += KiemTraRePass();
    
    if(ThongBaoRePass == "")
    {
        var ctl = document.getElementById("errRePass");
		if(ctl.style.display != "none")
		{
			Kq += "Password nhập lại không chính xác\n";
		}
	}	
	
	var nodeMaThe = document.getElementById("txtMaThe");
	Kq += KiemTraMaThe(nodeMaThe);
	
	var strCode = document.getElementById("txtCode").value;
	
	var xn = XL_NguoiDung.XacNhanCode(strCode);
	if(xn == "0")
	    Kq += "Mã xác nhận không chính xác\n";
	
    if(Kq != "")
    {
        XL_CHUOI.Xuat(Kq);
        return;
    }
    
    
    var hoten = document.getElementById("txtHoTen").value;
    var ngay = document.getElementById("cmbNgaySinh").value;
    var thang = document.getElementById("cmbThangSinh").value;
    var nam = document.getElementById("cmbNamSinh").value;
    var date = ngay + "/" + thang + "/" + nam;
  
    var gioitinh = (document.getElementById("optNam").checked == true);
    var diachi = document.getElementById("txtDiaChi").value;
    var dienthoai = document.getElementById("txtDienThoai").value;
    var email = document.getElementById("txtEmail").value;
    
    var username = document.getElementById("txtAcc").value;
    var password = document.getElementById("txtPass").value;
    var hashPass = SHA1(password);
    
    
    var cmbLoaiTheIndex = document.getElementById("cmbLoaiThe").selectedIndex;
    var loaithe = document.getElementById("cmbLoaiThe")[cmbLoaiTheIndex].value;
    var tenloaithe = document.getElementById("cmbLoaiThe")[cmbLoaiTheIndex].innerHTML;
    
    
    var hashMaThe = SHA1(nodeMaThe.value);
    
    var ngayHH = document.getElementById("cmbNgayHH").value;
    var thangHH = document.getElementById("cmbThangHH").value;
    var namHH = document.getElementById("cmbNamHH").value;
    var dateHH = ngayHH + "/" + thangHH + "/" + namHH;
    
    if(XL_The.KiemTraTheTonTai(tenloaithe, hashMaThe, dateHH) == 0)
    {
        XL_CHUOI.Xuat("Thẻ tín dụng không có thực hoặc đã hết hạn");
        return;
    }
    
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemKhachHang"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hoten", hoten));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("date", date));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("gioitinh", gioitinh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("diachi", diachi));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("dienthoai", dienthoai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("email", email));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("username", username));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("password", hashPass));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("loaithe", loaithe));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mathe", hashMaThe));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("dateHH", dateHH));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null)
    {
        if(goc.getAttribute("kq") == "true")
            XL_CHUOI.Xuat("Đăng ký thành công!");
        else if(goc.getAttribute("kq") == "false")
            XL_CHUOI.Xuat("Tài khoản đã có người sử dụng!");
        else if(goc.getAttribute("kq") == "error")
            XL_CHUOI.Xuat("Lỗi trong quá trình đăng ký!");
    }
    else
        XL_CHUOI.Xuat("Lỗi trong quá trình đăng ký!");
}


function ThemTaiKhoan() //Nhân viên, quản lý
{
    //Dùng hàm của file XL_DKTaiKhoan.js
    var Kq = "";
    Kq += KiemTraHoTen();
    //Kq += KiemTraDienThoai();
    Kq += KiemTraEmail();
    Kq += KiemTraAcc();
    Kq += KiemTraPass();
    Kq += KiemTraRePass();
    
    var ThongBaoRePass = KiemTraRePass();
    Kq += KiemTraRePass();
    if(ThongBaoRePass == "")
    {
         var ctl = document.getElementById("errRePass");
		if(ctl.style.display != "none")
		{
			Kq += "Password nhập lại không chính xác\n";
		}
	}	
    if(Kq != "")
    {
        XL_CHUOI.Xuat(Kq);
        return;
    }
    
    var cmbLoaiIndex = document.getElementById("cmbLoaiNguoiDung").selectedIndex;
    var loai = document.getElementById("cmbLoaiNguoiDung")[cmbLoaiIndex].value;
    var tenloai = document.getElementById("cmbLoaiNguoiDung")[cmbLoaiIndex].innerHTML;
    
    var hoten = document.getElementById("txtHoTen").value;
    
    var ngay = document.getElementById("cmbNgaySinh").value;
    var thang = document.getElementById("cmbThangSinh").value;
    var nam = document.getElementById("cmbNamSinh").value;
    var date = ngay + "/" + thang + "/" + nam;
  
    var gioitinh = (document.getElementById("optNam").checked == true);
    var diachi = document.getElementById("txtDiaChi").value;
    var dienthoai = document.getElementById("txtDienThoai").value;
    var email = document.getElementById("txtEmail").value;
    var kichhoat = document.getElementById("optKichHoat").checked == true;
    
    var username = document.getElementById("txtAcc").value;
    var password = document.getElementById("txtPass").value;
    var hashPass = SHA1(password);
    
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "TaoTaiKhoan"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("loai", loai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hoten", hoten));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("date", date));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("gioitinh", gioitinh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("diachi", diachi));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("dienthoai", dienthoai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("email", email));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("kichhoat", kichhoat));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("username", username));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("password", hashPass));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "true")
    {
        XL_CHUOI.Xuat("Thêm thành công!");
        
        var nodeFieldSetDS = document.getElementById("fsDSNguoiDung");
        nodeFieldSetDS.style.display = "block";
        
        var nodeTbody = document.getElementById("tbodyDSNguoiDung");
        var nodeNewRow = document.createElement("tr");
        
        var nodeColSTT = document.createElement("td");
        var nodeColLoai = document.createElement("td");
        var nodeColHoTen = document.createElement("td");
        var nodeColUsername = document.createElement("td");
        var nodeColEmail = document.createElement("td");
        var nodeColKichHoat = document.createElement("td");
        
        nodeColSTT.innerHTML = tbodyDSNguoiDung.rows.length;
        nodeColLoai.innerHTML = tenloai;
        nodeColHoTen.innerHTML = hoten;
        nodeColUsername.innerHTML = username;
        nodeColEmail.innerHTML = email;
        
        var nodeHinh = document.createElement("img");
        if(kichhoat == true)
            nodeHinh.src = "Hinh Anh/Linh Tinh/tick.png";
        else
            nodeHinh.src = "Hinh Anh/Linh Tinh/publish_x.png";
            
        nodeColKichHoat.appendChild(nodeHinh);
        
        nodeNewRow.appendChild(nodeColSTT);
        nodeNewRow.appendChild(nodeColLoai);
        nodeNewRow.appendChild(nodeColHoTen);
        nodeNewRow.appendChild(nodeColUsername);
        nodeNewRow.appendChild(nodeColEmail);
        nodeNewRow.appendChild(nodeColKichHoat);
        
        nodeTbody.appendChild(nodeNewRow);
    }
    else
        XL_CHUOI.Xuat("Tài khoản đã có người sử dụng!");
}

function Thoat()
{
    var Ham = new XL_HAM("He phuc vu/XL_NguoiDung");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Thoat");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Ham.Thuc_hien();
    var goc = Ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "true")
    {
        window.location = "index.aspx";
    }
    
    
}

 function XL_NguoiDung.HashPass()
{
    var strPass = document.getElementById("txtPass").value;
    nodeHiddenPass.value = SHA1(strPass);
}

function CapNhatThongTinMatKhau(loaiyeucau)
{
    var mkcu = document.getElementById("txt_MatKhauHT").value;
    var mkmoi = document.getElementById("txt_MatKhauM").value;
    var mknl = document.getElementById("txt_MatKhauMNL").value;
    
    var kt = "";
    if(mkcu == "" || mkmoi == "" || mknl == "")
        kt += "Chưa nhập đủ thông tin\n";
    if(mkmoi != mknl)
        kt += "Mật khẩu nhập lại không đúng";
    
    if (kt != "")
    {
        alert(kt);
        return;
    }
    
    mkcu = SHA1(mkcu);
    mkmoi = SHA1(mkmoi);
    
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
    if(loaiyeucau == 0)
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan", "CapNhatThongTinMatKhau"));
    else if (loaiyeucau == 1)
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan", "NVCapNhatThongTinMatKhau"));
        
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mkcu", mkcu));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mkmoi", mkmoi));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "True")
        XL_CHUOI.Xuat("Cập nhật thành công!");
    else
        XL_CHUOI.Xuat("Cập nhật bị lỗi!");
}

function CapNhatThongTinCaNhan(loaiyeucau)
{
    var hoten = nodeHoTen.value;
    var ngaysinh = nodeNgaySinh.value + "/" + nodeThangSinh.value + "/" + nodeNamSinh.value;
    
    var gioitinh;
    if(nodeGioiTinhNam.checked == true)
        gioitinh = "false";
    else
        gioitinh = "true";
        
    var diachi = nodeDiaChi.value
    var dienthoai= nodeDienThoai.value
    var email = nodeEmail.value
    
    
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
    if (loaiyeucau == 0)
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan", "CapNhatThongTinCaNhan"));
    else if (loaiyeucau == 1)
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan", "NVCapNhatThongTinCaNhan"));
        
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hoten", hoten));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngaysinh", ngaysinh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("gioitinh", gioitinh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("diachi", diachi));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("dienthoai", dienthoai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("email", email));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "True")
        XL_CHUOI.Xuat("Cập nhật thành công!");
    else
        XL_CHUOI.Xuat("Cập nhật bị lỗi!");
}

function CapNhatThongTinTheTinDung()
{   
    var index = nodeLoaiThe.selectedIndex;
    var maloaithe = nodeLoaiThe[index].value;
    var tenloaithe = nodeLoaiThe[index].innerHTML;
    
    var sothe = nodeSoThe.value;
    var kq = KiemTraMaThe(nodeSoThe)
    if(kq != "")
    {
        alert(kq);
        return;
    }
    
    var hashSoThe = SHA1(sothe);
    
    var ngayhh = nodeNgayHH.value
    var thanghh = nodeThangHH.value;
    var namhh = nodeNamHH.value;
    
    var date = ngayhh + "/" + thanghh + "/" + namhh;
    
    if(XL_The.KiemTraTheTonTai(tenloaithe, hashSoThe, date) == 0)
    {
        XL_CHUOI.Xuat("Thẻ tín dụng không có thực hoặc đã hết hạn");
        return;
    }
    
    var ham = new XL_HAM("He Phuc Vu/XL_NguoiDung");
     ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan", "CapNhatThongTinTheTinDung"));
     ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("maloaithe", maloaithe));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tenloaithe", tenloaithe));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("sothe", hashSoThe));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngayhh", date));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "True")
        XL_CHUOI.Xuat("Cập nhật thành công!");
    else
        XL_CHUOI.Xuat("Cập nhật bị lỗi!");
}




    function KiemTraHoTen()
    {
        var nodeHT = document.getElementById("txtHoTen");
        if(nodeHT.value == "")
            return "Hãy nhập họ tên\n";
        return "";    
    }
    
    function KiemTraDiaChi()
    {
        var nodeDC = document.getElementById("txtDiaChi");
        if(nodeDC.value == "")
            return "Hãy nhập địa chỉ\n";
        return "";
    }
    
   
    function KiemTraDienThoai()
    {
        var Kq = "";
        var nodeDT = document.getElementById("txtDienThoai");
        
        if(nodeDT.value == "")
            Kq += "Hãy nhập điện thoại\n";
        else
         {      
            if(isNaN(nodeDT.value))
                Kq += "Điện thoại phải là một dãy số\n";
        }
        return Kq;
    }
    
    function KiemTraEmail()
    {
        var Kq = "";
        var nodeEmail = document.getElementById("txtEmail");
      
        arrEmail = nodeEmail.value.split("@");
        if(arrEmail.length != 2)
            Kq += "Địa chỉ email không hợp lệ\n";
            
        return Kq;    
    }
    
    function KiemTraPass()
    {
        var nodePass = document.getElementById("txtPass");
        if(nodePass.value == "")
            return "Hãy nhập password\n";
        else if(nodePass.value.length < 4)
            return "Password ít nhất 4 kí tự";
        return "";
    }
    
    function KiemTraRePass()
    {
        var nodeRePass = document.getElementById("txtRePass");
        if(nodeRePass.value == "")
            return "Hãy nhập lại password\n";
        return "";
    }
    
    function KiemTraAcc()
    {
        var nodeAcc = document.getElementById("txtAcc");
        if(nodeAcc.value == "")
            return "Hãy nhập tên đăng nhập\n";
        return "";
    }
    
    function KiemTraMaThe(nodeMaThe)
    {
        //var nodeMaThe = document.getElementById("txtMaThe");
        if(nodeMaThe.value == "")
            return "Hãy nhập mã thẻ\n";
        if(isNaN(nodeMaThe.value))
        {
            return "Mã thẻ là một dãy 16 số\n";
        }
        if(nodeMaThe.value.length != 16)
            return "Mã số thẻ phải đủ 16 kí tự\n";
            
        return "";
    }
    
    function txtRePass_onChange()
    {
	    var	txtPass = document.getElementById("txtPass");
	    var txtRePass = document.getElementById("txtRePass");
	    var errRePass = document.getElementById("errRePass");
	    
	    if(txtPass.value != txtRePass.value)
		    errRePass.style.display = "inline";
	    else
		    errRePass.style.display = "none";
    }
 