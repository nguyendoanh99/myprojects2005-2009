// JScript File


function Mon_An()
{
    this.MaMon = 0;
    this.TenMon = "";
    this.HinhAnhMinhHoa = "";
    this.MoTa = "";
    this.DiemBinhChon = "";
    this.DonViTinh = "";
    this.Gia = "";
    this.MaLoaiMon = "";
    this.TinhTrang = "";
    this.TrangThaiHienThi = "";
}

var arr;
var Th;
var maxRows = 2;

function XL_MON_AN()
{
}

function XL_MON_AN.LayDanhSachQuaTang()
{
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "Lay_danh_sach_qua_tang"));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
  
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("limit", limit));
    
    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(Goc);
        Th = document.getElementById("Th_ds_QuaTang");
        maxRows = 3
        XL_MON_AN.Th_Danh_sach_qua_tang()
        
        //var node = document.createElement("input");
//        node.value = "Quay lại";
  //      node.onclick = QuayLai_Click;
        
    //    Th.appendChild(node);
        
        if(arr.length == 0)
            alert ("Không có quà tặng trị giá dưới " + limit + " VND");
    }
}

function QuayLai_Click()
{

    if (page == "0")
        window.location = "AddToGifts.aspx?lbSoTien=" + lbSoTien + "&loaidh=" + loaidh;
    else if (page == "1")
        window.location = "DatMuaSanPham_Customer.aspx";
    else if (page == "2")
        window.location = "DatMuaDinhKy.aspx";
}

function XL_MON_AN.GhiNhanTimKiemTheoTen(ten)
{    
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    var Tham_so = new XL_THAM_SO("Xac_nhan","GhiNhanThongTinTimKiemTheoTen");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("t", new Date().getTime());
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("ten_mon", ten);
    Ham.Danh_sach_tham_so.push(Tham_so);
    var Goc = Ham.Thuc_hien();
    
    window.location = "TimKiem.aspx";
}

function XL_MON_AN.GhiNhanTimKiemNangCao(ten, cmbLoaiMon, tag, cmbGiaMin, cmbGiaMax)
{    
    if(ten == "")
        ten = null;
    if(tag == "")
        tag = null;
    if(cmbLoaiMon[cmbLoaiMon.selectedIndex].value == "")
        cmbLoaiMon[cmbLoaiMon.selectedIndex].value = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    var Tham_so = new XL_THAM_SO("Xac_nhan","GhiNhanThongTinTimKiemNangCao");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("t", new Date().getTime());
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("ten_mon", ten);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("ma_loai_mon", cmbLoaiMon[cmbLoaiMon.selectedIndex].value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("tag", tag);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("gia_min", cmbGiaMin[cmbGiaMin.selectedIndex].value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("gia_max", cmbGiaMax[cmbGiaMax.selectedIndex].value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    var Goc = Ham.Thuc_hien();
    
    window.location = "TimKiem.aspx";
}

function XL_MON_AN.TimKiem()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    var Tham_so = new XL_THAM_SO("Xac_nhan","TimKiem");
    Ham.Danh_sach_tham_so.push(Tham_so);    
    Tham_so = new XL_THAM_SO("t", new Date().getTime());
    Ham.Danh_sach_tham_so.push(Tham_so);    

    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(Goc)
        Th = document.getElementById("Th_ds_mon_an_tim_kiem");
        maxRows = 2;
        XL_MON_AN.Th_Danh_sach_mon_an()
    }
}

function XL_MON_AN.DSMonAnTheoTag()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    Tham_so = new XL_THAM_SO("Xac_nhan","DS_mon_an_theo_tag");
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(Goc)
        Th = document.getElementById("Th_ds_mon_an_theo_tag");
        maxRows = 2;
        XL_MON_AN.Th_Danh_sach_mon_an()
    }
}

//LONG THÊM CHỖ NÀY, GỌI MÓN ĂN DAO : HÀM LayDSMonAnThuocLoaiMonBatKy
function XL_MON_AN.LayDSMonAnThuocLoaiMonBatKy()
{
    var ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "DsMonAnThuocLoaiMonBatKy"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(goc)
        Th = document.getElementById("Th_ds_MonAn_loai_mon_an");
        maxRows = 3;
        XL_MON_AN.Th_Danh_sach_mon_an()
    }
}

function XL_MON_AN.LoadDSDonViTinh(nodeId)
{
     var nodeCmb = document.getElementById(nodeId);
     var nodeOpt = document.createElement("option");
     nodeOpt.innerHTML = "--Chọn đv tính";
     nodeOpt.value= -1;
     nodeCmb.appendChild(nodeOpt);
        
     var dsDonVi = ["Chén", "Dĩa", "Tô", "Chai", "Lon", "Bình", "Ly", "Cái", "Gói", "Miếng", "Phần"];
     
     for(var i = 1; i <= dsDonVi.length; ++i)
     {  
        nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = dsDonVi[i];
        nodeOpt.value= dsDonVi[i];
        nodeCmb.appendChild(nodeOpt);
     }
}

