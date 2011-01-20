// JScript File
function XL_DonHang()
{
    this.MaDonHang = -1;
    this.MaKhachHang = -1;
    this.DiaChiNhan = "";
    this.NguoiNhan = ""
    this.NgayGioLap = "";
    this.NgayGioGiaoHang = "";
    this.LoaiDonDatHang = -1;
    this.HinhThucKhuyenMai = -1;
    this.TienKhuyenMai = 0;
    this.GiaTri = 0;
    this.MaHinhThucThanhToan = -1;
    this.DaDatHang = "";
    this.DaThanhToan = "";
    this.DaGiaoHang = "";
}

var chuoiThu = "Hai,Ba,Tu,Nam,Sau,Bay,Chu Nhat,";
var chuoiNgay = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,20,30,31,";

function XL_DonHang.LayDSLoaiDK(nodename)
{
    var th = document.getElementById(nodename);
    var nodeOpt;  
        
    nodeOpt = document.createElement("option");
    nodeOpt.innerHTML = "--Chọn--";
    nodeOpt.value = 0;
    th.appendChild(nodeOpt);
            
    nodeOpt = document.createElement("option");
    nodeOpt.innerHTML = "Hang Tuan";
    nodeOpt.value = 1;
    th.appendChild(nodeOpt);
        
    nodeOpt = document.createElement("option");
    nodeOpt.innerHTML = "Hang Thang";
    nodeOpt.value = 2;
    th.appendChild(nodeOpt);
}

function ChonItem()
{
    ChonItemFromTo("listDS", "listDSChon");
}

function ChonItemFromTo(l1, l2)
{
    var subs1 = document.getElementById(l1);
    var subs2 = document.getElementById(l2);
    
    if(subs1 && subs2)
    {
        if(subs1.selectedIndex == -1)
            return;
            
        subs2.appendChild(subs1.options[subs1.selectedIndex]);
    }
}

function ChonTatCaItem()
{
    ChonTatCaItemFromTo("listDS", "listDSChon");
}

function ChonTatCaItemFromTo(l1, l2)
{
    var subs1 = document.getElementById(l1);
    var subs2 = document.getElementById(l2);
    
    if(subs1 && subs2)    
        while(subs1.options.length > 0)
        {
            subs2.appendChild(subs1.firstChild);            
        }                    
}

function BoItem()
{
    ChonItemFromTo("listDSChon", "listDS");
}
    
function BoTatCaItem()
{
    ChonTatCaItemFromTo("listDSChon", "listDS");
}

function XL_DonHang.ChonLoaiDinhKy()
{
    var index = document.getElementById("cmbLoaiDK").value;
    var loai = document.getElementById("cmbLoaiDK")[index].innerHTML;
    var td1 = document.getElementById("tdDS");
    var td2 = document.getElementById("tdDSChon");
    
    if(td1.hasChildNodes())
        td1.removeChild(td1.firstChild);
    if(td2.hasChildNodes())
        td2.removeChild(td2.firstChild);
    var lb1 = document.createElement("label");
    var lb2 = document.createElement("label");
    
    var listDS = document.getElementById("listDS");
    var listDSChon = document.getElementById("listDSChon");
    while(listDS.hasChildNodes())
        listDS.removeChild(listDS.firstChild);
    while(listDSChon.hasChildNodes())
        listDSChon.removeChild(listDSChon.firstChild);
        
    if(loai == "Hang Tuan")
    {
        lb1.innerHTML = "Thứ giao hàng trong tuần";
        lb2.innerHTML = "Thứ giao hàng đã chọn";
        LayDS(chuoiThu);
    }
    else if(loai == "Hang Thang")
    {
        lb1.innerHTML = "Ngày giao hàng trong tháng";
        lb2.innerHTML = "Ngày giao hàng đã chọn";
        LayDS(chuoiNgay);
    }
    
    td1.appendChild(lb1);
    td2.appendChild(lb2);
}

function LayDS(chuoiDS)
{
    var mangDS = chuoiDS.split(',');
    var listDS = document.getElementById("listDS");
    var opt; 
    for(var i=0; i<mangDS.length-1; i++)
    {
        opt = document.createElement("option");
        opt.value = i;
        opt.innerHTML = mangDS[i];
        listDS.appendChild(opt);
    }
}

function LayDSChon(chuoiDSChon)
{
    var mangDSChon = chuoiDSChon.split(',');
    var listDSChon = document.getElementById("listDSChon");

    var opt; 
    for(var i=0; i<mangDSChon.length-1; i++)
    {
        opt = document.createElement("option");
        opt.value = i;
        opt.innerHTML = mangDSChon[i];
        listDSChon.appendChild(opt);
    }
}

function KoSuDungQuyenKM()
{
    var nodeDiemSD = document.getElementById("cmbDiemSD");
    var nodeHTKM = document.getElementById("cmbHTKM");
    var nodeChon = document.getElementById("btChon");
    var txtKM = document.getElementById("txtKM");
    var txtTT = document.getElementById("txtTT");
    var tienhang = document.getElementById("txtGiaTri").innerHTML;
    var tienthue = document.getElementById("txtThue").innerHTML;
    
    nodeDiemSD.disabled = true;
    nodeHTKM.disabled = true;
    nodeChon.disabled = true;
    
    txtKM.innerHTML = 0;
    txtTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue);
}


function CoSuDungQuyenKM()
{
    var nodeDiemSD = document.getElementById("cmbDiemSD");
    var nodeHTKM = document.getElementById("cmbHTKM");
    var nodeChon = document.getElementById("btChon");
    var txtKM = document.getElementById("txtKM");
    var txtTT = document.getElementById("txtTT");
    var txtGiaTriQT = document.getElementById("txtGiaTriQT");
    
    var htkm = nodeHTKM[nodeHTKM.selectedIndex].innerHTML;
    var tienhang = document.getElementById("txtGiaTri").innerHTML;
    var tienthue = document.getElementById("txtThue").innerHTML;
    
    nodeDiemSD.disabled = false;
    nodeHTKM.disabled = false;
    if(htkm == "Qua Tang ")
        nodeChon.disabled = false;
    
    txtKM.innerHTML = txtGiaTriQT.innerHTML;
    
    if(htkm == "Giam Gia ")
        txtTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue) - parseFloat(txtKM.innerHTML);
    
}

