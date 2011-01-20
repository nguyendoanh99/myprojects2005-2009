// JScript File
function Quang_Cao()
{
    this.TenCongTy = "";
    this.DiaChi = "";
    this.Website = "";
    this.Logo = "";
    this.WebsiteXuatHien = new Array();
    this.TrangThai = "";
}

function XL_QUANG_CAO()
{
}

function XL_QUANG_CAO.radLogo1_change()
{
    if(document.getElementById("radLogo1").checked == false)
    {
        document.getElementById("radLogo1").checked = true;
        document.getElementById("txtLogo").value = "";
        document.getElementById("txtLogo").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").disabled = false;
        document.getElementById("radLogo2").checked = false;
    }
}

function XL_QUANG_CAO.ChonWebsite(idselect1, idselect2)
{
    //Lay ra ten website
    var idListWebsite = document.getElementById(idselect1);
    if(idListWebsite.selectedIndex >= 0)
    {
        var Ten_website = idListWebsite.options[idListWebsite.selectedIndex].innerHTML;
        
        var idListWebsite_da_chon = document.getElementById(idselect2);
        var tagOption = document.createElement("option");
        tagOption.innerHTML = Ten_website;
        //Add node do vao
        idListWebsite_da_chon.appendChild(tagOption);
        //Remove node do di// ham remove di tai vi tri Index
        idListWebsite.remove(idListWebsite.selectedIndex);
    }
}

function XL_QUANG_CAO.ChonHetWebsite(idselect1, idselect2)
{
    var idListWebsite = document.getElementById(idselect1);
    for(var i = idListWebsite.length - 1; i >=0 ; i --)
    {
        var Ten_website = idListWebsite.options[i].innerHTML;
        
        var idListWebsite_da_chon = document.getElementById(idselect2);
        var tagOption = document.createElement("option");
        tagOption.innerHTML = Ten_website;
        //Add node do vao
        idListWebsite_da_chon.appendChild(tagOption);
       //Remove node do di// ham remove di tai vi tri Index
       idListWebsite.remove(i);
    }
}

function XL_QUANG_CAO.radLogo2_change()
{
    if(document.getElementById("radLogo2").checked == false)
    {  
        document.getElementById("radLogo2").checked = true;      
        document.getElementById("radLogo1").checked = false;
        document.getElementById("txtLogo").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").disabled = true;
    }
}

function Danh_sach_quang_cao()
{
    var Chuoi = "";    
    Chuoi += "<table border='1' cellPadding = '15' cellSpacing ='10' style='width: 900px; height: 63px'>";
    Chuoi += "<tbody id = 'Th_Danh_sach_quang_cao'>";          
    Chuoi += "<tr align = 'center'>";
    Chuoi += "<td colspan='8' style='height: 21px'><font face='Verdana, Arial, Helvetica, sans-serif' size='6'>";
    Chuoi += "Danh sách quảng cáo</font></td>";
    Chuoi += "</tr>";
    Chuoi += "<tr>";
    Chuoi += "<td style='width: 170px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Tên Công Ty</font></td>";
    Chuoi += "<td style='width: 280px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Địa Chỉ</font></td>";
    Chuoi += "<td style='width: 180px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Website</font></td>";
    Chuoi += "<td style='width: 80px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Logo</font></td>";
    Chuoi += "<td style='width: 220px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Website Xuất Hiện</font></td>";
    Chuoi += "<td style='width: 50px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "Trạng Thái</font></td>";
    Chuoi += "<td style='width: 50px; height: 10px;' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' size='1'>";
    Chuoi += "</font></td>";
    Chuoi += "</tr>";
    Chuoi += "</tbody>"
    Chuoi += "</table>";
    
    document.getElementById("divTh_QuangCao").innerHTML = Chuoi;
}

function Them() {
window.location = "ThemQuangCao.aspx"
}

function XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite(ten_website)
{
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Lay_danh_sach_qc_cua_website");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ten_website", ten_website);
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {
        var Kq = new Array();
        var M = Goc.childNodes;
        for(var i = 0 ; i < M.length ; i++)
        {
            var qc = new Quang_Cao();            
            
            qc.Website = M[i].getAttribute("Website");
            qc.Logo = M[i].getAttribute("Logo");
                                    
            Kq.push(qc);
        }
        i = 0;
        for(var j = 0; j < 4; j++)        
        {
//            var div = document.getElementById(i);
//            if(div.innerHTMl != null)
//                continue;
//            var qc = Kq[i];
//            var a = document.createElement("a");
//            a.href = qc.Website;
//            var img = document.createElement("IMG");
//            img.src = qc.Logo;
//            a.appendChild(img);
//            div.appendChild(a);
//            i++;
            var div = document.getElementById(j + 1);
            //if(div.src != "http://localhost:50604/oFFS/")
             //   continue;
            var qc = Kq[i];
            if(qc == null)
                continue;
            div.src = qc.Logo;
            div = document.getElementById('a' + (j + 1));
            div.href = qc.Website;
            i++;
        }        
    }
}

function Cap_nhat() {
    var obj = window.event.srcElement.parentNode.firstChild;
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Cong_ty_cap_nhat");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ten_cong_ty", obj.firstChild.nodeValue);
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    
    window.location = "CapNhatThongTinQuangCao.aspx";
}

function XL_QUANG_CAO.ThemQuangCao()
{
    if(document.getElementById("divLogo").innerText == "Invalid" || document.getElementById("divTen").innerText == "Invalid" || document.getElementById("divDiaChi").innerText == "Invalid" || document.getElementById("divWebsite").innerText == "Invalid")
    {
        alert("Thông Tin Không Hợp Lệ");
        //return;
    }    
    else
    {
        var value = "";
        var logo = document.getElementById("txtLogo");
        var temp = document.getElementById("lstWebsiteDaChon");
        if(temp.length == 0)
        {
            alert("Vui lòng chọn website hiển thị");
            //return;
        }
        else
        {
            for(var i = 0; i < temp.length; i++)    
            {
                value += temp.options[i].innerHTML;
                if(i != temp.length - 1)
                    value += '-';
            }
                
            var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
            var Tham_so = new XL_THAM_SO("Xac_nhan","Them_Quang_Cao");
            Ham.Danh_sach_tham_so.push(Tham_so);
            Tham_so = new XL_THAM_SO("Ten_quang_cao", document.getElementById("txtTen").value);
            Ham.Danh_sach_tham_so.push(Tham_so);        
            Tham_so = new XL_THAM_SO("Dia_chi",document.getElementById("txtDiaChi").value);
            Ham.Danh_sach_tham_so.push(Tham_so);
            Tham_so = new XL_THAM_SO("Website",document.getElementById("txtWebsite").value);
            if(logo.disabled == false)
            {
                Ham.Danh_sach_tham_so.push(Tham_so);
                Tham_so = new XL_THAM_SO("Logo", logo.value);
            }    
            Ham.Danh_sach_tham_so.push(Tham_so);
            Tham_so = new XL_THAM_SO("WebsiteTheHien", value);
            Ham.Danh_sach_tham_so.push(Tham_so);
            Tham_so = new XL_THAM_SO("Tinh_trang", 0);
            Ham.Danh_sach_tham_so.push(Tham_so);
            
            var Goc = Ham.Thuc_hien();
            if(Goc != null)
            {        
                alert("Thêm thành công");
                
            }
            else
                alert("Thêm bị lỗi hay tên quảng cáo đã tồn tại !");
        }        
    }    
}
function Lay_ds_checked()
{
    var parent = document.getElementById("Th_Danh_sach_quang_cao");
    var arr = new Array();
    var i = 1;
    
    if(parent == null)
        return;
    
    //alert(parent.childNodes.length);
    var child = parent.firstChild.nextSibling.nextSibling;
    while(child)
    {
        var checkNode = document.getElementById(i);        
        if(checkNode.checked == true)
            arr.push(child.firstChild.innerText)
            
        i++;
        child = child.nextSibling;
    }
    
    return arr;
}

