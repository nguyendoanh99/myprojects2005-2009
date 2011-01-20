// JScript File

function Thuc_Don()
{
    this.MaThucDon = 0;
    this.TenThucDon = "";
    this.HinhAnhMinhHoa = "";
    this.MaLoaiThucDon = "";    
    this.Gia = "";    
    this.TinhTrang = "";
    this.TrangThaiHienThi = "";
}

function XL_THUC_DON()
{
}

function XL_ThucDon()
{
}
var nodePathHinhAnh = null;


var TiLeGiam = 0;
var DsMaMonAn = new Array();
var arr;
var Th;
var maxRows = 2;

function XL_ThucDon.TimKiem()
{
    var ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "TimKiem"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        arr = XL_THUC_DON.Khoi_tao_ds_thuc_don(goc)
        Th = document.getElementById("Th_ds_thuc_don_tim_kiem");
        maxRows = 2;
        XL_THUC_DON.Th_Danh_sach_thuc_don()
    }
}

//LONG THÊM CHỖ NÀY, GỌI THỰC ĐƠN DAO : HÀM LayDSThucDonThuocLoaiThucDonBatKy
function XL_ThucDon.LayDSThucDonThuocLoaiThucDonBatKy()
{
    var ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "DsThucDonThuocLoaiThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        arr = XL_THUC_DON.Khoi_tao_ds_thuc_don(goc)
        Th = document.getElementById("Th_ds_ThucDon_loai_thuc_don");
        maxRows = 3;
        XL_THUC_DON.Th_Danh_sach_thuc_don()
    }
}


function XL_ThucDon.DSThucDonTheoTag()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    var Tham_so = new XL_THAM_SO("xac_nhan","DS_thuc_don_theo_tag");
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        arr = XL_THUC_DON.Khoi_tao_ds_thuc_don(Goc)
        Th = document.getElementById("Th_ds_thuc_don_theo_tag");
        maxRows = 2;
        XL_THUC_DON.Th_Danh_sach_thuc_don()
    }
}

function XL_ThucDon.ChiTietThucDon(mathucdon)
{    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan","ChiTietThucDon"));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("mathucdon",mathucdon));

    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        Kq = XL_MON_AN.Khoi_tao_ds_mon_an(Goc);
    }
    return Kq;
}


function XL_ThucDon.LayTiLeGiamGiaThucDon()
{
    var ham = new XL_HAM("He phuc vu/XL_ThamSo");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayTiLeGiamGiaThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var str = goc.getAttribute("TiLeGiam").replace(",", ".")
        TiLeGiam = parseFloat(str);
        var nodeLable = document.getElementById("lblTiLeGiam");
        nodeLable.innerText += TiLeGiam;
    }
}

//Nghi : phan trang mon an
function XL_ThucDon.PhanTrang()
{
    var ham = new XL_HAM("He phuc vu/XL_Mon_An");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "TongSoTrang"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var tongSoTrang = parseInt(goc.getAttribute("TongSoTrang"));
        var tableTag = document.getElementById("tbodyPhanTrang");
        var tr = document.createElement("tr");
        for (var i = 1; i <= tongSoTrang; ++i)
        {
            var td = document.createElement("td");
            td.setAttribute("class", "alt1");
            var aTag = document.createElement("a");
            aTag.innerText = i;
            aTag.href="javascript:XL_ThucDon.LayDSMonAnHienThi(" + i + ")";
            td.appendChild(aTag);            
            tr.appendChild(td);
        }
        tableTag.appendChild(tr);
    }
    else
        alert("Lỗi đường truyền, không thực hiện phân trang được");
}

