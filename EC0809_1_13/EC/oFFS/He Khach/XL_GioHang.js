// JScript File

function XL_GIO_HANG()
{
} 
function Gio_hang()
{
	this.MaMon = "";
	this.TenMon = "";
	this.SoLuong = 0;
	this.Gia = 0;
	this.TongGiaMonAn = 0;
}

var TongGiaTri = 0;
var TongSoItems = 0;
function XL_GIO_HANG.Lay_ds_checked()
{
    var parent = document.getElementById("th_detail");
    var arr = new Array();
    var i = 1;
    
    if(parent == null)
        return;
        
    //lay danh sach cac item muon xoa
    var child = parent.firstChild.nextSibling;
    while(child && i<= TongSoItems)
    {
        var checkNode = document.getElementById("item " + i);        
        if(checkNode.checked == true)
        {
            var m = checkNode.parentNode.nextSibling.firstChild.nodeValue;
            arr.push(m);
        }
            
        i++;
        child = child.nextSibling;
    }
    
    return arr;
}

function XL_GIO_HANG.Cap_nhat_tien()
{
    var parent = document.getElementById("th_detail");
    var arr = new Array();
    var i = 1;
    
    if(parent == null)
        return;
        
    //lay danh sach cac item muon xoa
    var child = parent.firstChild.nextSibling;
    if(child.firstChild.innerHTML == "")
        return;
    while(child && i <= TongSoItems)
    {
        var checkNode = document.getElementById("item " + i);                
        var m = checkNode.parentNode.nextSibling.firstChild.nodeValue;
        var gh = new Gio_hang();
        gh.MaMon = m;
        m = checkNode.parentNode.nextSibling.nextSibling.nextSibling.firstChild.value;
        var oldvalue = checkNode.parentNode.nextSibling.nextSibling.nextSibling.firstChild.oldvalue;
        
        if(parseInt(m) <= 0)
        {
            alert("Số lượng phải lớn hơn 0");
            m = oldvalue;
        }
        
        gh.SoLuong = m;
        arr.push(gh);        
            
        i++;
        child = child.nextSibling;
    }
    
    return arr;
}

function Cap_nhat()
{    
    //cap nhat danh sach cac item muon xoa
    var arr = XL_GIO_HANG.Lay_ds_checked();
    var Goc = null;
    for(var i = 0; i < arr.length; i++)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Xoa_khoi_gio_hang");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ma_mon_an", arr[i]);
        Ham.Danh_sach_tham_so.push(Tham_so);

        Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_GIO_HANG.Them();
        XL_GIO_HANG.Th_Thong_tin_chinh_gio_hang();
    }
    
    //tinh lai tien cac mon an khi khach hang co cap nhat lai so luong mua
    arr = XL_GIO_HANG.Cap_nhat_tien();
    
    for(var i = 0; i < arr.length; i++)
    {
        var gh = new Gio_hang();
        gh = arr[i];
        var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_nhat_tien");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ma_mon_an", gh.MaMon);
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("So_luong", gh.SoLuong);
        Ham.Danh_sach_tham_so.push(Tham_so);

        var Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_GIO_HANG.Them();
        XL_GIO_HANG.Th_Thong_tin_chinh_gio_hang();
    }
}

function Cap_nhat_qua_tang()
{    
    //cap nhat danh sach cac item muon xoa
    var arr = XL_GIO_HANG.Lay_ds_checked();
    var Goc = null;
    for(var i = 0; i < arr.length; i++)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Xoa_khoi_gio_qua_tang");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ma_mon_an", arr[i]);
        Ham.Danh_sach_tham_so.push(Tham_so);

        Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_GIO_HANG.ThemQuaTang();
    }
    
    //tinh lai tien cac mon an khi khach hang co cap nhat lai so luong mua
    arr = XL_GIO_HANG.Cap_nhat_tien();
    
    for(var i = 0; i < arr.length; i++)
    {
        var gh = new Gio_hang();
        gh = arr[i];
        var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_nhat_tien_qua_tang");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ma_mon_an", gh.MaMon);
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("So_luong", gh.SoLuong);
        Ham.Danh_sach_tham_so.push(Tham_so);

        var Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_GIO_HANG.ThemQuaTang();
    }
}