function Xoa_quang_cao()
{
    var arr = Lay_ds_checked();
    var Goc;
    
    var Kq = null;
    
    for(var i = 0; i < arr.length; i++)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Xoa_Quang_Cao");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ten_cong_ty",arr[i]);
        Ham.Danh_sach_tham_so.push(Tham_so);
        
        Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_QUANG_CAO.Thuc_hien_danh_sach_quang_cao(0);
    }
    return Kq;
}

function Kich_hoat_quang_cao()
{
    var arr = Lay_ds_checked();
    var Goc;
    
    var Kq = null;
    
    for(var i = 0; i < arr.length; i++)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");    
        var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_Nhat_Tinh_Trang");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ten_cong_ty",arr[i]);
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Loai", 1);
        Ham.Danh_sach_tham_so.push(Tham_so);
        
        Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_QUANG_CAO.Thuc_hien_danh_sach_quang_cao(0);
    }
    return Kq;
}

function Vo_hieu_quang_cao()
{
    var arr = Lay_ds_checked();
    var Goc;
    
    var Kq = null;
    
    for(var i = 0; i < arr.length; i++)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");    
        var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_Nhat_Tinh_Trang");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ten_cong_ty",arr[i]);
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Loai", 0);
        Ham.Danh_sach_tham_so.push(Tham_so);
        
        Goc = Ham.Thuc_hien();
    }
    if(Goc!=null)
    {   
        XL_QUANG_CAO.Thuc_hien_danh_sach_quang_cao(0);
    }
    return Kq;
}

function XL_QUANG_CAO.Thuc_hien_danh_sach_quang_cao(flag)
{
    var Ds = XL_QUANG_CAO.Danh_sach_quang_cao();    
    if(Ds!=null)
    {
        var Th = document.getElementById("Th_Danh_sach_quang_cao");
        if(Th == null)
            return;
        var len = Th.childNodes.length;
        for(var i = 2;i<len;i++)
            Th.removeChild(Th.lastChild);    
        for(var i = 0;i<Ds.length;i++)
        {        
            var dsqc = Ds[i];               
            var trNode = document.createElement("tr");
            var tdNode = document.createElement("td");
            var aNode = document.createElement("a");
            aNode.href = "#";
            aNode.onclick = Cap_nhat;
            aNode.appendChild(document.createTextNode(dsqc.TenCongTy));
            tdNode.appendChild(aNode);
            tdNode.align = "center";
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            tdNode.appendChild(document.createTextNode(dsqc.DiaChi));
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            tdNode.appendChild(document.createTextNode(dsqc.Website));
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var img = document.createElement("IMG");
            img.src = dsqc.Logo;
            img.height = "50";
            img.width = "50";
            //tdNode.appendChild(document.createTextNode(dsqc.Logo));
            tdNode.appendChild(img);
            trNode.appendChild(tdNode);
            
            //
            var dsWebsite = "";
            for(var j = 0; j < dsqc.WebsiteXuatHien.length; j++)
            {
                dsWebsite += dsqc.WebsiteXuatHien[j];
                if(j != dsqc.WebsiteXuatHien.length - 1)
                    dsWebsite += "\n";
            }
            //
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            tdNode.appendChild(document.createTextNode(dsWebsite));
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            tdNode.appendChild(document.createTextNode(dsqc.TrangThai));
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var checkNode = document.createElement("input");
            checkNode.type = "checkbox";
            checkNode.id = i+1;
            tdNode.appendChild(checkNode);
            trNode.appendChild(tdNode);
            
            Th.appendChild(trNode);                                        
        } 
        
        if(flag == 1)
        {
            var table = document.createElement("table");
            var bodyNode = document.createElement("tbody");
            var trNode = document.createElement("tr");                                              
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var buttonNode = document.createElement("button");        
            buttonNode.onclick = Them;
            buttonNode.appendChild(document.createTextNode("Thêm"));
            Th.appendChild(buttonNode);
            tdNode.appendChild(buttonNode);
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var buttonNode = document.createElement("button");
            buttonNode.onclick = Xoa_quang_cao;
            buttonNode.appendChild(document.createTextNode("Xóa"));
            Th.appendChild(buttonNode);
            tdNode.appendChild(buttonNode);
            trNode.appendChild(tdNode);
            
            /*var tdNode = document.createElement("td");
            tdNode.align = "center";
            var buttonNode = document.createElement("button");        
            buttonNode.onclick = Cap_nhat;
            buttonNode.appendChild(document.createTextNode("Cập Nhật"));
            Th.appendChild(buttonNode);
            tdNode.appendChild(buttonNode);
            trNode.appendChild(tdNode);*/
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var buttonNode = document.createElement("button");        
            //buttonNode.onclick = Them();
            buttonNode.appendChild(document.createTextNode("Kích Hoạt"));
            buttonNode.onclick = Kich_hoat_quang_cao;
            Th.appendChild(buttonNode);
            tdNode.appendChild(buttonNode);
            trNode.appendChild(tdNode);
            
            var tdNode = document.createElement("td");
            tdNode.align = "center";
            var buttonNode = document.createElement("button");        
            //buttonNode.onclick = Them();
            buttonNode.appendChild(document.createTextNode("Vô Hiệu"));
            buttonNode.onclick = Vo_hieu_quang_cao;            
            Th.appendChild(buttonNode);
            tdNode.appendChild(buttonNode);
            trNode.appendChild(tdNode);
            
            bodyNode.appendChild(trNode);
            table.appendChild(bodyNode);
            
            document.getElementById("divTh_QuangCao").appendChild(table);
        }
    }
}