var nodePathHinhAnh = null;
var arrMonMoi = new Array();
function XL_MON_AN.ThemMonMoi()
{   
    //Lấy thông tin trên form
    var tenmon = document.getElementById("txtTenMon11").value;
    var cmbLoaiMonIndex = document.getElementById("cmbLoaiMon").selectedIndex;
    var loaimon = document.getElementById("cmbLoaiMon")[cmbLoaiMonIndex].value;
    var tenloaimon = document.getElementById("cmbLoaiMon")[cmbLoaiMonIndex].innerHTML;
    
    //xu ly ten file
    var hinhanh = nodePathHinhAnh.value;
    var arr = new Array();
    arr = hinhanh.split("\\");
    hinhanh = "Hinh Anh/San Pham/" + arr[arr.length-1];
    
    var mota = document.getElementById("txtMoTa").value;
    var donvitinh_index = document.getElementById("cmbDonViTinh").selectedIndex;
    var donvitinh = "1 " + document.getElementById("cmbDonViTinh")[donvitinh_index].value;
    var gia = document.getElementById("txtGia").value;
    var tinhtrang = (document.getElementById("optCon").checked == true);
    var hienthi = (document.getElementById("optHien").checked == true);
    var tag = document.getElementById("txtTag").value;
    
    thongbao = "";
    if(tenmon == "")
    {
        thongbao += "Thiếu tên món\n";
    }
    if(loaimon == -1)
    {
        thongbao += "Thiếu loại món\n";
    }
   
    if(gia == "" || gia == "0" || isNaN(gia) == true)
    {
        thongbao += "Đơn giá phải là số nguyên dương > 0\n";
    }
    if(thongbao != "")
    {
        alert(thongbao);
        return;
    } 
    
    if(mota == "")
    {
        mota = "Không có";
    }
    
    var ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemMonMoi"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tenmon", tenmon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("loaimon", loaimon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hinhanh", hinhanh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mota", mota));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("donvitinh", donvitinh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("gia", gia));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tinhtrang", tinhtrang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hienthi", hienthi));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tag", tag));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "true")
    {
        XL_CHUOI.Xuat("Thêm thành công!");      
//        var mon_an = new Mon_An();
//        mon_an.TenMon = tenmon;
//        mon_an.HinhAnhMinhHoa = hinhanh;
//        mon_an.MaLoaiMon = loaimon;
//        mon_an.DonViTinh = donvitinh;
//        mon_an.Gia = gia;
//        mon_an.TinhTrang = tinhtrang;
//        mon_an.TrangThaiHienThi = hienthi;
//        arr.push(mon_an);

//        var nodeTbody = document.getElementById("tbodyDSMon");
//        var nodeNewRow = document.createElement("tr");
//        
//        var nodeColSTT = document.createElement("td");
//        var nodeColHinhAnh = document.createElement("td");
//        var nodeColTenMon = document.createElement("td");
//        var nodeColLoaiMon = document.createElement("td");
//        var nodeColGia = document.createElement("td");
//        var nodeColTinhTrang = document.createElement("td");
//        var nodeColHienThi = document.createElement("td");
//       
//       /* 
//        nodeColSTT.setAttribute("className", "helpBod");
//        nodeColHinhAnh.setAttribute("className", "helpBod");
//        nodeColTenMon.setAttribute("className", "helpBod");
//        nodeColLoaiMon.setAttribute("className", "helpBod");
//        nodeColGia.setAttribute("className", "helpBod");
//        nodeColTinhTrang.setAttribute("className", "helpBod");
//        nodeColHienThi.setAttribute("className", "helpBod");
//        */
//        
//        nodeColSTT.innerHTML = tbodyDSMon.rows.length;
//        
//        var nodeHA = document.createElement("img");
//        nodeHA.src = hinhanh;
//        nodeHA.width = "50";
//        nodeHA.height = "50";
//        nodeColHinhAnh.appendChild(nodeHA);


//        nodeColTenMon.innerHTML = tenmon;
//        nodeColLoaiMon.innerHTML = tenloaimon;
//        nodeColGia.innerHTML = gia;
//        
//        if(tinhtrang == "1")
//            nodeColTinhTrang.innerHTML = "Còn";
//        else
//            nodeColTinhTrang.innerHTML = "Hết";
//            
//        if(hienthi == "1")
//            nodeColHienThi.innerHTML = "Hiển thị";
//        else
//            nodeColHienThi.innerHTML = "Ẩn";
//        
//        
//        nodeNewRow.appendChild(nodeColSTT);
//        nodeNewRow.appendChild(nodeColHinhAnh);
//        nodeNewRow.appendChild(nodeColTenMon);
//        nodeNewRow.appendChild(nodeColLoaiMon);
//        nodeNewRow.appendChild(nodeColGia);
//        nodeNewRow.appendChild(nodeColTinhTrang);
//        nodeNewRow.appendChild(nodeColHienThi);
//        
//        nodeTbody.appendChild(nodeNewRow);
    }
    else
        XL_CHUOI.Xuat("Thêm bị lỗi!");
}

//function XL_MON_AN.HienThiMonMoiTao()
//{
//    if(arr == null)
//        return;
//    for(var i = 0; i < arr.length; i++)
//    {
//        var mon_an = arr[i];
//        var nodeTbody = document.getElementById("tbodyDSMon");
//        var nodeNewRow = document.createElement("tr");
//        
//        var nodeColSTT = document.createElement("td");
//        var nodeColHinhAnh = document.createElement("td");
//        var nodeColTenMon = document.createElement("td");
//        var nodeColLoaiMon = document.createElement("td");
//        var nodeColGia = document.createElement("td");
//        var nodeColTinhTrang = document.createElement("td");
//        var nodeColHienThi = document.createElement("td");
//       
//       /* 
//        nodeColSTT.setAttribute("className", "helpBod");
//        nodeColHinhAnh.setAttribute("className", "helpBod");
//        nodeColTenMon.setAttribute("className", "helpBod");
//        nodeColLoaiMon.setAttribute("className", "helpBod");
//        nodeColGia.setAttribute("className", "helpBod");
//        nodeColTinhTrang.setAttribute("className", "helpBod");
//        nodeColHienThi.setAttribute("className", "helpBod");
//        */
//        
//        nodeColSTT.innerHTML = tbodyDSMon.rows.length;
//        
//        var nodeHA = document.createElement("img");
//        nodeHA.src = hinhanh;
//        nodeHA.width = "50";
//        nodeHA.height = "50";
//        nodeColHinhAnh.appendChild(nodeHA);