function XL_GIO_HANG.Ghi_nhan_dat_hang_mon_an()
{
    var obj = window.event.srcElement.parentNode;      
    var parent = obj.previousSibling;
    var so_luong = parent.firstChild.value;
    
    if(parseInt(so_luong) <= 0)
        so_luong = 1;
        
    parent = parent.previousSibling.previousSibling;
    var ma = parent.firstChild.nodeValue;
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_dat_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Loai", "0");    
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma", ma);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("So_luong", so_luong);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    //window.location.href = "AddToCard.aspx";
}

function XL_GIO_HANG.Ghi_nhan_dat_hang_thuc_don()
{
    var obj = window.event.srcElement.parentNode;      
    var parent = obj.previousSibling;
    var so_luong = parent.firstChild.value;
    
    if(parseInt(so_luong) <= 0)
        so_luong = 1;
        
    parent = parent.previousSibling.previousSibling;
    var ma = parent.firstChild.nodeValue;
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_dat_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Loai", "1");    
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma", ma);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("So_luong", so_luong);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    //window.location.href = "AddToCard.aspx";
}

function XL_GIO_HANG.Ghi_nhan_dat_hang_thuc_don_ca_nhan()
{
    var obj = window.event.srcElement.parentNode;      
    var parent = obj.previousSibling;
    var so_luong = parent.firstChild.value;
    
    if(parseInt(so_luong) <= 0)
        so_luong = 1;
        
    parent = parent.previousSibling.previousSibling;
    var ma = parent.firstChild.nodeValue;
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_dat_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Loai", "2");    
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma", ma);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("So_luong", so_luong);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    //window.location.href = "AddToCard.aspx";
}

function XL_GIO_HANG.Ghi_nhan_dat_hang_tu_chi_tiet()
{
    var obj = window.event.srcElement.parentNode;      
    var parent = obj.previousSibling;
    var so_luong = parent.firstChild.value;
    parent = parent.parentNode.parentNode.parentNode.parentNode.previousSibling.previousSibling.previousSibling;
    var ma = parent.firstChild.nodeValue;
    var m = ma.split(": ");
    ma = m[1];
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_dat_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Loai", "0");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma", ma);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("So_luong", so_luong);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    //window.location = "ChiTietMonAn.aspx";
}


function XL_GIO_HANG.Them()
{ 
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Them_vao_gio_hang");
    Ham.Danh_sach_tham_so.push(Tham_so); 
    var Goc = Ham.Thuc_hien();
    //if(Goc != null)
    //{
        XL_GIO_HANG.Th_Thong_tin_gio_hang(Goc)
    //}
}

function XL_GIO_HANG.ThemQuaTang()
{ 
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Them_vao_gio_qua_tang");
    Ham.Danh_sach_tham_so.push(Tham_so); 
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        XL_GIO_HANG.Th_Thong_tin_gio_qua_tang(Goc)
    }
}