//Nghi : dùng cho việc hiển thị danh sách món ăn theo dạng bảng để lựa chọn món ăn trong chức năng
//thêm món mới
function XL_ThucDon.LayDSMonAnHienThi(pageNum)
{
    var ham = new XL_HAM("He phuc vu/XL_Mon_An");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSMonAnHienThi"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("pageNum", pageNum));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var tbody = document.getElementById("tbodyDSMonAnHienThi");
        while (tbody.firstChild != null)
        {
            tbody.removeChild(tbody.firstChild);
        }
        for(var i = 0; i<M.length; i++)
        {   
            var mamon = M[i].getAttribute("Ma_mon");
            var tenmon = M[i].getAttribute("Ten_mon");
            var hinhanh = M[i].getAttribute("Hinh_anh_minh_hoa");
            var mota = M[i].getAttribute("Mo_ta");
            var gia = M[i].getAttribute("Gia");
            var tinhtrang = M[i].getAttribute("Tinh_trang");
            var diem = parseInt(M[i].getAttribute("Diem_binh_chon"));
            
            var tr = document.createElement("tr");
            tr.id = "tr" + mamon;
            // STT
            var td = document.createElement("td");            
            var textNode = document.createTextNode(i + 1);
            td.appendChild(textNode);            
            tr.appendChild(td);
            
            // TenMon
            td = document.createElement("td");          
            textNode = document.createTextNode(tenmon);
            td.id = "mon" + mamon;
            td.appendChild(textNode);
            tr.appendChild(td);
            
            // HinhAnhMinhHoa
            td = document.createElement("td");     
            var img = document.createElement("img");
            img.src = hinhanh;
            img.width = "80";
            img.height = "80";
            td.appendChild(img);
            tr.appendChild(td);
            
            // MoTa
            td = document.createElement("td");          
            textNode = document.createTextNode(mota);
            td.appendChild(textNode);
            tr.appendChild(td);
            
            // Gia
            td = document.createElement("td");          
            textNode = document.createTextNode(gia);
            td.appendChild(textNode);
            tr.appendChild(td);
            
            // TinhTrang
            td = document.createElement("td");    
            var checked = (tinhtrang == 'True' ? 'checked' : '');      
            td.innerHTML = '<input type="checkbox" id="chkTinhTrang' + mamon + '" DISABLED ' + checked + '>';
            tr.appendChild(td);
            
            // DiemBinhChon
            td = document.createElement("td");          
            textNode = document.createTextNode(diem);
            td.appendChild(textNode);
            tr.appendChild(td);
                   
            
            // Nút chọn
            td = document.createElement("td"); 
            var but = document.createElement("input");
            but.type = "button";
            but.onclick= function() {XL_ThucDon.ChonMonAn(this);};
            but.value = "Chọn";
            but.MaMon = mamon;
            but.TenMon = tenmon;
            but.HinhAnh = hinhanh;
            but.Gia = gia;
            but.id = "butChon" + mamon;            
            //but.disable = (tinhtrang == 1 ? false : true);
            td.appendChild(but);
            tr.appendChild(td);
            
            tbody.appendChild(tr);
        }        
    }
    else
        alert("Lỗi đường truyền");
}

function XL_ThucDon.ChonMonAn(obj)
{
    var mamon = obj.MaMon;
    var tenmon = obj.TenMon;
    var hinhanh = obj.HinhAnh;
    var gia = obj.Gia;
        
    //kiem tra mon an da co trong ds hay chua
    var tbody = document.getElementById("tbodyDSMonAnChon");
//    //var child = tbody.firstChild;
//    if(DsMaMonAn != null)
//    {
//        for(var i = 0; i < DsMaMonAn.length; i++)
//        {            
//            if(DsMaMonAn[i] == mamon)
//                return;         
//        }
//    }   
    
    var table = document.getElementById("hor-minimalist-a");
    table.style.display = "block";
    
    var tbody = document.getElementById("tbodyDSMonAnChon");
    var tr = document.createElement('tr');
    tr.id = 'tr' + mamon;
    
    // STT
    var td = document.createElement("td");            
    td.innerHTML = tbody.rows.length + 1;
    tr.appendChild(td);
    
    // TenMon
    td = document.createElement("td");          
    textNode = document.createTextNode(tenmon);
    td.id = "mon" + mamon;
    td.appendChild(textNode);
    tr.appendChild(td);
    
    // HinhAnhMinhHoa
    td = document.createElement("td");     
    var img = document.createElement("img");
    img.src = hinhanh;
    img.width = "80";
    img.height = "80";
    td.appendChild(img);
    tr.appendChild(td);
    
    // Gia
    td = document.createElement("td");          
    textNode = document.createTextNode(gia);
    td.appendChild(textNode);
    tr.appendChild(td);
    
    // Button bỏ
    td = document.createElement("td"); 
    var but = document.createElement("input");
    but.type = "button";
    but.onclick= function() {XL_ThucDon.BoMonAn(this);};
    but.value = "Bỏ";
    but.MaMon = mamon;
    but.Gia = gia;
    but.id = "butBo" + mamon;        
    td.appendChild(but);
    tr.appendChild(td);
    
    tbody.appendChild(tr);
    
    var nodeGia = document.getElementById('txtGia');
    nodeGia.value = parseInt(nodeGia.value) + (parseInt(gia) - parseInt(gia) * TiLeGiam);
    
    DsMaMonAn.push(mamon);
}

