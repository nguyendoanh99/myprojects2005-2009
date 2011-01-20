// JScript File

function XL_HTTT()
{
    this.MaHTTT = -1;
    this.TenHTTT = "";
}

function XL_HTTT.LayDSHTTT(nodename)
{
    var th = document.getElementById(nodename);

    var ham = new XL_HAM("He phuc vu/XL_HTTT");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSHTTT"));
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
            nodeOpt.innerHTML = M[i].getAttribute("TenHinhThucThanhToan");
            nodeOpt.value = M[i].getAttribute("MaHinhThucThanhToan");            
            th.appendChild(nodeOpt);
        }       
        th.selectedIndex = 0;
    }
}