function TinhSoDiemToiDa(nodename)
{
    var nodeGT = document.getElementById("txtGiaTri");  //tong gia tri hang
    var giatri = nodeGT.innerHTML;
    
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Tinh_so_diem_toi_da");
    Ham.Danh_sach_tham_so.push(Tham_so);    
    Tham_so = new XL_THAM_SO("GiaTri", giatri);
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    {
        var Kq = Goc.getAttribute("Kq");
        Kq = parseInt(Kq);
        
        //load len tb diem toi da
        var nodediv = document.getElementById("div_DiemTD");
        var nodeDiem= document.createElement("label");
        nodeDiem.id = "txtDiemTD";
        nodeDiem.innerHTML = Kq;
        nodediv.appendChild(nodeDiem);
        
        //load combox chon diem sd
        var th = document.getElementById(nodename);
        var nodeOpt;  
        
        nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn--";
        nodeOpt.value = 0;
        nodeOpt.id = "DiemSDoption" + nodeOpt.value;
        th.appendChild(nodeOpt);
            
        for(var i = 1; i <= Kq; i++)
        {            
            nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = i + "";
            nodeOpt.value = i;
            nodeOpt.id = "DiemSDoption" + nodeOpt.value;
            th.appendChild(nodeOpt);
        }       
        th.selectedIndex = 0;
        
        if(Kq == 0)
        {
            var rdCo = document.getElementById("rdCo");
            var rdKo = document.getElementById("rdKo");
            var sec = document.getElementById("section8");
            var p = document.createElement("p");
            p.innerHTML = "* Bạn không đủ điểm để tham gia chương trình khuyến mãi";
            sec.appendChild(p);
            
            rdCo.disabled = true;
            rdKo.disabled = true;
            th.disabled = true;
            
            // khoi tao tong gia tri qua tang
            var nodediv = document.getElementById("div_GTQT");
            if(nodediv.hasChildNodes())
                nodediv.removeChild(nodediv.firstChild);
            var nodeGiaTri = document.createElement("label");
            nodeGiaTri.id = "txtGiaTriQT";
            nodeGiaTri.innerHTML = 0;
            nodediv.appendChild(nodeGiaTri);
            
            // khoi tao gia tri khuyen mai
            var node = document.getElementById("div_KM");
            if(node.hasChildNodes())
                node.removeChild(node.firstChild);
                
            var nodeKM= document.createElement("label");
                
            nodeKM.id = "txtKM";
            nodeKM.innerHTML = 0;
            node.appendChild(nodeKM);
            
            // khoi tao tong gia tri
            node = document.getElementById("div_TT");
            if(node.hasChildNodes())
                node.removeChild(node.firstChild);
                
            var nodeTT = document.createElement("label");
            var tienhang = document.getElementById("txtGiaTri").innerHTML;
            var tienthue = document.getElementById("txtThue").innerHTML;
            
            nodeTT.id = "txtTT";
            nodeTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue);
            node.appendChild(nodeTT);  
        }
    }
}

function TinhTien()
{
    var nodeSoTien = document.getElementById("lbSoTien");
    var diemtd = document.getElementById("txtDiemTD");
    var diem = document.getElementById("cmbDiemSD").value;
    if(diem != 0)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Tinh_tien_khuyen_mai");
        Ham.Danh_sach_tham_so.push(Tham_so);    
        Tham_so = new XL_THAM_SO("DiemKhuyenMai", diem);
        Ham.Danh_sach_tham_so.push(Tham_so);
        var Kq;
        var Goc = Ham.Thuc_hien();
        {
            Kq = Goc.getAttribute("Kq");
            Kq = parseInt(Kq);
            nodeSoTien.innerHTML = Kq;
        }
        
        var nodeHTKM = document.getElementById("cmbHTKM");
        nodeHTKM.disabled = false;
        
        //load lại 2 giá trị khuyến mãi + tổng tiền phải trả nếu chọn giảm giá
        var nodeIndex = nodeHTKM.selectedIndex;
        var tenHTKM = nodeHTKM[nodeIndex].innerHTML;
        if(tenHTKM == "Giam Gia ") 
        {
            //tổng giá trị khuyến mãi
            var nodediv = document.getElementById("div_GTQT");
            var nodeGT = document.createElement("label");
            if(nodediv.hasChildNodes() == true)    
            {
                nodediv.removeChild(nodediv.firstChild);       
                nodeGT.id = "txtGiaTriQT";          
                nodeGT.innerHTML = Kq;
                nodediv.appendChild(nodeGT);
            }
            //giá trị khuyến mãi
            var node = document.getElementById("div_KM");
            nodeKM = document.getElementById("txtKM");
            nodeKM.innerHTML = Kq;
            
            //Load tổng tiền phải trả
            var nodeTT = document.getElementById("txtTT");
            var tienhang = document.getElementById("txtGiaTri").innerHTML;
            var tienthue = document.getElementById("txtThue").innerHTML;
                    
            nodeTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue) - Kq; 
        }
    }
}

function ChonHinhThucKhuyenMai()
{
    var nodeIndex = document.getElementById("cmbHTKM").selectedIndex;
    var tenHTKM = document.getElementById("cmbHTKM")[nodeIndex].innerHTML;
    
    var node = document.getElementById("btChon");
    if(tenHTKM == "Qua Tang ")       
    {
        var nodeSoTien = document.getElementById("txtGiaTriQT");
        
        node.disabled = false;
    }
    else if(tenHTKM == "Giam Gia ")
    {   
        node.disabled = true;
        
        var nodeSoTien = document.getElementById("lbSoTien");
        var nodediv = document.getElementById("div_GTQT");
        var nodeGT = document.createElement("label");
        
        //Khoi tao tong gia tri khuyen mai
        if(nodediv.hasChildNodes() == true)    
        {
            nodediv.removeChild(nodediv.firstChild);
            
            nodeGT.id = "txtGiaTriQT";
            
            nodeGT.innerHTML = nodeSoTien.innerHTML;
            nodediv.appendChild(nodeGT);
        }
        
        //Load gia tri khuyen mai
        var node = document.getElementById("div_KM");
        nodeKM = document.getElementById("txtKM");
        nodeKM.innerHTML = nodeSoTien.innerHTML;
        
        //Load tổng tiền phải trả
        var nodeTT = document.getElementById("txtTT");
        var tienhang = document.getElementById("txtGiaTri").innerHTML;
        var tienthue = document.getElementById("txtThue").innerHTML;
                
        nodeTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue) - parseFloat(nodeSoTien.innerHTML);
    }
}

function ChonHinhThucThanhToan()
{
    var nodeIndex = document.getElementById("cmbHTTT").selectedIndex;
    var tenHTKM = document.getElementById("cmbHTTT")[nodeIndex].innerHTML;
    
    var nodeMD = document.getElementById("rdMacDinh");
    var nodeK = document.getElementById("rdKhac");
    var nodebt = document.getElementById("btnThanhToan");
    
    if(tenHTKM != "The Tin Dung ")       
    {
        nodeMD.disabled = true;
        nodeK.disabled = true;
        nodebt.value = "Đặt hàng";
    }
    else
    {
        nodeMD.disabled = false;
        nodeK.disabled = false;
        nodebt.value = "Đặt hàng và Thanh toán";
    }
}

function ChonMacDinh()
{
    var nodeK = document.getElementById("rdKhac");
    nodeK.checked = false;
    
    //Load lai the mac dinh
    nodeLoaiThe.disabled = true;
    nodeSoThe.disabled = true;
    nodeNgayHH.disabled = true;
    nodeThangHH.disabled = true;
    nodeNamHH.disabled = true;
}

function ChonTheKhac()
{
    var nodeMD = document.getElementById("rdMacDinh");
    nodeMD.checked = false;
    nodeLoaiThe.disabled = false;
    nodeSoThe.disabled = false;
    nodeNgayHH.disabled = false;
    nodeThangHH.disabled = false;
    nodeNamHH.disabled = false;
}