function XL_ThucDon.BoMonAn(obj)
{
    var mamon = obj.MaMon;
    var gia = obj.Gia;
    var tbody = document.getElementById("tbodyDSMonAnChon");
    var tr = document.getElementById('tr' + mamon);
    
    tbody.removeChild(tr);
    
    var i;
    for(i = 0; i < DsMaMonAn.length; ++i)
    {
        if(DsMaMonAn[i] == mamon)
            break;
    }
    DsMaMonAn.splice(i, 1);
    var nodeGia = document.getElementById('txtGia');
    nodeGia.value = parseInt(nodeGia.value) - (parseInt(gia) - parseInt(gia) * TiLeGiam);
    
    var childs = tbody.childNodes;
    for(i = 0; i < childs.length; ++i)
    {
        var tr = childs[i];
        var tdSTT = tr.firstChild;
        tdSTT.innerText = i + 1;
    }
}

function XL_ThucDon.ThemThucDonMoi()
{
    //Lấy thông tin trên form
    var hinhanh = objTxtPathHinhAnh.value;
    var arr = new Array();
    arr = hinhanh.split("\\");
    hinhanh = "Hinh Anh/San Pham/Thuc Don/" + arr[arr.length-1];
    
    var ten = document.getElementById("txtTenThucDon").value;
    var maloai = objCmbLoaiThucDon.value;
    var mota = document.getElementById("txtMoTa").value;
    //var hinhanh = objTxtPathHinhAnh.value;
    var gia = document.getElementById("txtGia").value;
    var tinhtrang = (document.getElementById("optCon").checked == true);
    var hienthi = (document.getElementById("optHien").checked == true);
    var tag = document.getElementById("txtTag").value;
  
    if(ten == "")
    {    
        XL_CHUOI.Xuat("Lỗi: chưa nhập tên thực đơn!");
        return;
    }
    if(maloai == -1) //chưa chọn loại thực đơn
    {
        XL_CHUOI.Xuat("Lỗi: chưa chọn loại thực đơn!");
        return;
    }
   
    if(DsMaMonAn.length < 2)
    {
        XL_CHUOI.Xuat("Lỗi: thực đơn phải có hai món ăn trở lên!");
        return;
    }
    
    var chuoiDSMaMonAn = "";
    for(var i = 0; i < DsMaMonAn.length; ++i)
        chuoiDSMaMonAn += DsMaMonAn[i] + "-";
    
    if(mota == "")
        mota = "Không có";
    
    var ham = new XL_HAM("He Phuc Vu/XL_Thuc_Don");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ten", ten));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("maloai", maloai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mota", mota));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hinhanh", hinhanh));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("gia", gia));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tinhtrang", tinhtrang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hienthi", hienthi));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("tag", tag));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("dsmamonan", chuoiDSMaMonAn));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
    
    if(goc != null && goc.getAttribute("kq") == "true")
    {
        
        XL_CHUOI.Xuat("Thêm thành công!");   
        //redirect toi trang danh sach cac thuc don
    }
    else
        XL_CHUOI.Xuat("Thêm bị lỗi!");    
}