function XL_QUANG_CAO.Danh_sach_quang_cao()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Lay_danh_sach");
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {   
        Kq = XL_QUANG_CAO.Khoi_tao_ds_quang_cao(Goc);
    }
    return Kq;
}


function XL_QUANG_CAO.Khoi_tao_ds_quang_cao(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var qc = new Quang_Cao();
        qc.TenCongTy = M[i].getAttribute("Ten_cong_ty");
        qc.DiaChi = M[i].getAttribute("Dia_chi");
        qc.Website = M[i].getAttribute("Website");
        qc.Logo = M[i].getAttribute("Logo");
        
        //lay danh sach webiste
        var dsWebsite = M[i].getAttribute("WebsiteTheHien");
        qc.WebsiteXuatHien = dsWebsite.split('-');
        
        
        qc.TrangThai = M[i].getAttribute("Tinh_trang");
        Kq.push(qc);
    }
    return Kq;
}

function XL_QUANG_CAO.Lay_danh_sach_website(id, arr)
{
    var Kq = null;    
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Lay_danh_sach_website");
    Ham.Danh_sach_tham_so.push(Tham_so);    
    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    { 
        var Kq = new Array();
        var M = Goc.childNodes;
        var lstWebsite = document.getElementById(id);
        for(var i = 0 ; i < M.length ; i++)
        {
            var flag = true;
            
            if(arr != null)
            {
                for(var j = 0; j < arr.length; j++)
                    if(M[i].getAttribute("Ten_website") == arr[j])
                    {
                        flag = false;
                        break;
                    }
            }
            if(flag == true)
            {
                var tagOption = document.createElement("option");
                tagOption.innerHTML = M[i].getAttribute("Ten_website");;
                //Add node do vao
                lstWebsite.appendChild(tagOption);            
            }
        }
    }
}