function XL_DonHang.LoadCmbNum(nodename, canduoi, cantren)
{
    var node = document.getElementById(nodename);
    
    for(var i = canduoi; i <= cantren; ++i)
    {
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = i;
        nodeOpt.value = i;
        node.appendChild(nodeOpt);
    }
    node.selectedIndex = 0;
}

function XL_DonHang.KTThongTinNhan()
{
    var Kq = "";
    
    var nodeNN = document.getElementById("txtNguoiNhan");
    var nodeDCN = document.getElementById("txtDiaChiNhan");
    if(nodeNN.value == "")
        Kq = "Chưa nhập tên người nhận hàng\n";
    if(nodeDCN.value == "")
        Kq += "Chưa nhập địa chỉ nhận hàng\n";
        
    return Kq;
}

function XL_DonHang.KiemTraHTKM()
{
    var Kq = "";
    
    var noderdCo = document.getElementById("rdCo");
    var nodeDiemSD = document.getElementById("cmbDiemSD");
    var HTKMIndex = document.getElementById("cmbHTKM").selectedIndex;
    var tenHTKM = document.getElementById("cmbHTTT")[HTKMIndex].innerHTML;
    var nodetxtGiaTriQT = document.getElementById("txtGiaTriQT");
    
    if(noderdCo.checked == true)
    {
        if(nodeDiemSD.selectedIndex == 0)
            Kq += "Chưa chọn số điểm sử dụng\n";
        else if(HTKMIndex == 0)
            Kq += "Chưa chọn hình thức khuyến mãi\n";
        else if(tenHTKM == "Qua Tang " && nodetxtGiaTriQT == "0")
            Kq += "Chưa chọn quà tặng\n";
    }      
    return Kq;  
}

function XL_DonHang.KiemTraHTTT()
{
    var Kq = "";
    
    var HTTTIndex = document.getElementById("cmbHTTT").selectedIndex;
    var tenHTTT = document.getElementById("cmbHTTT")[HTTTIndex].innerHTML;   
    var noderdKhac = document.getElementById("rdKhac");
    
    if(HTTTIndex == 0)
        Kq += "Chưa chọn hình thức thanh toán\n";
    else if(tenHTTT == "The Tin Dung " && nodeSoThe.value == "")
            Kq += "Chưa nhập số thẻ\n";
    //con kiem tra ngay het han nua     
    return Kq;  
}

function XL_DonHang.KiemTraTTDinhKy()
{
    var Kq = "";
    
    var LoaiDKindex = document.getElementById("cmbLoaiDK").value;
    dsChon = document.getElementById("listDSChon");
    
    var cmbNgay1 = parseInt(document.getElementById("cmbNgayBD").value);        
    var cmbThang1 = parseInt(document.getElementById("cmbThangBD").value);
    var cmbNam1 = parseInt(document.getElementById("cmbNamBD").value);
    //var ngaybd = new Date(cmbNgay.value + "/" + cmbThang.value + "/" + cmbNam.value);
        
    var cmbNgay2 = parseInt(document.getElementById("cmbNgayKT").value);        
    var cmbThang2 = parseInt(document.getElementById("cmbThangKT").value);
    var cmbNam2 = parseInt(document.getElementById("cmbNamKT").value);
    //var ngaykt = new Date(cmbNgay.value + "/" + cmbThang.value + "/" + cmbNam.value);
    
    var loaiDK = document.getElementById("cmbLoaiDK")[LoaiDKindex].innerHTML;
      
    if(LoaiDKindex == 0)
        Kq += "Chưa chọn loại định kỳ\n";
    if(SoSanhNgay(cmbNgay1, cmbThang1, cmbNam1, cmbNgay2, cmbThang2, cmbNam2, loaiDK) == false)
        Kq += "Ngày kết thúc không hợp lệ\n";
    if(dsChon.hasChildNodes() == false)
        Kq += "Chưa chọn thời gian giao định kỳ\n";
        
    return Kq;
}

function SoSanhNgay(cmbNgay1, cmbThang1, cmbNam1, cmbNgay2, cmbThang2, cmbNam2, loaiDK)
{
    var n = 0;
    var m = 0;
    
    if(loaiDK == "--Chọn--")
        return false;
    else if (loaiDK == "Hang Tuan")
        n = 7;
    else if(loaiDK == "Hang Thang")
        n = 1;
    if(cmbNam2 >= cmbNam1)
    {
        if(cmbNam2 > cmbNam1)
            return true;
        else
            if(cmbThang2 >= cmbThang1 + m)
                if(cmbThang2 > cmbThang1)
                    return true;
                else
                    if(cmbNgay2 >= cmbNgay1 + n)
                        return true;
                    else
                        return false;
            else
                return false;
    }
    else
        return false;
}

function XL_DonHang.KTHopLe(flag)
{
    // Kiem tra hop le
    var Kq = "";
    if(nodeLoaiND.value == "KhachHang")
    {
        Kq += XL_DonHang.KiemTraHTKM();
        Kq += XL_DonHang.KiemTraHTTT();     
        if(flag == 1)   //dinh ky
            Kq += XL_DonHang.KiemTraTTDinhKy();
    }
    else
        Kq += XL_DonHang.KTThongTinNhan();
    return Kq;
}