function XL_ThucDon.KhoiTao()
{
    document.getElementById("txtTenThucDon").value = "";
    objCmbLoaiThucDon.value = -1;
    document.getElementById("txtMoTa").value = "";;
    objTxtPathHinhAnh.value = "";
    document.getElementById("txtGia").value = 0;
    document.getElementById("optCon").checked = true;
    document.getElementById("optHien").checked = true;
    document.getElementById("txtTag").value = "";
    
    var table = document.getElementById("hor-minimalist-a");
    table.style.display = "none";
    
    DsMaMonAn = new Array();
    
    var tbody = document.getElementById("tbodyDSMonAnChon");
    while (tbody.firstChild != null)
    {
        tbody.removeChild(tbody.firstChild);
    }
}

/*function XL_THUC_DON.ThemMonMoi()
{
    //Lấy thông tin trên form
    var tenmon = document.getElementById("txtTenMon").value;
    
    var cmbLoaiMonIndex = document.getElementById("cmbLoaiMon").selectedIndex;
    var loaimon = document.getElementById("cmbLoaiMon")[cmbLoaiMonIndex].value;
    var tenloaimon = document.getElementById("cmbLoaiMon")[cmbLoaiMonIndex].innerHTML;
    
    //var hinhanh = document.getElementById("txtHinhAnh").value;
    var hinhanh = nodePathHinhAnh.value;
    var mota = document.getElementById("txtMoTa").value;
    var donvitinh = document.getElementById("cmbDonViTinh").value;
    var gia = document.getElementById("txtGia").value;
    if(gia == "")
        gia = "0";
    
    var tinhtrang = (document.getElementById("optCon").checked == true);
    var hienthi = (document.getElementById("optHien").checked == true);
    var tag = document.getElementById("txtTag").value;
    
    
    var ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemMonMoi"));
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
        
        var nodeTbody = document.getElementById("tbodyDSMon");
        var nodeNewRow = document.createElement("tr");
        
        var nodeColSTT = document.createElement("td");
        var nodeColHinhAnh = document.createElement("td");
        var nodeColTenMon = document.createElement("td");
        var nodeColLoaiMon = document.createElement("td");
        var nodeColGia = document.createElement("td");
        var nodeColTinhTrang = document.createElement("td");
        var nodeColHienThi = document.createElement("td");
        
        nodeColSTT.setAttribute("className", "helpBod");
        nodeColHinhAnh.setAttribute("className", "helpBod");
        nodeColTenMon.setAttribute("className", "helpBod");
        nodeColLoaiMon.setAttribute("className", "helpBod");
        nodeColGia.setAttribute("className", "helpBod");
        nodeColTinhTrang.setAttribute("className", "helpBod");
        nodeColHienThi.setAttribute("className", "helpBod");
        
        nodeColSTT.innerHTML = tbodyDSMon.rows.length;
        
        var nodeHA = document.createElement("img");
        nodeHA.src = hinhanh;
        nodeHA.width = "100";
        nodeHA.height = "100";
        nodeColHinhAnh.appendChild(nodeHA);


        nodeColTenMon.innerHTML = tenmon;
        nodeColLoaiMon.innerHTML = tenloaimon;
        nodeColGia.innerHTML = gia;
        nodeColTinhTrang.innerHTML = tinhtrang;
        nodeColHienThi.innerHTML = hienthi;
        
        
        nodeNewRow.appendChild(nodeColSTT);
        nodeNewRow.appendChild(nodeColHinhAnh);
        nodeNewRow.appendChild(nodeColTenMon);
        nodeNewRow.appendChild(nodeColLoaiMon);
        nodeNewRow.appendChild(nodeColGia);
        nodeNewRow.appendChild(nodeColTinhTrang);
        nodeNewRow.appendChild(nodeColHienThi);
        
        nodeTbody.appendChild(nodeNewRow);
        
    }
    else
        XL_CHUOI.Xuat("Thêm bị lỗi!");
}
*/
function XL_THUC_DON.Ghi_nhan_thuc_don(ma_thuc_don)
{
//    var obj = window.event.srcElement.parentNode.firstChild;
//    var parent = obj.parentNode.parentNode;
//    parent = parent.nextSibling;
//    var node = parent.firstChild.innerText;        
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_thuc_don");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma_thuc_don", ma_thuc_don);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    
    window.location = "ChiTietThucDon.aspx";
}