//        nodeColTenMon.innerHTML = tenmon;
//        nodeColLoaiMon.innerHTML = tenloaimon;
//        nodeColGia.innerHTML = gia;
//        
//        if(tinhtrang == "1")
//            nodeColTinhTrang.innerHTML = "Còn";
//        else
//            nodeColTinhTrang.innerHTML = "Hết";
//            
//        if(hienthi == "1")
//            nodeColHienThi.innerHTML = "Hiển thị";
//        else
//            nodeColHienThi.innerHTML = "Ẩn";
//        
//        
//        nodeNewRow.appendChild(nodeColSTT);
//        nodeNewRow.appendChild(nodeColHinhAnh);
//        nodeNewRow.appendChild(nodeColTenMon);
//        nodeNewRow.appendChild(nodeColLoaiMon);
//        nodeNewRow.appendChild(nodeColGia);
//        nodeNewRow.appendChild(nodeColTinhTrang);
//        nodeNewRow.appendChild(nodeColHienThi);
//        
//        nodeTbody.appendChild(nodeNewRow);
//    }
//}

function XL_MON_AN.KhoiTao()
{
     //Lấy thông tin trên form
    document.getElementById("txtTenMon").value = ""
    document.getElementById("cmbLoaiMon").value = -1
    //nodePathHinhAnh.value = "";
    document.getElementById('ctl00_ContentPlaceHolder1_FileUpload1').value = "";
    document.getElementById("txtMoTa").value = ""; 
    document.getElementById("cmbDonViTinh").selectedIndex = 0;
    document.getElementById("txtGia").value = 0;
//    if(gia == "" || isNaN(gia) == true)
//    {
//        XL_CHUOI.Xuat("Lỗi : hãy kiểm tra lại đơn giá");
//        return;
//    }
    
//    var tinhtrang = (document.getElementById("optCon").checked == true);
//    var hienthi = (document.getElementById("optHien").checked == true);
//    var tag = document.getElementById("txtTag").value;
    document.getElementById("optCon").checked == true;
    document.getElementById("optHien").checked == true;
    document.getElementById("txtTag").value = "";    
}

function XL_MON_AN.Ghi_nhan_mon_an(ma_mon_an)
{
//    var obj = window.event.srcElement.parentNode.firstChild;
//    var parent = obj.parentNode.parentNode;
//    parent = parent.nextSibling;
//    var node = parent.firstChild.innerText;    
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_mon_an");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma_mon_an", ma_mon_an);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    
    window.location = "ChiTietMonAn.aspx";
}


function XL_MON_AN.Chi_tiet_mon_an()
{    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    Tham_so = new XL_THAM_SO("Xac_nhan","Chi_tiet_mon_an");
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        Th = document.getElementById("Th_Chi_tiet_mon_an");
        Kq = XL_MON_AN.Chi_tiet(Goc, Th);
    }
    return Kq;
}

function XL_MON_AN.Chi_tiet(Nut, Th)
{    
    var M = Nut.childNodes;
    
    var ma = new Mon_An();
    ma.MaMon = M[0].getAttribute("Ma_mon");
    ma.TenMon = M[0].getAttribute("Ten_mon");
    ma.HinhAnhMinhHoa = M[0].getAttribute("Hinh_anh_minh_hoa");
    ma.MoTa = M[0].getAttribute("Mo_ta");
    ma.DiemBinhChon = M[0].getAttribute("Diem_binh_chon");
    ma.DonViTinh = M[0].getAttribute("Don_vi_tinh");
    ma.Gia = M[0].getAttribute("Gia");
    ma.MaLoaiMon = M[0].getAttribute("Ma_loai_mon");
    ma.TinhTrang = M[0].getAttribute("Tinh_trang");
    ma.TrangThaiHienThi = M[0].getAttribute("Trang_thai_hien_thi");    
    
    var table = document.createElement("table");    
    table.id = "wrap";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    td.id = "main";
    td.className = "vt";
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody); 
    
    div = document.createElement("div");         
    td.appendChild(div);
    div.style.margin = "10px";        
    div.style.textAlign = "left";    
    
    tr = document.createElement("tr");
    div.appendChild(tr);
    var div1 = document.createElement("div");
    div1.className = "breadcrumb";
    div.appendChild(div1);
    
    //tao table chua thong tin chi tiet mon an
    var table1 = document.createElement("table");
    table1.width = "100%";
    table1.cellspacing = "3";
    table1.cellpading = "3";
    table1.border = "0";
    div.appendChild(table1);
    
    var tbody1 = document.createElement("tbody");
    var tr1 = document.createElement("tr");
    tbody1.appendChild(tr1);
    table1.appendChild(tbody1);
    
    //tao hinh anh
    var td1 = document.createElement("td");
    td1.width = "50%";
    td1.valign = "middle";
    td1.align = "center";
    td1.style.textAlign = "center";
    tr1.appendChild(td1);
    
    div1 = document.createElement("div");
    div1.style.border = "1px dotted rgb(204, 204, 204)";
    div1.style.padding = "5px";
    td1.appendChild(div1);
    
    var img = document.createElement("IMG");
    img.border = "0";
    img.alt = "Chi Tiết";
    img.src = ma.HinhAnhMinhHoa;
    td1.appendChild(img);
    
    //thong tin chi tiet
    td1 = document.createElement("td");
    td1.width = "50%";
    td1.valign = "top";    
    td1.style.backgroundColor = "rgb(238, 238, 238)";
    tr1.appendChild(td1);
    
    var h1 = document.createElement("h1");
    h1.appendChild(document.createTextNode(ma.TenMon));    
    td1.appendChild(h1);
    
    var p = document.createElement("p");
    p.appendChild(document.createTextNode("Mã Món : " + ma.MaMon));    
    td1.appendChild(p);
    
    p = document.createElement("p");
    p.appendChild(document.createTextNode("Đơn Vị Tính : " + ma.DonViTinh));    
    td1.appendChild(p);       
    
    p = document.createElement("p");
    var strong = document.createElement("strong");
    strong.appendChild(document.createTextNode("Giá : " + ma.Gia + " VND"));    
    p.appendChild(strong);
    td1.appendChild(p);
    
    var form = document.createElement("form");
    form.method = "post";
    form.action = "AddToCard.aspx";
    td1.appendChild(form);
    
    var table2 = document.createElement("table");    
    table2.cellspacing = "1";
    table2.cellpading = "2";
    table2.border = "0";
    form.appendChild(table2);
    
    var tbody2 = document.createElement("tbody");
    table2.appendChild(tbody2);
    var tr2 = document.createElement("tr");
    var td2 = document.createElement("td");
    td2.className = "al";
    tr2.appendChild(td2);
    tbody2.appendChild(tr2);
    
    var tr2 = document.createElement("tr");
    tbody2.appendChild(tr2);   
    //tao textbox
    td2 = document.createElement("td");
    td2.className = "ac";    
    var input = document.createElement("input");
    input.className = "txtfield";
    input.type = "text";
    input.name = "quantity";
    input.value = "1";
    input.size = "2";
    input.maxlength = "3";
    td2.appendChild(input);
    tr2.appendChild(td2);
    
    //tao button
    td2 = document.createElement("td");
    td2.className = "ac vm";    
    input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "Order";        
    input.value = "Order";
    input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang_tu_chi_tiet ;
    td2.appendChild(input);
    tr2.appendChild(td2);
    
    tr2 = document.createElement("tr");  
    td2 = document.createElement("td");  
    div = document.createElement("div");  
    td2.appendChild(div);                
    div.style.textAlign = "center";
    form = document.createElement("form");
    form.method = "post";
    form.action = "DanhSachMonAnYeuThich.aspx";
    div.appendChild(form);
    
    input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "favorite";
    input.value = "Favorite";
    input.onclick = XL_MonAnYeuThich.Ghi_nhan_mon_an_tu_chi_tiet;
    
    form.appendChild(input);
    
    tr2.appendChild(td2);
    tbody2.appendChild(tr2);
    
    //Mo ta mon an
    tr1 = document.createElement("tr");
    tbody1.appendChild(tr1);
    
    tr1 = document.createElement("tr");
    tbody1.appendChild(tr1);
    td1 = document.createElement("td");
    tr1.appendChild(td1);
    var p = document.createElement("p");
    p.appendChild(document.createTextNode(ma.MoTa));    
    td1.appendChild(p);
    
    Th.appendChild(table);
}