function XL_DonHang.DatHang(loaiyeucau)
{
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    if(nodeLoaiND.value == "KhachHang")
    {
        var btnLuu = document.getElementById("btnLuu");
        if(btnLuu.disabled == true) // đã chọn lưu đon hàng --> đặt hàng
        {
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Dat_don_hang_da_luu"));
            var Goc = Ham.Thuc_hien();
            if(Goc != null)
            {
                var kq = Goc.getAttribute("kq");
                alert(kq);
                var flag = Goc.getAttribute("flag");
                if(flag == "true")
                {
                    if(nodeLoaiND.value == "KhachHang")
                    {   
                        //binh thuong or dinh ky
                        //dat hang or luu don hang
                        if(loaiyeucau == 2 || loaiyeucau == 3)  //dinh ky
                        {   
                            if(loaiyeucau == 2) // luu don hang
                                XL_DonHang.DisabledForm_Customer(2); 
                            else
                                XL_DonHang.DisabledForm_Customer(3); 
                        }
                        else
                        {
                            if(loaiyeucau == 0) // luu don hang
                                XL_DonHang.DisabledForm_Customer(0);
                            else
                                XL_DonHang.DisabledForm_Customer(1);
                        }
                    }
                    else
                        XL_DonHang.DisabledForm_Guest();   
                }
            }
            return;
        }
    }    
    var Kq;
    if(nodeLoaiND.value == "KhachHang" && (loaiyeucau == 2 || loaiyeucau == 3))  //dinh ky
        Kq = XL_DonHang.KTHopLe(1);
    else
        Kq = XL_DonHang.KTHopLe(0);
    if(Kq != "")
    {
        XL_CHUOI.Xuat(Kq);
        return;
    }
    
    // Lấy các tham số
   
    var nguoinhan;
    var diachinhan;
    
    //***NEU LA KHACH HANG//
    if(nodeLoaiND.value == "KhachHang")
    {
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Dat_hang_customer"));
        
        var HTKM = document.getElementById("cmbHTKM").value;
        var HTTT = document.getElementById("cmbHTTT").value;
        if(HTKM == 0)
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("HTKM", -1));
        else
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("HTKM", HTKM));
        
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("HTTT", HTTT));
        //Neu su dung TT = the tin dung
        var tenHTTT = document.getElementById("cmbHTTT")[HTTT].innerHTML;
        if(tenHTTT == "The Tin Dung ")
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Thanh_toan", 1));
        else
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Thanh_toan", 0));
            
        //***//
        //Neu su dung the tin dung khac mac dinh
        var thekhac = document.getElementById("rdKhac");
        if(thekhac.checked == true)
        {
            var maloaithe = nodeLoaiThe[nodeLoaiThe.selectedIndex].value;
            var tenloaithe = nodeLoaiThe[nodeLoaiThe.selectedIndex].innerHTML;
            var sothe = SHA1(nodeSoThe.value); // mã hóa số thẻ
            var ngayhh = nodeNgayHH.value + "/" + nodeThangHH.value + "/" + nodeNamHH.value; 
            
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ma_loai_the", maloaithe));
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ten_loai_the", tenloaithe));
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("So_the", sothe));
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ngay_hh", ngayhh));
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("The_khac", 1));
        }
        else
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("The_khac", 0));
        
        var tienkhuyenmai = document.getElementById("txtKM").innerHTML;
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Tien_khuyen_mai", tienkhuyenmai));
         
        nguoinhan = nodeNguoiNhan.value;    
        diachinhan = nodeDiaChiNhan.value;  
        if(loaiyeucau == 0) // lưu đơn hàng
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Loai_yeu_cau", 0));
        else if(loaiyeucau == 1)    // đặt hàng
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Loai_yeu_cau", 1));
        else if(loaiyeucau == 2)    // luu don hàng dinh ky
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Loai_yeu_cau", 2));
        else if(loaiyeucau == 3)    // đặt hàng dinh ky
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Loai_yeu_cau", 3));
    }
    else //***NEU LA KHACH//
    {
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Dat_hang_guest"));
        nguoinhan = document.getElementById("txtNguoiNhan").value;    
        diachinhan = document.getElementById("txtDiaChiNhan").value;  
    }
    
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Dia_chi_nhan", diachinhan));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Nguoi_nhan", nguoinhan));  
    
    if(loaiyeucau == -1 || loaiyeucau == 0 || loaiyeucau == 1)  //neu dat hang binh thuong va dat hang guest
    {
        var cmbNgay = document.getElementById("cmbNgayGH");        
        var cmbThang = document.getElementById("cmbThangGH");
        var cmbNam = document.getElementById("cmbNamGH");
        var cmbGio = document.getElementById("cmbGioGH");
        var cmbPhut = document.getElementById("cmbPhutGH");
        var cmbBuoi = document.getElementById("cmbBuoiGH");   
        var ngaygiao = cmbNgay.value + "/" + cmbThang.value + "/" + cmbNam.value;
        ngaygiao += " " + cmbGio.value + ":" + cmbPhut.value + ":00 " + cmbBuoi.value;
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ngay_giao", ngaygiao));
    }
    else if(loaiyeucau == 2 || loaiyeucau == 3)//them cac tham so dinh ky
    {
        var index = document.getElementById("cmbLoaiDK").value; 
        var loaidk = document.getElementById("cmbLoaiDK")[index].innerHTML; 
        
        var cmbNgay = document.getElementById("cmbNgayBD");        
        var cmbThang = document.getElementById("cmbThangBD");
        var cmbNam = document.getElementById("cmbNamBD");
        var ngaybd = cmbNgay.value + "/" + cmbThang.value + "/" + cmbNam.value;
        
        cmbNgay = document.getElementById("cmbNgayKT");        
        cmbThang = document.getElementById("cmbThangKT");
        cmbNam = document.getElementById("cmbNamKT");
        var ngaykt = cmbNgay.value + "/" + cmbThang.value + "/" + cmbNam.value;
        
        var thoigiangiao = XL_DonHang.LayThoiGianGiaoDinhKy();
        
        var cmbGio = document.getElementById("cmbGioGH");
        var cmbPhut = document.getElementById("cmbPhutGH");
        var cmbBuoi = document.getElementById("cmbBuoiGH");   
        var giogiao = cmbGio.value + ":" + cmbPhut.value + ":00 " + cmbBuoi.value;
        
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Loai_dk", loaidk));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ngay_bd", ngaybd));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ngay_kt", ngaykt));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Thoi_gian_giao", thoigiangiao));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Gio_giao", giogiao));
    }
    
    var time = new Date();
    
    var ngaylap = time.getDate() +"/"+(time.getMonth() + 1)+"/"+time.getFullYear()+" ";
    
    if(time.getHours() >= 12)
    {
        var hour = time.getHours()-12;
        ngaylap += hour+":"+time.getMinutes()+":00 PM";
    }
    else
        ngaylap += time.getHours()+":"+time.getMinutes()+":00 AM";
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ngay_lap", ngaylap));    
    var giatri = document.getElementById("txtTT").innerHTML;
    var tienthue = document.getElementById("txtThue").innerHTML;
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Gia_tri", giatri));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Tien_thue", tienthue));
    
    //Thuc hien
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        var kq = Goc.getAttribute("kq");
        alert(kq);
        var flag = Goc.getAttribute("flag");
        if(flag == "true")
        {
            if(nodeLoaiND.value == "KhachHang")
            {   
                //binh thuong or dinh ky
                //dat hang or luu don hang
                if(loaiyeucau == 2 || loaiyeucau == 3)  //dinh ky
                {   
                    if(loaiyeucau == 2) // luu don hang
                        XL_DonHang.DisabledForm_Customer(2); 
                    else
                        XL_DonHang.DisabledForm_Customer(3); 
                }
                else
                {
                    if(loaiyeucau == 0) // luu don hang
                        XL_DonHang.DisabledForm_Customer(0);
                    else
                        XL_DonHang.DisabledForm_Customer(1);
                }
            }
            else
                XL_DonHang.DisabledForm_Guest();   
        }
    }
}

function XL_DonHang.LayThoiGianGiaoDinhKy()
{
    var kq = "";
    var node = document.getElementById("listDSChon");
    var index;
    for(var i=0; i<node.length-1; i++)
    {   
        //index = node[i].value;
        kq +=  node[i].innerHTML + "-";
    }
    kq += node[i].innerHTML;
    return kq;
}