function XL_QUANG_CAO.Cap_nhat_thong_tin()
{
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Hien_thi_cap_nhat");
    Ham.Danh_sach_tham_so.push(Tham_so);    
    var Goc = Ham.Thuc_hien();
    if(Goc!=null)
    {   
        document.getElementById("txtTen").value = Goc.getAttribute("Ten_cong_ty");
        document.getElementById("txtDiaChi").value = Goc.getAttribute("Dia_chi");
        document.getElementById("txtWebsite").value = Goc.getAttribute("Website");
      
        //document.getElementById("txtWebsiteHT").value = Goc.getAttribute("Website_xuat_hien");        
        var arrWebsite = Goc.getAttribute("WebsiteTheHien");
        var arr = new Array();
        arr = arrWebsite.split('-');
        var idListWebsite_da_chon = document.getElementById('lstWebsiteDaChon1');
        for(var i = 0; i < arr.length; i++)
        {
            var tagOption = document.createElement("option");
            tagOption.innerHTML = arr[i];
            //Add node do vao
            idListWebsite_da_chon.appendChild(tagOption);
        }
        
        XL_QUANG_CAO.Lay_danh_sach_website('lstWebsite1', arr)
        
        document.getElementById("imgLogo").src = Goc.getAttribute("Logo");
        var trang_thai = Goc.getAttribute("Tinh_trang");
        if(trang_thai == 1)
            document.getElementById("chkTrangThai").checked = true;
    }
    return Kq;
}

XL_QUANG_CAO.KiemTraDuLieuNhap = function(data, Th_kqKiemTra, type)
{
    if(data == "")
    {
        //alert(Th_kqKiemTra);
        document.getElementById(Th_kqKiemTra).innerText = "Invalid";
        }
    else if(type == 1)
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
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

XL_QUANG_CAO.KiemTraTenQuangCao = function(data, Th_kqKiemTra)
{
    if(data == "")
    {
        //alert(Th_kqKiemTra);
        document.getElementById(Th_kqKiemTra).innerText = "Invalid";
        }
    else
    {
        var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
        var Tham_so = new XL_THAM_SO("Xac_nhan","Kiem_tra_ten_quang_cao");
        Ham.Danh_sach_tham_so.push(Tham_so);
        Tham_so = new XL_THAM_SO("Ten_quang_cao", data);
        Ham.Danh_sach_tham_so.push(Tham_so);
        
        var Goc = Ham.Thuc_hien();
        if(Goc != null)        
            document.getElementById(Th_kqKiemTra).innerText = "Valid";
        else
            document.getElementById(Th_kqKiemTra).innerText = "Tên quảng cáo đã tồn tại";
    }
}

function XL_QUANG_CAO.CapNhatThongTin()
{
    if(document.getElementById("divTen").innerText == "Tên quảng cáo đã tồn tại" || document.getElementById("divTen").innerText == "Invalid" || document.getElementById("divDiaChi").innerText == "Invalid" || document.getElementById("divWebsite").innerText == "Invalid")
    {
        alert("Thông Tin Không Hợp Lệ");
        return;
    }
    
    var value = "";
    var temp = document.getElementById("lstWebsiteDaChon1");
    for(var i = 0; i < temp.length; i++)    
    {
        value += temp.options[i].innerHTML;
        if(i != temp.length - 1)
            value += '-';
    }
    
    var logo = document.getElementById("txtLogo").value;
    
    var check;
    if(document.getElementById("chkTrangThai").checked == true)
        check = 1;
    else
        check = 0;
        
    var Ham = new XL_HAM("He Phuc Vu/XL_QUANG_CAO");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Cap_Nhat_Thong_Tin");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ten_cong_ty", document.getElementById("txtTen").value);
    Ham.Danh_sach_tham_so.push(Tham_so);        
    Tham_so = new XL_THAM_SO("Dia_chi",document.getElementById("txtDiaChi").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Website",document.getElementById("txtWebsite").value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    if(logo != "")
    {
        Tham_so = new XL_THAM_SO("Logo", logo);
        Ham.Danh_sach_tham_so.push(Tham_so);
    }
    Tham_so = new XL_THAM_SO("WebsiteTheHien", value);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Tinh_trang", check);
    Ham.Danh_sach_tham_so.push(Tham_so);
    
    var Goc = Ham.Thuc_hien();
    if(Goc != null)
    {        
        alert("Cap nhat thanh cong");
    }
}