function XL_MON_AN.Danh_sach_mon_an()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN");
    Tham_so = new XL_THAM_SO("Xac_nhan","Lay_danh_sach");
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(Goc);
        Th = document.getElementById("div_Th_ds_mon_an");
        maxRows = 3
        XL_MON_AN.Th_Danh_sach_mon_an()
    }
    return Kq;
}

var curPg;

function XL_MON_AN.Th_Danh_sach_mon_an()
{    
    var temp;
    var m;
        
    var obj = null;
    if(window.event == null)
        curPg = 1;
    else
    {
        obj = window.event.srcElement;        
    }
    if(obj != null)
    {
        if(obj.innerText == "Prev ")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg -= 1;
        }
        else if(obj.innerText == "Next")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg += 1;
        }    
        else
        {
            m = obj.innerText.split(" ");
            curPg = parseInt(m[0]);
        }   
    }    
    
    //xu ly phan trang
    var maxPages = 2;
    var totalPages = new Number();        
    var totalRows;
    
    if(arr.length % 3 == 0)
        totalRows = arr.length/3;
    else
        totalRows = parseInt(arr.length/3 + 1);

    if(totalRows % maxRows ==0)  
	        totalPages = totalRows / maxRows;
    else 
	        totalPages = parseInt(totalRows / maxRows + 1);
    
    var curPage =curPg;
    var curRow = (curPage-1)*maxRows+1;
    //////////////////////////////////////////////////////////////////////////////////////////////////////
                   
    var table = document.createElement("table");
    table.align = "center";
    table.id = "container";
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
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Món Ăn"));    
    td.appendChild(h1);
    
    if(arr.length == 0)
    {
        td.appendChild(document.createTextNode("Không có sản phẩm nào"));
        td.align = "left";
        Th.innerHTML = "";
        Th.appendChild(table);
        return;
    }
    
    var table3 = document.createElement("table");
    table3.width = "100%";
    table3.border = "0";
    td.appendChild(table3);
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    
    var td3 = document.createElement("td");
    td3.className = "ac"    ;
    tr3.appendChild(td3);
    
    //tiep tuc phan trang        
    
    var i=new Number();
    if(totalRows >= maxRows)
    {
        if(curPage>maxPages)
        {
            var pre=start-1;	        
            var a = document.createElement("a");
            a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
		    a.appendChild(document.createTextNode("Prev "));
		    td3.appendChild(a);
        }
    
        var start=1;
        var end=1;			 	 
        for( i=1;i<=totalPages;i++)
        {	
        
             if( (i >= (parseInt((curPage-1)/maxPages))* maxPages) && (i <= (parseInt((curPage-1)/maxPages+1))* maxPages ))
	        {
	            var a = document.createElement("a");
		        if(start==1) 
		            start=i;
		        if(i==curPage)      
		        {		            		        
			        a.appendChild(document.createTextNode(i + " "));
		        }			    
		        else    
			    {			    
			        a.href = "#";            
		            a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
			        a.appendChild(document.createTextNode(i + " "));
			    }
			    	
			    td3.appendChild(a);
		        end=i;
	        }
        }
    	
        //phan trang        
        
        if((((curPage-1)/maxPages+1)*maxPages) <= totalPages)
        {
            var next= end+1;	        
	        var a = document.createElement("a");
	        a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
			a.appendChild(document.createTextNode("Next"));
			td3.appendChild(a);
	    }
    }
    
    //tạo danh sách các món ăn ở trong
    var table1 = document.createElement("table");
    table1.className = "vt";
    table1.width = "100%";
    table1.cellspacing = "1";
    table1.cellpadding = "4";
    table1.border = "0";
    table1.align = "center";
    td.appendChild(table1);
    
    var tbody1 = document.createElement("tbody");
    table1.appendChild(tbody1);
       
    var low=curRow;								
    i=low-1;
    //curRow=1;
    var j = -1;
    var tr1;
    while (i<totalRows && (curRow<=totalRows) && (curRow <= curPage*maxRows))
	{	
	    j++;    	    
	    if(((curRow-1) * 3 + j) >= arr.length )/////////
	        break;
	    if(j % 4 == 0)///////////
        {
            tr1 = document.createElement("tr");
            tbody1.appendChild(tr1);
        }
	    
        var mon_an = arr[(curRow-1) * 3 + j];////////////
        
        if((j+1) % 3 == 0)//////////
        {
            curRow++;
            j = -1;
        }                
        
       // if(curRow<low)
		//    continue;
        if(mon_an.TrangThaiHienThi == false)
            continue;          
                
        
        var td1 = document.createElement("td");
        td1.className = "al vt";
        tr1.appendChild(td1);
        
        var form = document.createElement("form");
        form.method = "post";
        form.action = "AddToCard.aspx";
        td1.appendChild(form);
        
        //tạo hidden chua id món ăn
        var hidden = document.createElement("input");
        hidden.type = "hidden";
        hidden.id = "productid";
        hidden.value = mon_an.MaMon;
        form.appendChild(hidden);
        
        var table2 = document.createElement("table");
        table2.id = "table"+i;
        table2.width = "100%";
        table2.cellspacing = "2";
        table2.cellpadding = "2";
        table2.border = "0";        
        form.appendChild(table2);
        table2.style.border = "1px dotted rgb(119, 119, 119)";
        //table2.style.margin = "6px 6px 6px";
        
        var tbody2 = document.createElement("tbody");
        table2.appendChild(tbody2);
        
        //Ten mon an
        var tr2 = document.createElement("tr");
        var td2 = document.createElement("td");
        td2.align = "center";  
        td2.colSpan = 2;
        td2.appendChild(document.createTextNode(mon_an.TenMon));
        tr2.appendChild(td2);
        td2.style.background = "transparent url(./ImageInstock/h3r.gif) repeat-x scroll 0%"          
        td2.style.fontWeight = "bold";
        td2.style.mozBackgroundClip = "-moz-initial"; 
        td2.style.mozBackgroundOrigin = "-moz-initial";
        td2.style.mozBackgroundInlinePolicy = "-moz-initial";
        td2.style.color = "black";
        td2.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //don vi tinh
        tr2 = document.createElement("tr");
        td2 = document.createElement("td");
        td2.colSpan = 2;        
        td2.align = "center";  
        var div = document.createElement("div");
        div.appendChild(document.createTextNode(mon_an.DonViTinh));
        td2.appendChild(div);
        tr2.appendChild(td2);
        div.style.borderBottom = "1px dotted rgb(19, 91, 46)";
        div.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //hinh anh
        tr2 = document.createElement("tr");
        tbody2.appendChild(tr2);
        
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "top";
        td2.align = "left";
        var p = document.createElement("p");
        p.className = "ac";        
        var img = document.createElement("IMG");
        img.border = "0";
        img.alt = "CT";        
        img.src = mon_an.HinhAnhMinhHoa;
        img.width = 160;
        img.height= 150;
        //img.onclick = XL_MON_AN.Ghi_nhan_mon_an;
        p.appendChild(img);
        
        p.appendChild(document.createElement("br"));
        var a = document.createElement("a");
        a.href = "javascript:XL_MON_AN.Ghi_nhan_mon_an("+mon_an.MaMon+")";
        a.appendChild(document.createTextNode("Chi Tiết"));
        p.appendChild(a);
        td2.appendChild(p);
        tr2.appendChild(td2);
          
        //Don Gia   
        var arr1 = new Array();
        arr1 = mon_an.Gia.split('.');
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "middle";
        td2.align = "right";
        div = document.createElement("div");     
        div.id = "proID";
        div.style.display = "none";
        div.appendChild(document.createTextNode(mon_an.MaMon));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";        
        div.style.textAlign = "center";
        div.style.fontSize = "100%";
        div.style.color = "rgb(155, 155, 155)";   
        
        div = document.createElement("div");     
        div.appendChild(document.createTextNode(arr1[0] + " VND"));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";
        div.style.fontWeight = "bold";
        div.style.textAlign = "center";
        div.style.fontSize = "120%";
        div.style.color = "rgb(19, 91, 46)";   
             
        div = document.createElement("div");  
        td2.appendChild(div);        
        div.style.margin = "5px";
        div.style.textAlign = "center";                      
        var input = document.createElement("input");
        input.className = "txtfield";
        input.type = "text";
        input.name = "quantity";
        input.value = "1";
        input.size = "3";
        input.maxlength = "4";
        div.appendChild(input);
        
        div = document.createElement("div");  
        td2.appendChild(div);                
        div.style.textAlign = "center";
        input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "Order";        
        input.value = "Order";
        input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang_mon_an ;
        div.appendChild(input);                
        
        div = document.createElement("div");  
        td2.appendChild(div);                
        div.style.textAlign = "center";
        form = document.createElement("form");
        form.method = "post";
        form.action = "DanhSachMonAnYeuThich.aspx";
        div.appendChild(form);
        
        input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "favorite";        
        input.value = "Favorite";
        input.onclick = XL_MonAnYeuThich.Ghi_nhan_mon_an;
        
        form.appendChild(input);             
        tr2.appendChild(td2);               
    }
    Th.innerHTML = "";
    Th.appendChild(table);
}