function XL_DonHang.DisabledForm_Customer(flag)
{
    document.getElementById("rdCo").disabled = true;
    document.getElementById("rdKo").disabled = true;
    document.getElementById("cmbDiemSD").disabled = true;
    document.getElementById("cmbHTKM").disabled = true;
    document.getElementById("btChon").disabled = true;
    document.getElementById("cmbHTTT").disabled = true;
    document.getElementById("rdMacDinh").disabled = true;
    document.getElementById("rdKhac").disabled = true;
    nodeNguoiNhan.disabled = true;
    nodeDiaChiNhan.disabled = true;
    nodeLoaiThe.disabled = true;
    nodeSoThe.disabled = true;
    nodeNgayHH.disabled = true;
    nodeThangHH.disabled = true;
    nodeNamHH.disabled = true;
    document.getElementById("cmbGioGH").disabled = true;
    document.getElementById("cmbPhutGH").disabled = true;
    document.getElementById("cmbBuoiGH").disabled = true;
    document.getElementById("btnQuayLai").disabled = true;
    document.getElementById("btnLuu").disabled = true;
    
    if(flag == 2 || flag == 3)   // form dinh ky
    {
        document.getElementById("cmbLoaiDK").disabled = true;
        document.getElementById("cmbNgayBD").disabled = true;
        document.getElementById("cmbThangBD").disabled = true;
        document.getElementById("cmbNamBD").disabled = true;
        document.getElementById("cmbNgayKT").disabled = true;
        document.getElementById("cmbThangKT").disabled = true;
        document.getElementById("cmbNamKT").disabled = true;
        
        document.getElementById("chon").disabled = true;
        document.getElementById("chontatca").disabled = true;
        document.getElementById("bo").disabled = true;
        document.getElementById("botatca").disabled = true;
        
        document.getElementById("listDS").disabled = true;
        document.getElementById("listDSChon").disabled = true;
    }
    else
    {
        document.getElementById("cmbNgayGH").disabled = true;
        document.getElementById("cmbThangGH").disabled = true;
        document.getElementById("cmbNamGH").disabled = true;
    }
    if(flag == 1 || flag == 3)   // dat hang
        document.getElementById("btnThanhToan").disabled = true;
}

function XL_DonHang.DisabledForm_Guest()
{
    document.getElementById("txtNguoiNhan").disabled = true;
    document.getElementById("txtDiaChiNhan").disabled = true;
   
    document.getElementById("cmbNgayGH").disabled = true;
    document.getElementById("cmbThangGH").disabled = true;
    document.getElementById("cmbNamGH").disabled = true;
    document.getElementById("cmbGioGH").disabled = true;
    document.getElementById("cmbPhutGH").disabled = true;
    document.getElementById("cmbBuoiGH").disabled = true;
    
    document.getElementById("btnQuayLai").disabled = true;
    document.getElementById("btnThanhToan").disabled = true;
}

var TongGiaTriHoaDon = 0;

function XL_DonHang.DsSanPham()
{
    var Th = document.getElementById("Th_ds_san_pham");
   
   //lay thong tin gio hang
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Them_vao_gio_hang");
    Ham.Danh_sach_tham_so.push(Tham_so); 
    var Goc = Ham.Thuc_hien();
    var arr = new Array();
    if(Goc != null)
    {        
        arr = XL_GIO_HANG.Khoi_tao_gio_hang(Goc)
    }
    else
        return;
    
    var table3 = document.createElement("table");
    table3.align = "center";
    table3.width = "100%";
    table3.border = "1";        
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    var td3 = document.createElement("td");
    td3.width = "15%";
    td3.appendChild(document.createTextNode("Ma Item"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "35%";
    td3.appendChild(document.createTextNode("Ten Item"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "10%";
    td3.appendChild(document.createTextNode("So Luong"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "20%";
    td3.appendChild(document.createTextNode("Don Gia(VND)"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "20%";
    td3.appendChild(document.createTextNode("Tri Gia(VND)"));
    tr3.appendChild(td3);
    
    for(var i = 0; i < arr.length; i++)
    {
        var gio_hang = arr[i];
        TongGiaTriHoaDon += parseInt(gio_hang.TongGiaMonAn);
        tr3 = document.createElement("tr");
        tbody3.appendChild(tr3);
        td3 = document.createElement("td");
        td3.width = "15%";        
        td3.appendChild(document.createTextNode(gio_hang.MaMon));        
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "35%";        
        td3.appendChild(document.createTextNode(gio_hang.TenMon));        
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.SoLuong));
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.Gia));
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.TongGiaMonAn));
        tr3.appendChild(td3);
    }
    
    Th.innerHTML = "";
    Th.appendChild(table3);
    
    // Load gia trị đơn hàng
    var nodediv = document.getElementById("div_TGT2");
    var nodeGiaTri = document.createElement("label");
    nodeGiaTri.id = "txtGiaTri";
    nodeGiaTri.innerHTML = TongGiaTriHoaDon;
    nodediv.appendChild(nodeGiaTri);
    
    // Tính và load tiền thuế
    var tienthue;
    Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Tinh_Tien_Thue")); 
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {   
        // Khởi tạo tiền thuế     
        tienthue = Goc.getAttribute("Kq");
        nodediv = document.getElementById("div_Thue");
        var nodeThue = document.createElement("label");
        nodeThue.id = "txtThue";
        nodeThue.innerHTML = tienthue;
        nodediv.appendChild(nodeThue);
    }
    else
        return;
    
    // khoi tao gia tri khuyen mai
    if(nodeLoaiND.value == "KhachHang")
    {
        var node = document.getElementById("div_KM");
        var nodeKM = document.createElement("label");
    
        nodeKM.id = "txtKM";
        nodeKM.innerHTML = 0;
        node.appendChild(nodeKM);
    }
    
    // khoi tao tổng tiền phải trả
    node = document.getElementById("div_TT");
    var nodeTT = document.createElement("label");
    
    nodeTT.id = "txtTT";
    nodeTT.innerHTML = TongGiaTriHoaDon + parseFloat(tienthue);
    node.appendChild(nodeTT);
}

var TongGiaTriKhuyenMai = 0;
function XL_DonHang.DsQuaTang()
{

    var Th = document.getElementById("Th_Danh_Sach_Qua_Tang");
   
   //lay thong tin gio hang
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Them_vao_gio_qua_tang");
    Ham.Danh_sach_tham_so.push(Tham_so); 
    var Goc = Ham.Thuc_hien();
    var arr = new Array();
    if(Goc != null)
    {        
        arr = XL_GIO_HANG.Khoi_tao_gio_hang(Goc)
    }
    else
    {
        // khoi tao tong gia tri khuyến mãi
        var node = document.getElementById("div_GTQT");
        var nodeTT = document.createElement("label");
                
        nodeTT.id = "txtGiaTriQT";
        nodeTT.innerHTML = 0;
        node.appendChild(nodeTT);  
        
        return;
    }
    
    var table3 = document.createElement("table");
    table3.align = "center";
    table3.width = "100%";
    table3.border = "1";        
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    var td3 = document.createElement("td");
    td3.width = "15%";
    td3.appendChild(document.createTextNode("Ma Item"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "35%";
    td3.appendChild(document.createTextNode("Ten Item"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "10%";
    td3.appendChild(document.createTextNode("So Luong"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "20%";
    td3.appendChild(document.createTextNode("Don Gia(VND)"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "20%";
    td3.appendChild(document.createTextNode("Tri Gia(VND)"));
    tr3.appendChild(td3);
    
    for(var i = 0; i < arr.length; i++)
    {
        var gio_hang = arr[i];
        TongGiaTriKhuyenMai += parseInt(gio_hang.TongGiaMonAn);
        tr3 = document.createElement("tr");
        tbody3.appendChild(tr3);
        td3 = document.createElement("td");
        td3.width = "15%";        
        td3.appendChild(document.createTextNode(gio_hang.MaMon));        
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "35%";        
        td3.appendChild(document.createTextNode(gio_hang.TenMon));        
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.SoLuong));
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.Gia));
        tr3.appendChild(td3);
        
        td3 = document.createElement("td");
        td3.width = "10%";
        td3.appendChild(document.createTextNode(gio_hang.TongGiaMonAn));
        tr3.appendChild(td3);
    }
    
    Th.innerHTML = "";
    Th.appendChild(table3);
    
    // khoi tao tong gia tri khuyen mai
    var nodediv = document.getElementById("div_GTQT");
    var nodeGiaTri = document.createElement("label");
    nodeGiaTri.id = "txtGiaTriQT";
    nodeGiaTri.innerHTML = TongGiaTriKhuyenMai;
    nodediv.appendChild(nodeGiaTri);
    
    //khoi tao gia tri khuyen mai
    var node = document.getElementById("div_KM");
    var nodeKM = document.createElement("label");
    
    node.removeChild(node.firstChild);
    nodeKM.id = "txtKM";
    var nodeGTQT = document.getElementById("txtGiaTriQT");
    nodeKM.innerHTML = nodeGTQT.innerHTML;
    node.appendChild(nodeKM);
    
    // khoi tao tong tiền phải trả
    node = document.getElementById("div_TT");
    var nodeTT = document.createElement("label");
    var tienhang = document.getElementById("txtGiaTri").innerHTML;
    var tienthue = document.getElementById("txtThue").innerHTML;
    
    node.removeChild(node.firstChild);
    nodeTT.id = "txtTT";
    nodeTT.innerHTML = parseFloat(tienhang) + parseFloat(tienthue);
    node.appendChild(nodeTT);    
}

function btnQuayLai_onclick() 
{
    //giữ lại trạng thái trên form
   
    window.location = "AddToCard.aspx"
}  

function XL_DonHang.Thoat()
{
    window.location = "DanhSachMonAn.aspx"
}

function ClickChonQuaTang()
{  
    var index = document.getElementById("cmbDiemSD").selectedIndex;
    var cmbDiemSD = document.getElementById("cmbDiemSD")[index].innerHTML;
    var lbSoTien = document.getElementById("lbSoTien").innerHTML;
    var cmbHTKM = document.getElementById("cmbHTKM").selectedIndex;
    var cmbHTTT = document.getElementById("cmbHTTT").selectedIndex;
    var rdMacDinh = document.getElementById("rdMacDinh").checked;
    var txtNguoiNhan = nodeNguoiNhan.value;
    var txtDiaChiNhan = nodeDiaChiNhan.value;
    var cmbNgayGH = document.getElementById("cmbNgayGH").selectedIndex;
    var cmbThangGH = document.getElementById("cmbThangGH").selectedIndex;
    var cmbNamGH = document.getElementById("cmbNamGH").selectedIndex;
    var cmbGioGH = document.getElementById("cmbGioGH").selectedIndex;
    var cmbPhutGH = document.getElementById("cmbPhutGH").selectedIndex;
    var cmbBuoiGH = document.getElementById("cmbBuoiGH").selectedIndex;
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Luu_trang_thai_form")); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbDiemSD",cmbDiemSD)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("lbSoTien",lbSoTien)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbHTKM",cmbHTKM)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbHTTT",cmbHTTT)); 
    if(rdMacDinh == true)
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("rdThe","rdMacDinh"));
    else
    {
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("rdThe","rdKhac"));
        
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeLoaiThe",nodeLoaiThe.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeSoThe",nodeSoThe.value)); 
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeNgayHH",nodeNgayHH.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeThangHH",nodeThangHH.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeNamHH",nodeNamHH.selectedIndex));
    }
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("txtNguoiNhan",txtNguoiNhan)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("txtDiaChiNhan",txtDiaChiNhan)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNgayGH",cmbNgayGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbThangGH",cmbThangGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNamGH",cmbNamGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbGioGH",cmbGioGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbPhutGH",cmbPhutGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbBuoiGH",cmbBuoiGH)); 
    
    var Goc = Ham.Thuc_hien();
    
    var lbSoTien = document.getElementById("lbSoTien").innerHTML;
    var btChon = document.getElementById("btChon");
    
    if (btChon.value != "Cập nhật")
        window.location = "DanhSachQuaTang.aspx?lbSoTien=" + lbSoTien + "&page=1&limit=" + lbSoTien + "&loaidh=0";
    else                                                                            
        window.location = "AddToGifts.aspx?lbSoTien=" + lbSoTien + "&loaidh=0"; // 0 là loại bình thường
}


