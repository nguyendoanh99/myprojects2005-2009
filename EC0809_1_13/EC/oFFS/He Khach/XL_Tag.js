// JScript File

function XL_TAG()
{
    this.ma_tag = -1;
    this.ten_tag = "";
    this.do_uu_tien = -1;
}

function XL_TAG.KhoiTaoDanhSachTag(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var tag = new XL_TAG();
        
        tag.ma_tag = M[i].getAttribute("Ma_tag");
        tag.ten_tag = M[i].getAttribute("Ten_tag");
        tag.do_uu_tien = M[i].getAttribute("Do_uu_tien");        
                
        Kq.push(tag);
    }
    return Kq;
}

function XL_TAG.DanhSachTag()
{

    var ham = new XL_HAM("He Phuc Vu/XL_Tag");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDanhSach"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));    
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {       
        var arr = XL_TAG.KhoiTaoDanhSachTag(goc);
        var Th = document.getElementById("divDSTag");
        XL_TAG.TheHienDSTag(arr, Th);
    }
}

function OnMouseOver(evt)
{
    var evt = evt || window.event;
    var obj = evt.target || window.event.srcElement;
   
    //var nodeParent = obj.parentNode;    
    obj.style.color = "blue";
}

function OnMouseOut(evt)
{
    var evt = evt || window.event;
    var obj = evt.target || window.event.srcElement;
   
    //var nodeParent = obj.parentNode;    
    obj.style.color = "red";
}


function XL_TAG.TheHienDSTag(arr, Th)
{
    Th.innerHTML = "";
    
    var maxPriority = 0;
    var minPriority = 0;
    for(var i = 0; i < arr.length; i++)
    {
        if(parseInt(arr[i].do_uu_tien) >= parseInt(maxPriority))
            maxPriority = parseInt(arr[i].do_uu_tien);
    }
    
    for(var i = 0; i < arr.length; i++)
    {
        if(parseInt(arr[i].do_uu_tien) <= parseInt(minPriority))
            minPriority = parseInt(arr[i].do_uu_tien);
    }
    
    var jump = parseInt((maxPriority - minPriority)/3);
    var lev1 = minPriority + jump;
    var lev2 = lev1 + jump;  
   
    var p = document.createElement("p");    
    Th.appendChild(p);
    
    for(var i = 0; i < arr.length; i++)
    {
        var tag = arr[i];
        var a = document.createElement("a");
        a.appendChild(document.createTextNode(tag.ten_tag + " "));
        a.href = "javascript:XL_TAG.click("+tag.ma_tag+");";
        a.onmouseover = OnMouseOver;
        a.onmouseout = OnMouseOut;
        if(tag.do_uu_tien <= lev1)
            a.style.fontSize = "small";
        else if(tag.do_uu_tien > lev1 && tag.do_uu_tien <= lev2)
            a.style.fontSize = "large";
        else
        {
            a.style.fontSize = "x-large";            
        }
       
        p.appendChild(a);
    }
}

function XL_TAG.click(ma_tag)
{
    var ham = new XL_HAM("He Phuc Vu/XL_Tag");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "Ghi_nhan_tag"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ma_tag", ma_tag));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    window.location = "DanhSachItemTheoTag.aspx";
    
}