function XL_MON_AN.Khoi_tao_hien_thi(_arr, _Th)
{
    arr = _arr;
    Th = _Th;
}

function XL_MON_AN.Khoi_tao_ds_mon_an(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var ma = new Mon_An();
        ma.MaMon = M[i].getAttribute("Ma_mon");
        ma.TenMon = M[i].getAttribute("Ten_mon");
        ma.HinhAnhMinhHoa = M[i].getAttribute("Hinh_anh_minh_hoa");
        ma.MoTa = M[i].getAttribute("Mo_ta");
        ma.DiemBinhChon = M[i].getAttribute("Diem_binh_chon");
        ma.DonViTinh = M[i].getAttribute("Don_vi_tinh");
        ma.Gia = M[i].getAttribute("Gia");
        ma.MaLoaiMon = M[i].getAttribute("Ma_loai_mon");
        ma.TinhTrang = M[i].getAttribute("Tinh_trang");
        ma.TrangThaiHienThi = M[i].getAttribute("Trang_thai_hien_thi");
        Kq.push(ma);
    }
    return Kq;
}

function XL_MON_AN.Th_Danh_sach_qua_tang()
{    
    var temp;
    var m;
        
    var obj = null;
    if(window.event == null)
        curPg = 1;
    else
    {
        obj = window.event.srcElement;        
    }
    if(obj != null)
    {
        if(obj.innerText == "Prev ")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg -= 1;
        }
        else if(obj.innerText == "Next")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg += 1;
        }    
        else
        {
            m = obj.innerText.split(" ");
            curPg = parseInt(m[0]);
        }   
    }    
    
    //xu ly phan trang
    var maxPages = 2;
    var totalPages = new Number();        
    var totalRows;
    
    if(arr.length % 3 == 0)
        totalRows = arr.length/3;
    else
        totalRows = parseInt(arr.length/3 + 1);

    if(totalRows % maxRows ==0)  
	        totalPages = totalRows / maxRows;
    else 
	        totalPages = parseInt(totalRows / maxRows + 1);
    
    var curPage =curPg;
    var curRow = (curPage-1)*maxRows+1;
    //////////////////////////////////////////////////////////////////////////////////////////////////////
                   
    var table = document.createElement("table");
    table.align = "center";
    table.id = "container";
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
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Quà Tặng"));    
    td.appendChild(h1);
    
    var table3 = document.createElement("table");
    table3.width = "100%";
    table3.border = "0";
    td.appendChild(table3);
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    
    var td3 = document.createElement("td");
    td3.className = "ac"    ;
    tr3.appendChild(td3);
    
    //tiep tuc phan trang        
    
    var i=new Number();
    if(totalRows >= maxRows)
    {
        if(curPage>maxPages)
        {
            var pre=start-1;	        
            var a = document.createElement("a");
            a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_qua_tang;
		    a.appendChild(document.createTextNode("Prev "));
		    td3.appendChild(a);
        }
    
        var start=1;
        var end=1;			 	 
        for( i=1;i<=totalPages;i++)
        {	
        
             if( (i >= (parseInt((curPage-1)/maxPages))* maxPages) && (i <= (parseInt((curPage-1)/maxPages+1))* maxPages ))
	        {
	            var a = document.createElement("a");
		        if(start==1) 
		            start=i;
		        if(i==curPage)      
		        {		            		        
			        a.appendChild(document.createTextNode(i + " "));
		        }			    
		        else    
			    {			    
			        a.href = "#";            
		            a.onclick = XL_MON_AN.Th_Danh_sach_qua_tang;
			        a.appendChild(document.createTextNode(i + " "));
			    }
			    	
			    td3.appendChild(a);
		        end=i;
	        }
        }
    	
        //phan trang        
        
        if((((curPage-1)/maxPages+1)*maxPages) <= totalPages)
        {
            var next= end+1;	        
	        var a = document.createElement("a");
	        a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_qua_tang;
			a.appendChild(document.createTextNode("Next"));
			td3.appendChild(a);
	    }
    }
    
    //tạo danh sách các món ăn ở trong
    var table1 = document.createElement("table");
    table1.className = "vt";
    table1.width = "100%";
    table1.cellspacing = "1";
    table1.cellpadding = "4";
    table1.border = "0";
    table1.align = "center";
    td.appendChild(table1);
    
    var tbody1 = document.createElement("tbody");
    table1.appendChild(tbody1);
       
    var low=curRow;								
    i=low-1;
    //curRow=1;
    var j = -1;
    var tr1;
    while (i<totalRows && (curRow<=totalRows) && (curRow <= curPage*maxRows))
	{	
	    j++;    	    
	    if(((curRow-1) * 3 + j) >= arr.length )/////////
	        break;
	    if(j % 4 == 0)///////////
        {
            tr1 = document.createElement("tr");
            tbody1.appendChild(tr1);
        }
	    
        var mon_an = arr[(curRow-1) * 3 + j];////////////
        
        if((j+1) % 3 == 0)//////////
        {
            curRow++;
            j = -1;
        }                
        
       // if(curRow<low)
		//    continue;
        if(mon_an.TrangThaiHienThi == false)
            continue;          
                
        
        var td1 = document.createElement("td");
        td1.className = "al vt";
        tr1.appendChild(td1);
        
        var form = document.createElement("form");
        form.method = "post";
        form.action = "AddToGifts.aspx?lbSoTien=" + lbSoTien + "&loaidh=" + loaidh; //1dinhky, 0thuong
            
        td1.appendChild(form);
        
        //tạo hidden chua id món ăn
        var hidden = document.createElement("input");
        hidden.type = "hidden";
        hidden.id = "productid";
        hidden.value = mon_an.MaMon;
        form.appendChild(hidden);
        
        var table2 = document.createElement("table");
        table2.id = "table"+i;
        table2.width = "100%";
        table2.cellspacing = "2";
        table2.cellpadding = "2";
        table2.border = "0";        
        form.appendChild(table2);
        table2.style.border = "1px dotted rgb(119, 119, 119)";
        
        var tbody2 = document.createElement("tbody");
        table2.appendChild(tbody2);
        
        //Ten mon an
        var tr2 = document.createElement("tr");
        var td2 = document.createElement("td");
        td2.align = "center";  
        td2.colSpan = 2;
        td2.appendChild(document.createTextNode(mon_an.TenMon));
        tr2.appendChild(td2);
        td2.style.background = "transparent url(./ImageInstock/h3r.gif) repeat-x scroll 0%"          
        td2.style.fontWeight = "bold";
        td2.style.mozBackgroundClip = "-moz-initial"; 
        td2.style.mozBackgroundOrigin = "-moz-initial";
        td2.style.mozBackgroundInlinePolicy = "-moz-initial";
        td2.style.color = "black";
        td2.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //don vi tinh
        tr2 = document.createElement("tr");
        td2 = document.createElement("td");
        td2.colSpan = 2;        
        td2.align = "center";  
        var div = document.createElement("div");
        div.appendChild(document.createTextNode(mon_an.DonViTinh));
        td2.appendChild(div);
        tr2.appendChild(td2);
        div.style.borderBottom = "1px dotted rgb(19, 91, 46)";
        div.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //hinh anh
        tr2 = document.createElement("tr");
        tbody2.appendChild(tr2);
        
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "top";
        td2.align = "left";
        var p = document.createElement("p");
        p.className = "ac";        
        var img = document.createElement("IMG");
        img.border = "0";
        img.alt = "CT";        
        img.src = mon_an.HinhAnhMinhHoa;
        img.width = 160;
        img.height= 150;
        //img.onclick = XL_MON_AN.Ghi_nhan_mon_an;
        p.appendChild(img);
        
        p.appendChild(document.createElement("br"));
        var a = document.createElement("a");
        a.href = "javascript:XL_MON_AN.Ghi_nhan_mon_an("+mon_an.MaMon+")";
        a.appendChild(document.createTextNode("Chi Tiết"));
        p.appendChild(a);
        td2.appendChild(p);
        tr2.appendChild(td2);
          
        //Don Gia   
        var arr1 = new Array();
        arr1 = mon_an.Gia.split('.');
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "middle";
        td2.align = "right";
        div = document.createElement("div");     
        div.id = "proID";
        div.appendChild(document.createTextNode(mon_an.MaMon));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";        
        div.style.textAlign = "center";
        div.style.fontSize = "100%";
        div.style.color = "rgb(155, 155, 155)";   
        
        div = document.createElement("div");     
        div.appendChild(document.createTextNode(arr1[0] + " VND"));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";
        div.style.fontWeight = "bold";
        div.style.textAlign = "center";
        div.style.fontSize = "120%";
        div.style.color = "rgb(19, 91, 46)";   
             
        div = document.createElement("div");  
        td2.appendChild(div);        
        div.style.margin = "5px";
        div.style.textAlign = "center";                      
        var input = document.createElement("input");
        input.className = "txtfield";
        input.type = "text";
        input.name = "quantity";
        input.value = "1";
        input.size = "3";
        input.maxlength = "4";
        div.appendChild(input);
        
        div = document.createElement("div");  
        td2.appendChild(div);                
        div.style.textAlign = "center";
        input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "Chon";        
        input.value = "Chọn";
        input.onclick = XL_GIO_HANG.Ghi_nhan_dat_hang_mon_an ;
        
        div.appendChild(input);                
        tr2.appendChild(td2);               
    }
    Th.innerHTML = "";
    Th.appendChild(table);
}