function XL_GIO_HANG.Tinh_tien()
{
	var node;
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Tinh_tien");
    Ham.Danh_sach_tham_so.push(Tham_so);    

    var Goc = Ham.Thuc_hien();
}
///////////Giao dien/////////
function XL_GIO_HANG.Khoi_tao_gio_hang(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    //alert(M.length);
    for(var i =0;i<M.length - 2;i++)
    {
        var gh = new Gio_hang();
        
        gh.MaMon = M[i].getAttribute("Ma_mon") 
        gh.TenMon = M[i].getAttribute("Ten_mon");
	    gh.SoLuong = M[i].getAttribute("So_luong") ;
	    gh.Gia = M[i].getAttribute("Gia") ;
	    gh.TongGiaMonAn = M[i].getAttribute("Tong_gia_tri_mon_an") ;
	        
        Kq.push(gh);
    }
    TongSoItems = M[i]. getAttribute("TongSoItem") ;
    TongGiaTri = M[i + 1]. getAttribute("TongGiaTri") ;    
    return Kq;
}
function XL_GIO_HANG.Th_Thong_tin_gio_hang(Nut)
{
	var arr = new Array();

	var Th = document.getElementById("Th_Gio_hang");
    Th.innerHTML = "";
    var table = document.createElement("table");
    table.align = "center";
    table.id = "container";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    td.id = "main";
    td.className = "vt";
    
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tạo tiêu đề cho danh sách
    var h1 = document.createElement("h1");
    h1.appendChild(document.createTextNode("Thông Tin Giỏ Hàng"));    
    td.appendChild(h1);	

	var table2 = document.createElement("table");
    table2.width = "99%";
    table2.cellspacing = "1";
    table2.cellpadding = "1";
    table2.border = "0";   
	td.appendChild(table2);
    var tbody2 = document.createElement("tbody");
    tbody2.id = "th_detail";
    table2.appendChild(tbody2);
    var tr2 = document.createElement("tr");
    tr2.style.backgroundColor = "rgb(252, 252, 252)";
    tbody2.appendChild(tr2);
    td2 = document.createElement("td");
    td2.width = "10%";
    td2.appendChild(document.createTextNode("Xóa"));   
    td2.align = "center"; 
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "15%";
    td2.appendChild(document.createTextNode("Mã TĐ/Món"));   
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "30%";
    td2.appendChild(document.createTextNode("Tên Thực đơn/ Món"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "14%";
    td2.appendChild(document.createTextNode("Số Lượng"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "18%";
    td2.appendChild(document.createTextNode("Giá"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "18%";
    td2.appendChild(document.createTextNode("Tổng Giá"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    
    Th.appendChild(table);
    if(Nut != null)
    {
        arr = XL_GIO_HANG.Khoi_tao_gio_hang(Nut);
    //alert(arr.length);
 	    for(var i = 0; i < arr.length; i++)
	    {
	        //alert(i);
		    var gio_hang = new Gio_hang();
		    gio_hang = arr[i];
    		
		    tr2 = document.createElement("tr");
		    tbody2.appendChild(tr2);
            //tao checkbox
	        td2 = document.createElement("td");
	        td2.width = "10%";
	        td2.align = "center";
		    var checkNode = document.createElement("input");
            checkNode.type = "checkbox";
            //checkNode.width = "5%";
            checkNode.id = "item " + (i+1);
            td2.appendChild(checkNode);
            tr2.appendChild(td2);

		    //Ma Mon
	        td2 = document.createElement("td");
	        td2.width = "10%";
            td2.appendChild(document.createTextNode(gio_hang.MaMon));
            tr2.appendChild(td2);
            
            //Ten Mon
	        td2 = document.createElement("td");
	        td2.width = "35%";
            td2.appendChild(document.createTextNode(gio_hang.TenMon));
            tr2.appendChild(td2);
            
		    //So Luong
	        td2 = document.createElement("td");
	        td2.width = "14%";
            var input = document.createElement("input");
       	    input.className = "txtfield";
       	    input.type = "text";
            input.name = "quantity";
       	    input.value = gio_hang.SoLuong;
       	    input.oldvalue = gio_hang.SoLuong;  
      	    input.size = "3";
            input.maxlength = "4";
            td2.appendChild(input);
            tr2.appendChild(td2);

		    //Gia
	        td2 = document.createElement("td");
	        td2.width = "18%";
            td2.appendChild(document.createTextNode(gio_hang.Gia));
            tr2.appendChild(td2);

		    //Tong Gia
	        td2 = document.createElement("td");
	        td2.width = "18%";
            td2.appendChild(document.createTextNode(gio_hang.TongGiaMonAn));
            tr2.appendChild(td2);
        }

    }            

    tr2 = document.createElement("tr");
	tbody2.appendChild(tr2);
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");    
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");    
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);

    //tong gia tri
    td2 = document.createElement("td");
    td2.className = "menuhdr";
    td2.colSpan = 2;
    var span = document.createElement("span");
    span.style.color = "rgb(255, 0, 0)";
    span.appendChild(document.createTextNode("Tổng Giá Trị : " + TongGiaTri));
    td2.appendChild(span);
    tr2.appendChild(td2)
    
    tr2 = document.createElement("tr");
	tbody2.appendChild(tr2);
	
	td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "));
    tr2.appendChild(td2);     
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "));
    tr2.appendChild(td2);

    td2 = document.createElement("td");
    td2.className = "ar";
    td2.style.backgroundColor = "rgb(255, 255, 255)";
    tr2.appendChild(td2);    
    
    var table1 = document.createElement("table");
    table1.align = "left";
    td2.appendChild(table1);
    var tbody1 = document.createElement("tbody");
    table1.appendChild(tbody1);
    var tr1 = document.createElement("tr");
    tbody1.appendChild(tr1);
    
    var td1 = document.createElement("td");
    tr1.appendChild(td1);     
    var div = document.createElement("div");
    div.style.textAlign = "left";
    td1.appendChild(div);
    
    var form = document.createElement("form");
    form.mothod = "post";
    form.action = "DanhSachMonAn.aspx";
    div.appendChild(form);
        
    //button       
    var input = document.createElement("input");
    input.className = "nonsubmitbtn";
    input.type = "submit";
    input.name = "tieptuc";        
    input.value = "Tiếp Tục";         
    form.appendChild(input);

    td1 = document.createElement("td");
    tr1.appendChild(td1);        
    
    div = document.createElement("div");
    div.style.textAlign = "left";
    td1.appendChild(div);

    input = document.createElement("input");
    input.className = "nonsubmitbtn";
    input.type = "submit";
    input.name = "tinhlai";        
    input.value = "Cập Nhật";
    input.onclick =  Cap_nhat ;
    div.appendChild(input);        

    div = document.createElement("div");
    div.style.textAlign = "right";
    td.appendChild(div);
    
    form = document.createElement("form");
    form.method = "post";
    if(nodeLoaiND.value == "KhachHang")     
        form.action = "DatMuaSanPham_Customer.aspx";   
    else
        form.action = "DatMuaSanPham.aspx";   
    div.appendChild(form);
    

    var input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "checkout";        
    input.value = "Đặt Mua";
    if (TongGiaTri == 0)
        input.disabled = true;
    form.appendChild(input);
      
    if(nodeLoaiND.value == "KhachHang")     
    {
        form = document.createElement("form");
        form.method = "post";
        form.action = "DatMuaDinhKy.aspx";   
        div.appendChild(form);
    
        var input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "checkout";        
        input.value = "Đặt Hàng Định Kỳ";
        if (TongGiaTri == 0)
            input.disabled = true;
        form.appendChild(input);
    }
  //input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang ;    
}

function XL_GIO_HANG.Th_Thong_tin_gio_qua_tang(Nut)
{
	var arr = new Array();

	var Th = document.getElementById("Th_Gio_QT");
    Th.innerHTML = "";
    var table = document.createElement("table");
    table.align = "center";
    table.id = "container";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    td.id = "main";
    td.className = "vt";
    
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tạo tiêu đề cho danh sách
    var h1 = document.createElement("h1");
    h1.appendChild(document.createTextNode("Thông Tin Quà Tặng"));    
    td.appendChild(h1);	

	var table2 = document.createElement("table");
    table2.width = "99%";
    table2.cellspacing = "1";
    table2.cellpadding = "1";
    table2.border = "0";   
	td.appendChild(table2);
    var tbody2 = document.createElement("tbody");
    tbody2.id = "th_detail";
    table2.appendChild(tbody2);
    var tr2 = document.createElement("tr");
    tr2.style.backgroundColor = "rgb(252, 252, 252)";
    tbody2.appendChild(tr2);
    td2 = document.createElement("td");
    td2.width = "10%";
    td2.appendChild(document.createTextNode("Xóa"));   
    td2.align = "center"; 
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "15%";
    td2.appendChild(document.createTextNode("Mã TĐ/Món"));   
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "30%";
    td2.appendChild(document.createTextNode("Tên Thực đơn/ Món"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "14%";
    td2.appendChild(document.createTextNode("Số Lượng"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "18%";
    td2.appendChild(document.createTextNode("Giá"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    td2 = document.createElement("td");
    td2.width = "18%";
    td2.appendChild(document.createTextNode("Tổng Giá"));
    td2.className = "menuhdr";
    tr2.appendChild(td2);
    
    Th.appendChild(table);
    if(Nut != null)
    {
        arr = XL_GIO_HANG.Khoi_tao_gio_hang(Nut);
    //alert(arr.length);
 	    for(var i = 0; i < arr.length; i++)
	    {
	        //alert(i);
		    var gio_hang = new Gio_hang();
		    gio_hang = arr[i];
    		
		    tr2 = document.createElement("tr");
		    tbody2.appendChild(tr2);
            //tao checkbox
	        td2 = document.createElement("td");
	        td2.width = "10%";
	        td2.align = "center";
		    var checkNode = document.createElement("input");
            checkNode.type = "checkbox";
            //checkNode.width = "5%";
            checkNode.id = "item " + (i+1);
            td2.appendChild(checkNode);
            tr2.appendChild(td2);

		    //Ma Mon
	        td2 = document.createElement("td");
	        td2.width = "10%";
            td2.appendChild(document.createTextNode(gio_hang.MaMon));
            tr2.appendChild(td2);
            
            //Ten Mon
	        td2 = document.createElement("td");
	        td2.width = "35%";
            td2.appendChild(document.createTextNode(gio_hang.TenMon));
            tr2.appendChild(td2);
            
		    //So Luong
	        td2 = document.createElement("td");
	        td2.width = "14%";
            var input = document.createElement("input");
       	    input.className = "txtfield";
       	    input.type = "text";
            input.name = "quantity";
       	    input.value = gio_hang.SoLuong;
      	    input.size = "3";
            input.maxlength = "4";
            td2.appendChild(input);
            tr2.appendChild(td2);

		    //Gia
	        td2 = document.createElement("td");
	        td2.width = "18%";
            td2.appendChild(document.createTextNode(gio_hang.Gia));
            tr2.appendChild(td2);

		    //Tong Gia
	        td2 = document.createElement("td");
	        td2.width = "18%";
            td2.appendChild(document.createTextNode(gio_hang.TongGiaMonAn));
            tr2.appendChild(td2);
        }

    }            

    tr2 = document.createElement("tr");
	tbody2.appendChild(tr2);
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");    
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);
    td2 = document.createElement("td");    
    td2.appendChild(document.createTextNode(" "))
    tr2. appendChild(td2);

    //tong gia tri
    td2 = document.createElement("td");
    td2.className = "menuhdr";
    td2.colSpan = 2;
    var span = document.createElement("span");
    span.style.color = "rgb(255, 0, 0)";
    span.appendChild(document.createTextNode("Tổng Giá Trị : " + TongGiaTri));
    td2.appendChild(span);
    tr2.appendChild(td2)
    
    tr2 = document.createElement("tr");
	tbody2.appendChild(tr2);
	
	td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "));
    tr2.appendChild(td2);     
    td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(" "));
    tr2.appendChild(td2);

    td2 = document.createElement("td");
    td2.className = "ar";
    td2.style.backgroundColor = "rgb(255, 255, 255)";
    tr2.appendChild(td2);    
    
    var table1 = document.createElement("table");
    table1.align = "left";
    td2.appendChild(table1);
    var tbody1 = document.createElement("tbody");
    table1.appendChild(tbody1);
    var tr1 = document.createElement("tr");
    tbody1.appendChild(tr1);
    
    var td1 = document.createElement("td");
    tr1.appendChild(td1);     
    var div = document.createElement("div");
    div.style.textAlign = "left";
    td1.appendChild(div);
    
    var form = document.createElement("form");
    form.method = "post";
    var limit = parseFloat(lbSoTien) - TongGiaTri;
    form.action = "DanhSachQuaTang.aspx?lbSoTien=" + lbSoTien + "&page=0&limit=" + limit + "&loaidh=" + loaidh;
    div.appendChild(form);
     
    //button       
    var input = document.createElement("input");
    input.className = "nonsubmitbtn";
    input.type = "submit";
    input.name = "tieptuc";        
    input.value = "Tiếp Tục";        
    form.appendChild(input);
    
    if (parseFloat(lbSoTien) == TongGiaTri)  //neu tong tien trong gio qua tang = tong tien khuyen mai
        input.disabled = true;
        
    td1 = document.createElement("td");
    tr1.appendChild(td1);        
    
    div = document.createElement("div");
    div.style.textAlign = "left";
    td1.appendChild(div);

    input = document.createElement("input");
    input.className = "nonsubmitbtn";
    input.type = "submit";
    input.name = "tinhlai";        
    input.value = "Cập nhật";
    input.onclick =  Cap_nhat_qua_tang ;
    div.appendChild(input);        
    
    div = document.createElement("div");
    div.style.textAlign = "right";
    td.appendChild(div);
    
    form = document.createElement("form");
    form.method = "post";
    if (loaidh == "0")
        form.action = "DatMuaSanPham_Customer.aspx";
    else if (loaidh == "1")
        form.action = "DatMuaDinhKy.aspx";
    div.appendChild(form);

    var input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "checkout";        
    input.value = "Đồng Ý";
    form.appendChild(input);
    
  //input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang ;    
}
function XL_GIO_HANG.Th_Thong_tin_chinh_gio_hang()
{
    var node;
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Thong_tin_chinh_gio_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);    

    var Goc = Ham.Thuc_hien();
            
    var table = document.createElement("table");
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");

    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //hinh xe day
    var img = document.createElement("IMG");
    img.border = "0";
    img.width = "42";
    img.height = "43";
    img.alt = "Shopping Cart";        
    img.src = "./Hinh Anh/cart.jpg";
    img.onclick = click;
    td.appendChild(img);

    //noi dung gio hang
    td = document.createElement("td");
    td.style.backgroundColor = "rgb(230, 230, 230)";
    td.width = "200";
    td.align = "center";
    tr.appendChild(td);
    if(Goc == null)
    {
        td.appendChild(document.createTextNode("Your cart is empty"));
    }
    else
    {
        var so_luong = Goc.getAttribute("So_items");
        td.appendChild(document.createTextNode("Your Items : " + so_luong));
        td.appendChild(document.createElement("br"));
        var tong_gia_tri = Goc.getAttribute("Tong_gia_tri");
        td.appendChild(document.createTextNode("Total : " + tong_gia_tri + " VND"));
        td.appendChild(document.createElement("br"));
        
        var a = document.createElement("a");
        a.href = "javascript:click()";     
        a.appendChild(document.createTextNode("View Cart | "));
        td.appendChild(a);
        
        a = document.createElement("a");
        a.href = "javascript:CheckoutClick()";
        a.appendChild(document.createTextNode("Check Out"));
        td.appendChild(a);
    }
    
    document.getElementById("divTTGioHang").innerHTML = "";
    document.getElementById("divTTGioHang").appendChild(table);    
}


function click()
{
    window.location = "AddToCard.aspx";
}

function CheckoutClick()
{
    window.location = "DatMuaSanPham.aspx";
}