function XL_DonHang.LayTrangThaiForm()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Lay_trang_thai_form")); 
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {      
        var cmbDiemSD = Goc.getAttribute("cmbDiemSD");
        document.getElementById("cmbDiemSD").selectedIndex = parseInt(cmbDiemSD);
        document.getElementById("cmbDiemSD").disabled = false;
        
        document.getElementById("rdCo").checked = true;
        
        var lbSoTien = Goc.getAttribute("lbSoTien");
        document.getElementById("lbSoTien").innerHTML = lbSoTien;
        
        var cmbHTKM = Goc.getAttribute("cmbHTKM");
        document.getElementById("cmbHTKM").selectedIndex = parseInt(cmbHTKM);
        document.getElementById("cmbHTKM").disabled = false;
        
        var tienkhuyenmai = document.getElementById("txtGiaTriQT").innerHTML
        var tiensudung = document.getElementById("lbSoTien").innerHTML;
        if(tienkhuyenmai != "0")
        {
            document.getElementById("btChon").value = "Cập nhật";
            var tiendu = parseFloat(tiensudung) - parseFloat(tienkhuyenmai);
            
            var Kq = null;
            var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Tinh_so_diem_hoan_lai")); 
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("tiendu",tiendu)); 
            
            var goc = Ham.Thuc_hien();
            
            if(goc != null)
            {
                var diemhoanlai = goc.getAttribute("Kq");
                
                var cmbDiemSD = document.getElementById("cmbDiemSD");
               
                var diemsudungmoi = cmbDiemSD.selectedIndex - parseInt(diemhoanlai);
                cmbDiemSD.selectedIndex = diemsudungmoi; //gia tri diem = index
                TinhTien(); //tinh lai so tien tuong ung
                alert("Giá trị quà tặng là " + tienkhuyenmai + " VND, bạn nên sử dụng " + diemsudungmoi + " điểm khuyến mãi.");
                //disable cac diem su dung co gia tri nho hon
                for(var i=1; i<diemsudungmoi; i++)
                {
                    var id = "DiemSDoption" + i;
                    var nodeOpt = document.getElementById(id);
                    cmbDiemSD.removeChild(nodeOpt);
                }
            }
        }
        
        document.getElementById("btChon").disabled = false;
        
        var cmbHTTT = Goc.getAttribute("cmbHTTT");
        document.getElementById("cmbHTTT").selectedIndex = parseInt(cmbHTTT);
        
        var rdThe = Goc.getAttribute("rdThe");
        if(rdThe == "rdMacDinh")
            document.getElementById("rdMacDinh").checked = true;
        else
        {
            document.getElementById("rdKhac").checked = true;
            document.getElementById("rdKhac").disabled = false;
            document.getElementById("rdMacDinh").checked = false;
            document.getElementById("rdMacDinh").disabled = false;
            
            nodeLoaiThe.selectedIndex = parseInt(Goc.getAttribute("nodeLoaiThe"));
            nodeLoaiThe.disabled = false;
            
            nodeSoThe.value = Goc.getAttribute("nodeSoThe");
            nodeSoThe.disabled = false;
            
            nodeNgayHH.selectedIndex = parseInt(Goc.getAttribute("nodeNgayHH"));
            nodeNgayHH.disabled = false;
            
            nodeThangHH.selectedIndex = parseInt(Goc.getAttribute("nodeThangHH"));
            nodeThangHH.disabled = false;
            
            nodeNamHH.selectedIndex = parseInt(Goc.getAttribute("nodeNamHH"));
            nodeNamHH.disabled = false;
        }
        var txtNguoiNhan = Goc.getAttribute("txtNguoiNhan");
        nodeNguoiNhan.value = txtNguoiNhan;  
         
        var txtDiaChiNhan = Goc.getAttribute("txtDiaChiNhan");
        nodeDiaChiNhan.value = txtDiaChiNhan;  
        
        var cmbNgayGH = Goc.getAttribute("cmbNgayGH");
        document.getElementById("cmbNgayGH").selectedIndex = parseInt(cmbNgayGH);
        
        var cmbThangGH = Goc.getAttribute("cmbThangGH");
        document.getElementById("cmbThangGH").selectedIndex = parseInt(cmbThangGH);
        
        var cmbNamGH = Goc.getAttribute("cmbNamGH");
        document.getElementById("cmbNamGH").selectedIndex = parseInt(cmbNamGH);
        
        var cmbGioGH = Goc.getAttribute("cmbGioGH");
        document.getElementById("cmbGioGH").selectedIndex = parseInt(cmbGioGH);
        
        var cmbPhutGH = Goc.getAttribute("cmbPhutGH");
        document.getElementById("cmbPhutGH").selectedIndex = parseInt(cmbPhutGH);
        
        var cmbBuoiGH = Goc.getAttribute("cmbBuoiGH");
        document.getElementById("cmbBuoiGH").selectedIndex = parseInt(cmbBuoiGH);
    }

}