//XU LY CHO TRANG CHITIETLOAIMON.ASPX

var myDataSource;
function CreateTable()
{   
    myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_MON_AN.aspx?Xac_nhan=DsMonAnThuocLoaiMon&" + "LoaiMon=" + maLoaiMon + "&t=" + (new Date().getTime()) + "&"));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "MonAn", // Name of the node for each result
        fields : [
            { key: "MaMonAn" }, // Attribute of the resultNode
            { key: "TenMonAn" }, 
            { key: "LoaiMonAn" },
            { key: "MoTa"},
            { key: "HinhAnhMinhHoa"}, 
            { key: "Gia"}, 
            { key: "TrangThaiHienThi"}, 
            { key: "TinhTrang"}
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords" // Tổng số dòng 
        }
    };        
        
    var myRequestBuilder = function(oState, oSelf) {
        // Get states or use defaults
        oState = oState || {pagination:null, sortedBy:null};
        var sort = (oState.sortedBy) ? oState.sortedBy.key : "myDefaultColumnKey";
        var dir = (oState.sortedBy && oState.sortedBy.dir === DT.CLASS_DESC) ? "false" : "true";
        var startIndex = (oState.pagination) ? oState.pagination.recordOffset : 0;
        var results = (oState.pagination) ? oState.pagination.rowsPerPage : 100;
        
        // Build custom request
        return  "column=" + sort +
                "&asc=" + true +
                "&startIndex=" + startIndex +
                "&results=" + results +
                "&t=" + (new Date().getTime());
    };

    var myConfigs = {
        generateRequest : myRequestBuilder,
        // Set up pagination
        initialRequest: "sort=id&dir=asc&startIndex=0&results=5", // Initial request for first page of data
        // Phân trang
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 5 // Số dòng tối đa của một trang
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : true
    };
    
    // Định nghĩa các formatter dành cho các cột
    // Define a custom format function
    var TinhTrangFormatter = function(elCell, oRecord, oColumn, oData) {
        var oTinhTrang = parseInt(oData);
        elCell.innerHTML = oTinhTrang==1 ? "Còn" : "Hết";
    };
    var HienThiFormatter = function(elCell, oRecord, oColumn, oData) {
        var oTinhTrang = parseInt(oData);
        elCell.innerHTML = oTinhTrang==1 ? "Hiện" : "Ẩn";
    };
    
    // Override the built-in formatter
    // Cho nút xóa tài khoản, gửi lại mật khẩu
    YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maMonAn = oRecord.getData("MaMonAn");
        if (oColumn.key.indexOf("XoaMonAn") != -1)
            elCell.innerHTML = '<a id="XoaMonAn' + maMonAn + '"><img src="Images/Close.png" title="Xóa món ăn" height="16"/></a>';
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
    
    var HinhAnhFormatter = function(elCell, oRecord, oColumn, oData) {
        var hinhAnh = oRecord.getData("HinhAnhMinhHoa");
        elCell.innerHTML = '<img src="' + hinhAnh + '" height="48" width="48"/>';
    };
    
    var radioEditorHienThi = new YAHOO.widget.RadioCellEditor({radioOptions:[{label: "Hiện", value: 1}, {label: "Ẩn", value: 0}]});
    radioEditorHienThi._elSaveBtn.innerHTML = "Lưu";
    radioEditorHienThi._elCancelBtn.innerHTML = "Bỏ qua";
    
    var radioEditorTinhTrang = new YAHOO.widget.RadioCellEditor({radioOptions:[{label: "Còn", value: 1}, {label: "Hết", value: 0}]});
    radioEditorTinhTrang._elSaveBtn.innerHTML = "Lưu";
    radioEditorTinhTrang._elCancelBtn.innerHTML = "Bỏ qua";
    // Định nghĩa cột
    var myColumnDefs = [
        { label:"STT", formatter: STTFormatter},
        { key: "HinhAnhMinhHoa", label: "", formatter: HinhAnhFormatter},                
        { key: "TenMonAn", label: "Tên món ăn" },          
        { key: "LoaiMonAn", label: "Loại món"},
        { key: "MoTa", label: "Mô tả"},
        { key: "Gia", label: "Giá", formatter: "number"},
        { key: "TrangThaiHienThi", label: "Trạng thái", editor: radioEditorHienThi, formatter: HienThiFormatter},
        { key: "TinhTrang", label: "Tình trạng", editor: radioEditorTinhTrang, formatter: TinhTrangFormatter},
        { key: "XoaMonAn", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divDanhSachMon", myColumnDefs, myDataSource, myConfigs);
    // Update totalRecords on the fly with value from server
    // Dành cho phân trang, cập nhật lại tổng số dòng
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
    return myDataTable;
}

function XL_MON_AN.LayDanhSachMon()
{
    document.body.className += " yui-skin-sam";
    
    //var divcha = document.getElementById ("divcha");
    //var divcon = document.createTextNode("label");
    //divcon.innerHTML = "Loại món: " + tenLoaiMon;
    //divcha.appendChild(divcon);
    
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}

// Thêm các event cho table
function AddEvents(myDataTable)
{
    var maMonAn;
    var oRecord;
    // Define various event handlers for Dialog
	var handleYes = function() {
	    this.hide();
	    var kq = XoaMonAn(maMonAn);
        if (kq.length == 0)
        {
            myDataTable.deleteRow(oRecord);
        }
        else    
            alert(kq);
	};
	var handleNo = function() {
		this.hide();
	};
 
	// Instantiate the Dialog
	Deletedialog = new YAHOO.widget.SimpleDialog("DeleteDLG", 
			 { width: "300px",
			   fixedcenter: true,
			   visible: false,
			   modal:true, 
			   draggable: true,
			   close: true,
			   icon: YAHOO.widget.SimpleDialog.ICON_HELP,
			   constraintoviewport: true,
			   buttons: [ { text:"Có", handler:handleYes },
						  { text:"Không",  handler:handleNo, isDefault:true } ]
			 } );
	Deletedialog.setHeader("Xóa món ăn?");
	
	// Render the Dialog
	Deletedialog.render(document.body);
	
    var highlightEditableCell = function(oArgs) {
        var elCell = oArgs.target;
        if(YAHOO.util.Dom.hasClass(elCell, "yui-dt-editable") 
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-XoaMonAn")) {
            this.highlightCell(elCell);
        }
    };
    // Enable inline cell editing 
    myDataTable.subscribe("cellMouseoverEvent", highlightEditableCell);
    myDataTable.subscribe("cellMouseoutEvent", myDataTable.onEventUnhighlightCell);
    myDataTable.subscribe("cellClickEvent", myDataTable.onEventShowCellEditor);
    
    // Sự kiện click vào nút Save
    // Cập nhật lại tình trạng kích hoạt của tài khoản    
	// Create a Custom Event handler
    var myEditorSaveEvent = function(oArgs) {
        var oEditor = oArgs.editor;
        var tinhTrang = oArgs.newData;
        var oldData = oArgs.oldData;
        
        if (parseInt(tinhTrang) == parseInt(oldData))
            return;
        
        var key = oEditor.getColumn().key;
        var maMonAn = oEditor.getRecord().getData("MaMonAn");
        
        if (key.indexOf("TinhTrang") != -1)
            CapNhat("CapNhatTinhTrang", maMonAn, tinhTrang);
        else
            CapNhat("CapNhatTrangThaiHienThi", maMonAn, tinhTrang);
    };
	myDataTable.subscribe("editorSaveEvent", myEditorSaveEvent);     
	
    // Sự kiện click trên link (Xóa tài khoản, Gửi lại mật khẩu)
    myDataTable.subscribe("linkClickEvent", function(oArgs){
        var target = oArgs.target;
        oRecord = this.getRecord(target);
        maMonAn = oRecord.getData("MaMonAn");
        var tenMonAn = oRecord.getData("TenMonAn");
        if (target.id.indexOf("XoaMonAn") != -1) // xóa món ăn
        {
            Deletedialog.setBody("Bạn có muốn xóa món ăn '" + tenMonAn + "' không?"); 
            Deletedialog.show();
        }
    });
}
    
function CapNhat(request, maMonAn, giaTri)
{
    var ham = new XL_HAM("He phuc vu/XL_NVQuanLyMonAn");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", request));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaMonAn", maMonAn));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("GiaTri", giaTri));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {            
        }        
        else
            return "Không thực hiện được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
}
function XoaMonAn(maMonAn)
{
    var ham = new XL_HAM("He phuc vu/XL_NVQuanLyMonAn");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "XoaMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaMonAn", maMonAn));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
             return "";
        else
            return "Không xóa được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
    
}