function XL_THUC_DON.Chi_tiet_thuc_don()
{    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Chi_tiet_thuc_don");
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        Th = document.getElementById("Th_Chi_tiet_thuc_don");
        arr = XL_MON_AN.Khoi_tao_ds_mon_an(Goc);
        XL_THUC_DON.Chi_tiet()
    }
    return Kq;
}

function XL_THUC_DON.Lay_ma_thuc_don()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Lay_ma_thuc_don");
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {
        Kq = Goc.getAttribute("Ma_thuc_don");
    }
    return Kq;
}

function XL_THUC_DON.Chi_tiet()
{    
    var temp;
    var m;
    var mathucdon = XL_THUC_DON.Lay_ma_thuc_don();
        
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

//    var arr = new Array();
//    arr = XL_THUC_DON.Chi_tiet_thuc_don();
    
    //xu ly phan trang
    var maxRows = 3;
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
    h1.appendChild(document.createTextNode("Danh Sách Món Ăn Của Thực Đơn"));    
    td.appendChild(h1);
    
    ///////////////////////////////////////////////////////////////////////////////
    tr = document.createElement("tr");
    tbody.appendChild(tr);
    td = document.createElement("td");
    td.align = "left";
    tr.appendChild(td);
    
    var table2 = document.createElement("table");
    var tbody2 = document.createElement("tbody");
    var tr2 = document.createElement("tr");
    tbody2.appendChild(tr2);
    table2.appendChild(tbody2);
    var td2 = document.createElement("td");
    td.appendChild(table2);
    
    var form = document.createElement("form");    
    form.method = "post";
    form.action = "TaoThucDonMoi_KH.aspx";
    td2.appendChild(form);    
    //var div = document.createElement("div");  
    //td.appendChild(div);                
    //div.style.textAlign = "center";
    input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "customize";        
    input.value = "Customize";
//    input.onclick =  "XL_ThucDonCaNhan.LoadDSMonChonTuThucDonCoSan(mathucdon)";
//    td.appendChild(input);
    form.appendChild(input);
    tr2.appendChild(td2);
    
    td2 = document.createElement("td");
    td2.align = "left";
    form = document.createElement("form");
    form.method = "post";
    form.action = "DanhSachThucDonYeuThich.aspx";
    td2.appendChild(form); 
    //div = document.createElement("div");  
    //td.appendChild(div);                
    //div.style.textAlign = "center";
    input = document.createElement("input");
    input.className = "submitbtn";
    input.type = "submit";
    input.name = "favorite";        
    input.value = "Favorite";
//    input.onclick =  "XL_ThucDonCaNhan.ThemThucDonUaThich(mathucdon)";
//    td.appendChild(input);
    form.appendChild(input);
    tr2.appendChild(td2);
    //////////////////////////////////////////////////////////////////////////////////
    
    tr = document.createElement("tr");
    tbody.appendChild(tr);
    td = document.createElement("td");    
    tr.appendChild(td);
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
            a.onclick = XL_THUC_DON.Chi_tiet;		
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
			        //a.href = "javascript:XL_MON_AN.Th_Danh_sach_mon_an()";
			        a.href = "#";
                    a.onclick = XL_THUC_DON.Chi_tiet;				        
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
	        //a.href = "javascript:XL_MON_AN.Th_Danh_sach_mon_an()";
	        a.href = "#";
            a.onclick = XL_THUC_DON.Chi_tiet;			
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
        
        form = document.createElement("form");
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
        div = document.createElement("div");
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
        div.display = 'none';
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

function XL_THUC_DON.Danh_sach_thuc_don()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_THUC_DON");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Lay_danh_sach");
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    
    if(Goc!=null)
    {
        arr = XL_THUC_DON.Khoi_tao_ds_thuc_don(Goc);
        Th = document.getElementById("div_Th_ds_thuc_don");
        maxRows = 3;
        XL_THUC_DON.Th_Danh_sach_thuc_don()
    }
    return Kq;
}