function ClickChonQuaTangDinhKy()
{  
    var index = document.getElementById("cmbDiemSD").selectedIndex;
    var cmbDiemSD = document.getElementById("cmbDiemSD")[index].innerHTML;
    var lbSoTien = document.getElementById("lbSoTien").innerHTML;
    var cmbHTKM = document.getElementById("cmbHTKM").selectedIndex;
    var cmbHTTT = document.getElementById("cmbHTTT").selectedIndex;
    var rdMacDinh = document.getElementById("rdMacDinh").checked;
    var txtNguoiNhan = nodeNguoiNhan.value;
    var txtDiaChiNhan = nodeDiaChiNhan.value;
    
    var cmbLoaiDK = document.getElementById("cmbLoaiDK").selectedIndex;
    var cmbNgayBD = document.getElementById("cmbNgayBD").selectedIndex;
    var cmbThangBD = document.getElementById("cmbThangBD").selectedIndex;
    var cmbNamBD = document.getElementById("cmbNamBD").selectedIndex;
    var cmbNgayKT = document.getElementById("cmbNgayKT").selectedIndex;
    var cmbThangKT = document.getElementById("cmbThangKT").selectedIndex;
    var cmbNamKT = document.getElementById("cmbNamKT").selectedIndex;
    var cmbGioGH = document.getElementById("cmbGioGH").selectedIndex;
    var cmbPhutGH = document.getElementById("cmbPhutGH").selectedIndex;
    var cmbBuoiGH = document.getElementById("cmbBuoiGH").selectedIndex;
    
      
    
    var listDS = document.getElementById("listDS");
    var listDSChon = document.getElementById("listDSChon");
    var chuoiDS = "";
    var chuoiDSChon = "";
    
    while(listDS.hasChildNodes())
    {
        var node = listDS.firstChild;
        chuoiDS += node.innerHTML + ",";
        listDS.removeChild(node);
    }  
    while(listDSChon.hasChildNodes())
    {
        var node = listDSChon.firstChild;
        chuoiDSChon += node.innerHTML + ",";
        listDSChon.removeChild(node);
    }
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Luu_trang_thai_form_dinh_ky")); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbDiemSD",cmbDiemSD)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("lbSoTien",lbSoTien)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbHTKM",cmbHTKM)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbHTTT",cmbHTTT)); 
    if(rdMacDinh == true)
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("rdThe","rdMacDinh"));
    else
    {
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("rdThe","rdKhac"));
        
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeLoaiThe",nodeLoaiThe.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeSoThe",nodeSoThe.value)); 
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeNgayHH",nodeNgayHH.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeThangHH",nodeThangHH.selectedIndex));
        Ham.Danh_sach_tham_so.push(new XL_THAM_SO("nodeNamHH",nodeNamHH.selectedIndex));
    }
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("txtNguoiNhan",txtNguoiNhan)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("txtDiaChiNhan",txtDiaChiNhan)); 
    
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbLoaiDK",cmbLoaiDK)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNgayBD",cmbNgayBD)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbThangBD",cmbThangBD)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNamBD",cmbNamBD)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNgayKT",cmbNgayKT)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbThangKT",cmbThangKT)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbNamKT",cmbNamKT)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbGioGH",cmbGioGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbPhutGH",cmbPhutGH)); 
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("cmbBuoiGH",cmbBuoiGH)); 
    
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("chuoiDS",chuoiDS));
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("chuoiDSChon",chuoiDSChon));
    
    var Goc = Ham.Thuc_hien();
    
    var lbSoTien = document.getElementById("lbSoTien").innerHTML;
    var btChon = document.getElementById("btChon");
    
    if (btChon.value != "Cập nhật")
        window.location = "DanhSachQuaTang.aspx?lbSoTien=" + lbSoTien + "&page=2&limit=" + lbSoTien + "&loaidh=1";//page2:quaylai_click
    else                                                                            
        window.location = "AddToGifts.aspx?lbSoTien=" + lbSoTien + "&loaidh=1"; // 1 là loại đinh kỳ
}

