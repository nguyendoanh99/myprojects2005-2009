// JScript File
var arrDiChuyen = new Array(); // Mang dung de thuc hien viec di chuyen quan ngua
var _timeDiChuyen = null;
var _timeCapNhat = null;
var _timeXiNgau = null;
var ThongTinNguoiChoi;
var LuotDi = -1;
var SoLan = 0; // Dung cho ham do xi ngau
var XiNgau = -1;
// Kiểm tra quân cờ có đi tiếp được hay không
function KiemTraDiDuoc(ConCo, BuocNhay)
{
    var vt = parseInt(ViTriQuanCo[ConCo]);
    var ConCoBatDau = Math.round(ConCo / 4);
    if (vt == -1)
        return false;
    
    var i;
    for (i = 01; i < BuocNhay; ++i)
        if (arrOCo[vt + i] != -1)
            return false;
            
    if (arrOCo[vt + BuocNhay] >= ConCoBatDau && arrOCo[vt + BuocNhay] <= ConCoBatDau + 3)
        return false;
        
    return true;
    
}
function DoXiNgau()
{
    if (SoLan > 30)
    {
        if (ThongTinNguoiChoi != null && LuotDi == ThongTinNguoiChoi.NguoiChoiThu)
        {
            clearTimeout(_timeXiNgau);
            _timeXiNgau = null;
            SoLan = 0;
            
            var Ham = new XL_HAM("DoXiNgau");
            var Goc = Ham.Thuc_hien();
            
            if (Goc != null)
            {
                XiNgau = parseInt(Goc.getAttribute("XiNgau"));
                var node = document.getElementById("XiNgau");
                node.innerHTML = XiNgau;
                var butRaquan = document.getElementById("butRaQuan");
                var butDiChuyen = document.getElementById("butDiChuyen");                
                var coBatDau = ThongTinNguoiChoi.NguoiChoiThu * 4;
                if (XiNgau == 6 || XiNgau == 1)
                {
                    var i;                    
                    var flag = false;
                    for (i = 0; i < 4; ++i)
                        if (ViTriQuanCo[coBatDau + i] == -1)
                        {
                            flag = true;
                            break;
                        }
                    // Ô ra quân bị chặn bởi quân mình
                    var ORaQuan = arrOCo[arrViTriBatDau[ThongTinNguoiChoi.NguoiChoiThu]];
                    if (ORaQuan >= coBatDau && ORaQuan <= coBatDau + 3)
                        flag = false;
                        
                    if (flag == true)                            
                        butRaquan.disabled = "";
                    else
                        butRaquan.disabled = "disabled";
                }
                else 
                {
                    butRaquan.disabled = "disabled";
                    var dem = 0;
                    for (i = 0; i < 4; ++i)
                        if (ViTriQuanCo[coBatDau + i] == -1)
                        {
                            dem++;
                        }
                    // Không có quân nào trên bàn cờ    
                    if (dem == 4)
                    {
                        alert("Không có quân nào trên bàn cờ");
                        Ham = new XL_HAM("ChuyenLuotDi");
                        Ham.Thuc_hien();
                        butDiChuyen.disabled = "disabled";
                        butRaquan.disabled = "disabled";
                        return;
                    }
                }    
                
                var flag = false;
                var dem = 0;
                for (var i = 0; i < 4; ++i)
                {
                    if (ViTriQuanCo[coBatDau + i] != -1)
                        dem++;
                        
                    if (KiemTraDiDuoc(coBatDau + i, XiNgau) == true)
                    {
                        flag = true;
                        break;
                    }
                }   
                if (flag == false)
                {                     
                    butDiChuyen.disabled = "disabled";
                    // Khong co quan co nao het
                    if (dem == 0)
                        return;
                    alert("Không thể đi bất kỳ quân cờ nào");
                    Ham = new XL_HAM("ChuyenLuotDi");
                    Ham.Thuc_hien();
                }
         //       else                
                    //butDiChuyen.disabled = "";
            }
            return;
        }
        else
            SoLan = 0;
    }    
    var butDoXiNgau = document.getElementById("butDoXiNgau");
    butDoXiNgau.disabled = "disabled";
    var node = document.getElementById("XiNgau");
    var so = parseInt(Math.random() * 6 + 1);
    node.innerHTML = so;
    SoLan++;
    _timeXiNgau = setTimeout("DoXiNgau()", 50);
}
function DangNhap()
{
    var Ham = new XL_HAM("DangNhap");
    var Goc = Ham.Thuc_hien();
    
    if (Goc != null)
    {
        var M = Goc.getElementsByTagName("NguoiChoiThu");
        var NguoiChoiThu = parseInt(M[0].getAttribute("GiaTri"));
        
        ThongTinNguoiChoi = new NGUOICHOI(NguoiChoiThu);
    }
}
function DiChuyen(ConCo, BuocDi)
{
    if (ThongTinNguoiChoi.NguoiChoiThu != LuotDi)
        return "Không phải lượt của mình";
       
    if (Math.round(ConCo / 4) != ThongTinNguoiChoi.NguoiChoiThu)
        return "Không phải cờ của mình.";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

    var ViTriCu = parseInt(ViTriQuanCo[ConCo]);
    var ViTriMoi =  (ViTriCu + BuocDi) % 56;
    var ViTriBatDau = arrViTriBatDau[Math.round(ConCo / 4)];
    var ViTriKetThuc = ViTriBatDau - 1;
    var ViTriDich = arrViTriDich[Math.round(ConCo / 4)];
    var kq = "";
    
    if (ViTriKetThuc < 0)
        ViTriKetThuc = 55;
        
    if (ViTriCu == ViTriKetThuc)
    {
        ViTriCu = ViTriDich;
        ViTriMoi = ViTriCu + BuocDi - 1;
        for (var i = ViTriCu; i <= ViTriMoi; ++i)
        {
            if (arrOCo[i] != -1)
            {
                kq = "Không thể đi được vì có quân cờ cản đường";
                return kq;
            }   
        }
    }
    else
        if (ViTriCu >= ViTriDich)
        {
            if (ViTriCu == ViTriDich + 5)
            {
                kq = "Đã đến đích, không thể đi được nữa";
                return kq;
            }
            
            var temp = BuocDi - (ViTriCu - ViTriDich + 1);            
            if (temp == 1)
            {
                ViTriMoi = ViTriCu + 1;
                if (arrOCo[ViTriMoi] != -1)
                {
                    kq = "Không thể đi được vì có quân cờ cản đường";
                    return kq;
                }
            }
            else
            {
                kq = "Không thể đi quá một ô được";
                return kq;
            }
        }
        else
        {
            for (var i = ViTriCu + 1; i != ViTriMoi; i = (i + 1) % 56)
            {
                if (arrOCo[i] != -1)
                {
                    kq = "Không thể đi được vì có quân cờ cản đường";
                    return kq;
                }   
                else
                {
                    if (i == ViTriKetThuc)
                    {
                        kq = "Không thể đi qua đích được.";
                        return kq;
                    }
                }
            }
            
            if (arrOCo[ViTriMoi] != -1)
            {
                var temp = ThongTinNguoiChoi.NguoiChoiThu * 4;
                if (temp <= arrOCo[ViTriMoi] && arrOCo[ViTriMoi] <= temp + 3)
                {
                    kq = "Không thể đi được vì không thể ăn quân cờ của chính mình";
                    return kq;
                }
                else
                {
                    kq = "Bạn đã ăn được quân cờ của đối thủ.";
                    
                    var ThamSo = new XL_THAM_SO("ConCo", arrOCo[ViTriMoi]);
                    var Ham = new XL_HAM("LuuNuocDi");
                    Ham.Danh_sach_tham_so.push(ThamSo);
                    ThamSo = new XL_THAM_SO("ViTri", -1);
                    Ham.Danh_sach_tham_so.push(ThamSo);
                    Ham.Thuc_hien();
                    
                    ViTriQuanCo[ViTriMoi] = -1;
                    arrOCo[ViTriMoi] = -1;
                }
            }
        }
        
    var ThamSo = new XL_THAM_SO("ConCo", ConCo);
    var Ham = new XL_HAM("LuuNuocDi");
    Ham.Danh_sach_tham_so.push(ThamSo);
    ThamSo = new XL_THAM_SO("ViTri", ViTriMoi);
    Ham.Danh_sach_tham_so.push(ThamSo);
    Ham.Thuc_hien();
    // Chuyen luot
    Ham = new XL_HAM("ChuyenLuotDi");
    Ham.Thuc_hien();
    return kq;
}
function TaoDuongDi()
{
    var flag = 0; // Khong co su thay doi
    
    for (var i = 0; i < arrDiChuyen.length; ++i)
    {
        var t = arrDiChuyen[i];
        var ViTriCu = t[0];
        var ConCo = t[1];
        var ViTriMoi = ViTriQuanCo[ConCo];
        var ViTriBatDau = arrViTriBatDau[Math.round(ConCo / 4)];
        var ViTriKetThuc = ViTriBatDau - 1;
        var ViTriDich = arrViTriDich[Math.round(ConCo / 4)];
        var node;
        
        if (ViTriKetThuc < 0)
            ViTriKetThuc = 55;
        
        if (ViTriMoi != -1 && ViTriCu != ViTriMoi)
        {
            // Xoa nuoc di cu
            if (ViTriCu != -1)
            {
                node = document.getElementById("vt" + ViTriCu);
                node.innerHTML = "&nbsp;";
                
                if (ViTriCu == ViTriKetThuc)
                {
                    ViTriCu = ViTriDich;
                }
                else
                    if (ViTriMoi <= 55)
                        ViTriCu = (ViTriCu + 1) % 56;
                    else
                        ViTriCu = (ViTriCu + 1);
            }
            else
            {
                switch (Math.round(ConCo / 4))
                {
                case 0:
                    ViTriCu = 0;
                    break; 
                case 1:
                    ViTriCu = 14;
                    break;
                case 2:
                    ViTriCu = 28;
                    break;
                case 3:
                    ViTriCu = 42;
                    break;
                }
            }
                
            node = document.getElementById("vt" + ViTriCu);
            node.innerHTML = ConCo;   
            t[0] = ViTriCu;
            flag = 1;
        }
    }
    
    if (flag == 1)
    {
        _timeDiChuyen = setTimeout("TaoDuongDi()", 200);        
    }
    else
    {
        while (arrDiChuyen.length != 0)
        {
            arrDiChuyen.pop();
        }
        clearTimeout(_timeDiChuyen);
        _timeDiChuyen = null;
        _timeCapNhat = setTimeout("CapNhatBanCo()", 100);
    }
}
function CapNhatBanCo()
{
    var Ham = new XL_HAM("LayNoiDung");
    var Goc = Ham.Thuc_hien();
    
    if (Goc != null)
    {
        var M = Goc.childNodes;
        
        for (var i = 0; i < M.length; ++i)
        {        
            var NoiDung = M[i].getAttribute("NoiDung");
            var NguoiGui = M[i].getAttribute("NguoiGui");
            arrStr += "\n" + NguoiGui + ": " + NoiDung;  
            TextAreaChat.value = arrStr;  
        }        
    }
    else
        alert("Lỗi khi kết nối");
        
    Ham = new XL_HAM("LayTrangThaiBanCo");
    Goc = Ham.Thuc_hien();
    var DangDoXiNgau;
    var SoNguoiChoi;
    var SoNguoiXem;
    if (Goc != null)
    {
        var M = Goc.getElementsByTagName("Co");
        LuotDi = Goc.getElementsByTagName("LuotDi")[0].getAttribute("GiaTri"); // Luot Di
        XiNgau = Goc.getElementsByTagName("XiNgau")[0].getAttribute("GiaTri"); // Xi ngau
        DangDoXiNgau = Goc.getElementsByTagName("DangDoXiNgau")[0].getAttribute("GiaTri"); 
        SoNguoiChoi = Goc.getElementsByTagName("SoNguoiChoi")[0].getAttribute("GiaTri"); 
        SoNguoiXem = Goc.getElementsByTagName("SoNguoiXem")[0].getAttribute("GiaTri"); 
        var butDoXiNgau = document.getElementById("butDoXiNgau");
        
        if (ThongTinNguoiChoi != null && SoNguoiChoi > 1 && LuotDi == -1 && ThongTinNguoiChoi.NguoiChoiThu == 0)        
        {
            Ham = new XL_HAM("ChuyenLuotDi");
            Ham.Thuc_hien();
        }
        
        if (DangDoXiNgau == 1)
        {
            if (_timeXiNgau == null)
            {
                SoLan = 0;
                _timeXiNgau = setTimeout("DoXiNgau()", 50);
            }
        }
        else
        {            
            if (LuotDi == ThongTinNguoiChoi.NguoiChoiThu)
                butDoXiNgau.disabled = "";
            else
                butDoXiNgau.disabled = "disabled";
                
            clearTimeout(_timeXiNgau);
            _timeXiNgau = null;
        }
        
        if (XiNgau != -1)
        {
            butDoXiNgau.disabled = "disabled";     
            var node = document.getElementById("XiNgau");
            node.innerHTML = XiNgau;
            clearTimeout(_timeXiNgau);
            _timeXiNgau = null;
        }
        
        for (var i = 0; i < M.length; ++i)
        {       
            var ViTriCo = M[i].getAttribute("ViTri");
            
            if (ViTriCo != ViTriQuanCo[i])
            {
                arrOCo[ViTriQuanCo[i]] = -1;
                var arrTemp = new Array();
                arrTemp.push(parseInt(ViTriQuanCo[i])); // Vi tri cu
                arrTemp.push(i); // con co
                arrDiChuyen.push(arrTemp);
                ViTriQuanCo[i] = ViTriCo;
                arrOCo[ViTriCo] = i;
            } 
        }
        clearTimeout(_timeCapNhat);
        _timeCapNhat = null;
        _timeDiChuyen = setTimeout("TaoDuongDi()", 700);        
    }
    else
        alert("Lỗi khi kết nối");
    
    if (_timeDiChuyen == null)    
    {
        _timeCapNhat = setTimeout("CapNhatBanCo()", 2000);
    }
}