var curPg;

function XL_THUC_DON.Khoi_tao_the_hien(_arr, _Th)
{
    arr = _arr;
    Th = _Th;
}

function XL_THUC_DON.Th_Danh_sach_thuc_don()
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
    h1.appendChild(document.createTextNode("Danh Sách Thực Đơn"));    
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
            a.onclick = XL_THUC_DON.Th_Danh_sach_thuc_don;		    
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
			        //a.href = "javascript:XL_THUC_DON.Th_Danh_sach_thuc_don()";
			        a.href = "#";
                    a.onclick = XL_THUC_DON.Th_Danh_sach_thuc_don;		    		    
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
	        //a.href = "javascript:XL_THUC_DON.Th_Danh_sach_thuc_don()";
	        a.href = "#";
            a.onclick = XL_THUC_DON.Th_Danh_sach_thuc_don;		    		    
			a.appendChild(document.createTextNode("Next"));
			td3.appendChild(a);
	    }
    }
    
    //tạo danh sách các thực đơn ở trong
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
	
        var thuc_don = arr[(curRow-1) * 3 + j];////////////
        
        if((j+1) % 3 == 0)//////////
        {
            curRow++;
            j = -1;
        }                
        
       // if(curRow<low)
		//    continue;
        if(thuc_don.TrangThaiHienThi == false)
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
        hidden.value = thuc_don.MaThucDon;
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
        td2.appendChild(document.createTextNode(thuc_don.TenThucDon));
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
        div.appendChild(document.createTextNode("1 phan"));
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
        img.src = thuc_don.HinhAnhMinhHoa;
        img.width = 140;
        img.height= 130;
        //img.onclick = XL_THUC_DON.Ghi_nhan_thuc_don;
        p.appendChild(img);
        
        p.appendChild(document.createElement("br"));
        var a = document.createElement("a");
        a.href = "javascript:XL_THUC_DON.Ghi_nhan_thuc_don("+thuc_don.MaThucDon+")";
        a.appendChild(document.createTextNode("Chi Tiết"));
        p.appendChild(a);
        td2.appendChild(p);
        tr2.appendChild(td2);
          
        //Don Gia   
        var arr1 = new Array();
        arr1 = thuc_don.Gia.split('.');
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "middle";
        td2.align = "right";
        div = document.createElement("div");     
        div.id = "proID";
        div.style.display = "none";
        div.appendChild(document.createTextNode(thuc_don.MaThucDon));
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
        input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang_thuc_don ;
        div.appendChild(input);
        
        div = document.createElement("div");  
        form = document.createElement("form");
        form.method = "post";
        form.action = "TaoThucDonMoi_KH.aspx";
        div.appendChild(form);
                
        td2.appendChild(div);                
        div.style.textAlign = "center";
        input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "customize";        
        input.value = "Customize";
        input.onclick =  XL_ThucDonCaNhan.Ghi_nhan_thuc_don ;        
        form.appendChild(input);
                                
        tr2.appendChild(td2);               
    }
    Th.innerHTML = "";
    Th.appendChild(table);
}


function XL_THUC_DON.Khoi_tao_ds_thuc_don(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var td = new Thuc_Don();
        td.MaThucDon = M[i].getAttribute("Ma_thuc_don");
        td.TenThucDon = M[i].getAttribute("Ten_thuc_don");
        td.HinhAnhMinhHoa = M[i].getAttribute("Hinh_anh_minh_hoa");        
        td.Gia = M[i].getAttribute("Gia");
        td.MaLoaiThucDon = M[i].getAttribute("Ma_loai_thuc_don");
        td.TinhTrang = M[i].getAttribute("Tinh_trang");
        td.TrangThaiHienThi = M[i].getAttribute("Trang_thai_hien_thi");
        Kq.push(td);
    }
    return Kq;
}