function XL_DonHang.LayTrangThaiFormDinhKy()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
    Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Lay_trang_thai_form_dinh_ky")); 
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {      
        var cmbDiemSD = Goc.getAttribute("cmbDiemSD");
        document.getElementById("cmbDiemSD").selectedIndex = parseInt(cmbDiemSD);
        document.getElementById("cmbDiemSD").disabled = false;
        
        document.getElementById("rdCo").checked = true;
        
        var lbSoTien = Goc.getAttribute("lbSoTien");
        document.getElementById("lbSoTien").innerHTML = lbSoTien;
        
        var cmbHTKM = Goc.getAttribute("cmbHTKM");
        document.getElementById("cmbHTKM").selectedIndex = parseInt(cmbHTKM);
        document.getElementById("cmbHTKM").disabled = false;
        
        var tienkhuyenmai = document.getElementById("txtGiaTriQT").innerHTML
        var tiensudung = document.getElementById("lbSoTien").innerHTML;
        if(tienkhuyenmai != "0")
        {
            document.getElementById("btChon").value = "Cập nhật";
            var tiendu = parseFloat(tiensudung) - parseFloat(tienkhuyenmai);
            
            var Kq = null;
            var Ham = new XL_HAM("He Phuc Vu/XL_DON_HANG");
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("Xac_nhan","Tinh_so_diem_hoan_lai")); 
            Ham.Danh_sach_tham_so.push(new XL_THAM_SO("tiendu",tiendu)); 
            
            var goc = Ham.Thuc_hien();
            
            if(goc != null)
            {
                var diemhoanlai = goc.getAttribute("Kq");
                
                var cmbDiemSD = document.getElementById("cmbDiemSD");
               
                var diemsudungmoi = cmbDiemSD.selectedIndex - parseInt(diemhoanlai);
                cmbDiemSD.selectedIndex = diemsudungmoi; //gia tri diem = index
                TinhTien(); //tinh lai so tien tuong ung
                alert("Giá trị quà tặng là " + tienkhuyenmai + " VND, bạn nên sử dụng " + diemsudungmoi + " điểm khuyến mãi.");
                //disable cac diem su dung co gia tri nho hon
                for(var i=1; i<diemsudungmoi; i++)
                {
                    var id = "DiemSDoption" + i;
                    var nodeOpt = document.getElementById(id);
                    cmbDiemSD.removeChild(nodeOpt);
                }
            }
        }
        
        document.getElementById("btChon").disabled = false;
        
        var cmbHTTT = Goc.getAttribute("cmbHTTT");
        document.getElementById("cmbHTTT").selectedIndex = parseInt(cmbHTTT);
        
        var rdThe = Goc.getAttribute("rdThe");
        if(rdThe == "rdMacDinh")
            document.getElementById("rdMacDinh").checked = true;
        else
        {
            document.getElementById("rdKhac").checked = true;
            document.getElementById("rdKhac").disabled = false;
            document.getElementById("rdMacDinh").checked = false;
            document.getElementById("rdMacDinh").disabled = false;
            
            nodeLoaiThe.selectedIndex = parseInt(Goc.getAttribute("nodeLoaiThe"));
            nodeLoaiThe.disabled = false;
            
            nodeSoThe.value = Goc.getAttribute("nodeSoThe");
            nodeSoThe.disabled = false;
            
            nodeNgayHH.selectedIndex = parseInt(Goc.getAttribute("nodeNgayHH"));
            nodeNgayHH.disabled = false;
            
            nodeThangHH.selectedIndex = parseInt(Goc.getAttribute("nodeThangHH"));
            nodeThangHH.disabled = false;
            
            nodeNamHH.selectedIndex = parseInt(Goc.getAttribute("nodeNamHH"));
            nodeNamHH.disabled = false;
        }
        var txtNguoiNhan = Goc.getAttribute("txtNguoiNhan");
        nodeNguoiNhan.value = txtNguoiNhan;  
         
        var txtDiaChiNhan = Goc.getAttribute("txtDiaChiNhan");
        nodeDiaChiNhan.value = txtDiaChiNhan;  
        
        var cmbLoaiDK = Goc.getAttribute("cmbLoaiDK");
        document.getElementById("cmbLoaiDK").selectedIndex = parseInt(cmbLoaiDK);
        
        var cmbNgayBD = Goc.getAttribute("cmbNgayBD");
        document.getElementById("cmbNgayBD").selectedIndex = parseInt(cmbNgayBD);
        var cmbThangBD = Goc.getAttribute("cmbThangBD");
        document.getElementById("cmbThangBD").selectedIndex = parseInt(cmbThangBD);
        var cmbNamBD = Goc.getAttribute("cmbNamBD");
        document.getElementById("cmbNamBD").selectedIndex = parseInt(cmbNamBD);
        
        var cmbNgayKT = Goc.getAttribute("cmbNgayKT");
        document.getElementById("cmbNgayKT").selectedIndex = parseInt(cmbNgayKT);
        var cmbThangKT = Goc.getAttribute("cmbThangKT");
        document.getElementById("cmbThangKT").selectedIndex = parseInt(cmbThangKT);
        var cmbNamKT = Goc.getAttribute("cmbNamKT");
        document.getElementById("cmbNamKT").selectedIndex = parseInt(cmbNamKT);
        
        var cmbGioGH = Goc.getAttribute("cmbGioGH");
        document.getElementById("cmbGioGH").selectedIndex = parseInt(cmbGioGH);
        var cmbPhutGH = Goc.getAttribute("cmbPhutGH");
        document.getElementById("cmbPhutGH").selectedIndex = parseInt(cmbPhutGH);
        var cmbBuoiGH = Goc.getAttribute("cmbBuoiGH");
        document.getElementById("cmbBuoiGH").selectedIndex = parseInt(cmbBuoiGH);
        
        var chuoiDS = Goc.getAttribute("chuoiDS");
        var chuoiDSChon = Goc.getAttribute("chuoiDSChon");
        XL_DonHang.LayTrangThaiDanhSach(chuoiDS, chuoiDSChon);
    }
}

function XL_DonHang.LayTrangThaiDanhSach(chuoiDS, chuoiDSChon)
{
    var index = document.getElementById("cmbLoaiDK").value;
    var loai = document.getElementById("cmbLoaiDK")[index].innerHTML;
    var td1 = document.getElementById("tdDS");
    var td2 = document.getElementById("tdDSChon");
    
    if(td1.hasChildNodes())
        td1.removeChild(td1.firstChild);
    if(td2.hasChildNodes())
        td2.removeChild(td2.firstChild);
    var lb1 = document.createElement("label");
    var lb2 = document.createElement("label");
    
    var listDS = document.getElementById("listDS");
    var listDSChon = document.getElementById("listDSChon");
    while(listDS.hasChildNodes())
        listDS.removeChild(listDS.firstChild);
    while(listDSChon.hasChildNodes())
        listDSChon.removeChild(listDSChon.firstChild);
        
    if(loai == "Hang Tuan")
    {
        lb1.innerHTML = "Thứ giao hàng trong tuần";
        lb2.innerHTML = "Thứ giao hàng đã chọn";
    }
    else if(loai == "Hang Thang")
    {
        lb1.innerHTML = "Ngày giao hàng trong tháng";
        lb2.innerHTML = "Ngày giao hàng đã chọn";
    }
    
    LayDS(chuoiDS);
    LayDSChon(chuoiDSChon);
        
    td1.appendChild(lb1);
    td2.appendChild(lb2);
}

function KiemTraSoThe()
{
    var sothe = SHA1(nodeSoThe.value); // mã hóa số thẻ
    
    if (sothe.toUpperCase() == hiddenSoThe.value.toUpperCase())
    {
       alert("Thẻ vừa nhập là thẻ mặc định");
       ChonMacDinh();
    }
}