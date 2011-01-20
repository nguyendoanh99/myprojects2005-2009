// JScript File

function XL_HTKM()
{
    this.MaHTKM = -1;
    this.TenHTKM = "";
}

function XL_HTKM.LayDSHTKM(nodename)
{
    var th = document.getElementById(nodename);

    var ham = new XL_HAM("He phuc vu/XL_HTKM");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSHTKM"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {     
        var M = goc.childNodes;  
        var nodeOpt;  
        
        nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn--";
        nodeOpt.value = 0;
        th.appendChild(nodeOpt);
            
        for(var i = 0; i < M.length; i++)
        {            
            nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = M[i].getAttribute("TenHinhThucKhuyenMai");
            nodeOpt.value = M[i].getAttribute("MaHinhThucKhuyenMai");
            th.appendChild(nodeOpt);
        }       
        th.selectedIndex = 0;
    }
}