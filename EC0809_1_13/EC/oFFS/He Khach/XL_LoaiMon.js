// JScript File

function XL_LoaiMon()
{
}

function Loai_Mon()
{
    this.MaLoaiMon = -1;
    this.TenLoaiMon = "";
    this.MaLoaiMonCha = -1;
    this.LaLoaiMonLa = "False";
}

//bien chua duong dan khi duyet loai thuc don hay loai mon an
var arrMaLoaiMonAn = new Array();
var arr;
var Th;
var path;

function XL_LoaiMon.ChiTietLoaiMon(ma_loai_mon)
{
    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ChiTietLoaiMon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiMon", ma_loai_mon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var lma = null;
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        lma = new Loai_Mon();
        
        lma.MaLoaiMon = goc.getAttribute("MaLoaiMon");
        lma.TenLoaiMon = goc.getAttribute("TenLoaiMon");
        lma.MaLoaiMonCha = goc.getAttribute("MaLoaiMonCha");
        lma.LaLoaiMonLa = goc.getAttribute("LaLoaiMonLa");
    }
    
    return lma;
}

function XL_LoaiMon.push(ma)
{
    if(ma != null)
        arrMaLoaiMonAn.push(ma);
    
    var DOM = XL_LoaiMon.HienThiDuongDan(arrMaLoaiMonAn);
    return DOM;
}

function XL_LoaiMon.pop(ma)
{
    if(ma == null)
    {
        for(var i = arrMaLoaiMonAn.length - 1; i >= 0; i--)
            arrMaLoaiMonAn.pop();
        return null;
    }
    var n = arrMaLoaiMonAn.length;
    
    for(var i = n - 1; i >= 0; i--)
        if(arrMaLoaiMonAn[i] != ma)
            arrMaLoaiMonAn.pop();
            
    var DOM = XL_LoaiMon.HienThiDuongDan(arrMaLoaiMonAn);
    return DOM;
}

function XL_LoaiMon.HienThiDuongDan(_arr)
{
    var div = document.createElement("div");
    div.textAlign = "left";
    var a = document.createElement("a");
    a.appendChild(document.createTextNode("DS Loai Mon"));
    a.href = "javascript:XL_LoaiMon.DanhSachLoaiMon()"
//    a.Color = "#FF0000";
    div.appendChild(a);

    for(var i = 0; i < _arr.length; i++)
    {
        var loai_mon_an = XL_LoaiMon.ChiTietLoaiMon(_arr[i]);
        div.appendChild(document.createTextNode(" --> "));                
        
        if(i < _arr.length - 1)
        {
            a = document.createElement("a");
            a.appendChild(document.createTextNode(loai_mon_an.TenLoaiMon));
            a.href = "javascript:XL_LoaiMon.pop("+loai_mon_an.MaLoaiMon+");javascript:XL_LoaiMon.DanhSachLoaiMonCon("+loai_mon_an.MaLoaiMon+",'"+loai_mon_an.LaLoaiMonLa+"')"
            a.color = "#FF0000";
            div.appendChild(a);
        }        
        else
        {
            //a = document.createElement("a");
            div.appendChild(document.createTextNode(loai_mon_an.TenLoaiMon));            
            //a.color = "rgb(255, 0, 0)";
            //div.appendChild(a);
        }
    }
    
    return div;
}


//NGHI
//show danh sách loại món GỐC ở dnh sách loại món bên phải trang
function XL_LoaiMon.LoadDSLoaiMonGoc(nodename)
{
    var nodeDiv = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiMonGoc"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        
        //<a title="Thức ăn nhanh" style="display:block;" class="mainlevel" href="danhsachmonan.aspx" >Thức ăn nhanh</a>
        for(var i =0; i<M.length; i++)
        {
            var maloaimon = M[i].getAttribute("MaLoaiMon");
            var tenloaimon = M[i].getAttribute("TenLoaiMon");
            
            var nodeA = document.createElement("a");
            nodeA.innerHTML = tenloaimon;
            nodeA.style.display = 'block';
            nodeA.setAttribute("className", "mainlevel");
            
            ////////////////////////////////LONG THÊM HÀM THÍCH HỢP CHO CHỖ NÀY
            nodeA.href = "javascript:XL_LoaiMon.click(" + maloaimon + ")";
            
            nodeDiv.appendChild(nodeA);
        }
    }
    else
        alert("Lỗi khi load loại món");
}

function XL_LoaiMon.click(maloaimon)
{
    var ham = new XL_HAM("He Phuc Vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "GhiNhanLoaiMon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ma_loai_mon", maloaimon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    window.location = "DsMonAnThuocLoaiMonAn.aspx";
}

function XL_LoaiMon.LoadDSLoaiMonLa(nodename) //lá
{
    var nodeCmb = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiMonLa"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn loại món";
        nodeOpt.value = -1;
        nodeCmb.appendChild(nodeOpt);
        
        for(var i =0; i<M.length; i++)
        {
            var maloaimon = M[i].getAttribute("MaLoaiMon");
            var tenloaimon = M[i].getAttribute("TenLoaiMon");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenloaimon;
            nodeOpt.value = maloaimon;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load loại món");
}

function XL_LoaiMon.LoadDSLoaiMon(nodename) //lá
{
    var nodeCmb = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiMon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn loại món";
        nodeOpt.value = -1;
        nodeCmb.appendChild(nodeOpt);
        
        for(var i =0; i<M.length; i++)
        {
            var maloaimon = M[i].getAttribute("MaLoaiMon");
            var tenloaimon = M[i].getAttribute("TenLoaiMon");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenloaimon;
            nodeOpt.value = maloaimon;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load loại món");
}


function XL_LoaiMon.ThemLoaiMonMoi(nodetenloaimon, nodemaloaimoncha, nodelaloaimonla)
{
    //Lấy thông tin trên form
    var tenloaimon = nodetenloaimon.value;
    var maloaimoncha = nodemaloaimoncha.value;
    var laloaimonla = (nodelaloaimonla.checked == true);
    
    if(tenloaimon == "")
        XL_CHUOI.Xuat("Lỗi: chưa nhập tên loại món!");
    else
    {
        var ham = new XL_HAM("He Phuc Vu/XL_LoaiMon");
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemLoaiMonMoi"));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("tenloaimon", tenloaimon));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("maloaimoncha", maloaimoncha));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("laloaimonla", laloaimonla));
        
        //Yêu cầu server cập nhật thông tin cho khách hàng
        var goc = ham.Thuc_hien();
        
        if(goc != null && goc.getAttribute("kq") == "True")
        {
            XL_CHUOI.Xuat("Thêm thành công!");   
            //redirect toi trang danh sach cac loai mon    
        }
        else
            XL_CHUOI.Xuat("Thêm bị lỗi!");
    }    
}

function XL_LoaiMon.DanhSachLoaiMon()
{
    var kq = null;

    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiMon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        arr = XL_LoaiMon.Khoi_tao_ds_loai_mon_an(goc)
        Th = document.getElementById("Th_ds_loai_mon");
        XL_LoaiMon.pop(null);
        var _kq = XL_LoaiMon.HienThiDuongDan(arrMaLoaiMonAn);
        XL_LoaiMon.HienThiDanhSachLoaiMon(1, _kq);
    }
    
    //return kq;
}

function XL_LoaiMon.DanhSachLoaiMonCon(ma_loai_mon, la_loai_mon_la)
{
    var kq = null;
    if(la_loai_mon_la == "False")
    {
        var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDanhSachLoaiMonCon"));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiMon", ma_loai_mon));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));

        var goc = ham.Thuc_hien();
        var _path = null;
        if(goc != null)
        {
                    
            arr = XL_LoaiMon.Khoi_tao_ds_loai_mon_an(goc)
            Th = document.getElementById("Th_ds_loai_mon");
            var i;
            if(arrMaLoaiMonAn.length != 0)
            {
                for(i = 0; i < arrMaLoaiMonAn.length; i++)
                    if(arrMaLoaiMonAn[i] == ma_loai_mon)
                    {
                        _path = XL_LoaiMon.pop(ma_loai_mon);
                        break;
                    }
            }        
            else if(arrMaLoaiMonAn.length == 0)
                _path = XL_LoaiMon.push(ma_loai_mon);
            else if(arrMaLoaiMonAn.length != 0 && i == arrMaLoaiMonAn.length)
                _path = XL_LoaiMon.push(ma_loai_mon);
            XL_LoaiMon.HienThiDanhSachLoaiMon(0, _path)
        }
    }
    else
    {        
        var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSMonAn"));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiMon", ma_loai_mon));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));

        var goc = ham.Thuc_hien();
        if(goc != null)
        {            
            arr = XL_MON_AN.Khoi_tao_ds_mon_an(goc);
            Th = document.getElementById("Th_ds_loai_mon");
            path = XL_LoaiMon.push(ma_loai_mon);
            XL_LoaiMon.HienThiDanhSachMonAn()
        }
        else
        {
            arr = null;
            Th = document.getElementById("Th_ds_loai_mon");
            path = XL_LoaiMon.push(ma_loai_mon);
            XL_LoaiMon.HienThiDanhSachMonAn()
        }        
    }
    
    //return kq;
}

function XL_LoaiMon.Khoi_tao_ds_loai_mon_an(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var lma = new Loai_Mon();
        
        lma.MaLoaiMon = M[i].getAttribute("MaLoaiMon");
        lma.TenLoaiMon = M[i].getAttribute("TenLoaiMon");
        lma.MaLoaiMonCha = M[i].getAttribute("MaLoaiMonCha");
        lma.LaLoaiMonLa = M[i].getAttribute("LaLoaiMonLa");
                
        Kq.push(lma);
    }
    return Kq;
}

function XL_LoaiMon.HienThiDanhSachLoaiMon(flag, path)
{
    var table = document.createElement("table");
    table.align = "center";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tao duong dan
    td.appendChild(path);    
    tr = document.createElement("tr");
    td = document.createElement("td");
    tbody.appendChild(tr);
    
    //tạo tiêu đề cho danh sách    
    var h1 = document.createElement("h1");
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Loai Món Ăn"));    
    td.appendChild(h1);
    tr.appendChild(td);
    
    var table3 = document.createElement("table");
    table3.align = "center";
    table3.width = "70%";
    table3.border = "0";
    td.appendChild(table3);
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    var td3 = document.createElement("td");
    td3.width = "15%";
    td3.appendChild(document.createTextNode("Ma Loai Mon"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "40%";
    td3.appendChild(document.createTextNode("Ten Loai Mon"));
    tr3.appendChild(td3);
//    td3 = document.createElement("td");
//    td3.width = "15%";
//    td3.appendChild(document.createTextNode("Ma Loai Mon Cha"));
//    tr3.appendChild(td3);
    
    for(var i = 0; i < arr.length; i++)
    {
        var loai_mon_an = arr[i];
        if(loai_mon_an.MaLoaiMonCha != -1 && flag == 1)
            continue;
        tr3 = document.createElement("tr");
        tbody3.appendChild(tr3);
        td3 = document.createElement("td");
        td3.width = "15%";
        var a = document.createElement("a");
        a.href = "javascript:XL_LoaiMon.DanhSachLoaiMonCon("+loai_mon_an.MaLoaiMon +",'" + loai_mon_an.LaLoaiMonLa+"')";
        a.appendChild(document.createTextNode(loai_mon_an.MaLoaiMon));
        td3.appendChild(a);
        tr3.appendChild(td3);
        td3 = document.createElement("td");
        td3.width = "40%";
        a = document.createElement("a");
        a.href = "javascript:XL_LoaiMon.DanhSachLoaiMonCon("+loai_mon_an.MaLoaiMon + ",'" + loai_mon_an.LaLoaiMonLa+"')";
        a.appendChild(document.createTextNode(loai_mon_an.TenLoaiMon));
        td3.appendChild(a);
        tr3.appendChild(td3);
        //td3 = document.createElement("td");
        //td3.width = "15%";
        //td3.appendChild(document.createTextNode(loai_mon_an.MaLoaiMonCha));
        //tr3.appendChild(td3);
    }
    
    Th.innerHTML = "";
    Th.appendChild(table);
}

function XL_LoaiMon.HienThiDanhSachMonAn()
{    
    var temp;
    var m;
    //var mathucdon = XL_THUC_DON.Lay_ma_thuc_don();
        
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

    //var arr = new Array();
    //arr = XL_THUC_DON.Chi_tiet_thuc_don(mathucdon);
    
    var table = document.createElement("table");
    table.align = "center";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");

    
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tao duong dan
    td.appendChild(path);    
    tr = document.createElement("tr");
    td = document.createElement("td");
    tbody.appendChild(tr);
    tr.appendChild(td);
    
    //tạo tiêu đề cho danh sách
    var h1 = document.createElement("h1");
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Món Ăn Cua Loai Mon An"));    
    td.appendChild(h1);
    
    if(arr.length == 0)
    {
        Th.innerHTML = "";
        Th.appendChild(table);
    }
        
    //////////////////////////////////////////////////////////////////////////////////
    else
    {
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
        
        ///////////////////////////////////////////////////////////////////////////////
        tr = document.createElement("tr");
        tbody.appendChild(tr);
        td = document.createElement("td");
        td.align = "right";
        tr.appendChild(td);
        
        
        //var div = document.createElement("div");  
        //td.appendChild(div);                
        //div.style.textAlign = "center";
        //////////////////////////////////////////////////////////////////////////////////
        
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
                a.onclick = XL_LoaiMon.HienThiDanhSachMonAn;
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
                        a.onclick = XL_LoaiMon.HienThiDanhSachMonAn;        
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
                a.onclick = XL_LoaiMon.HienThiDanhSachMonAn;
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
            div.appendChild(document.createTextNode(mon_an.Gia + " VND"));
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
            tr2.appendChild(td2);               
        }
        
        Th.innerHTML = "";
        Th.appendChild(table);
    }
}

//XU LY CHO TRANG QuanLyDanhMucLoaiMon.aspx

var myDataSource;
function CreateTable()
{
    myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_LoaiMon.aspx?xac_nhan=DuyetCayLoaiMon&t=" + (new Date().getTime()) + "&"));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "Record", // Name of the node for each result
        fields : [
            { key: "MaLoaiMon" }, // Attribute of the resultNode
            { key: "TenLoaiMon" }, 
            { key: "LaLoaiMonLa" },
            { key: "SoLuongMonCon"}
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
        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        // Phân trang
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 10 // Số dòng tối đa của một trang
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : true
    };
    
    // Override the built-in formatter
    // Cho nút xóa tài khoản, gửi lại mật khẩu
   YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maLoaiMon = oRecord.getData("MaLoaiMon");
        //var tenLoaiMon = oRecord.getData("TenLoaiMon");
        var laLoaiMonLa = oRecord.getData("LaLoaiMonLa");
        var soLuongMonCon = oRecord.getData("SoLuongMonCon");
        if (oColumn.key.indexOf("Xoa") != -1)
        {
            if(laLoaiMonLa == "True" && soLuongMonCon == "0")
                elCell.innerHTML = '<a id="Xoa' + maLoaiMon + '"><img src="Images/Close.png" title="Xóa loại món" height="16"/></a>';
        }
        else
        {
            if(laLoaiMonLa == "True" && soLuongMonCon != "0")
                elCell.innerHTML = '<a href="ChiTietLoaiMon.aspx?loai=' +  maLoaiMon + '"id="ChiTiet' + maLoaiMon + '"><img src="Images/Clipboard.png"' + 'title="Chi tiết món con" height="16"/></a>';
        }
        
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
  
    // Định nghĩa cột
    var myColumnDefs = [
        { label:"STT", formatter: STTFormatter},
        { key: "MaLoaiMon", label:"Mã loại món" },
        { key: "TenLoaiMon", label:"Tên loại món", sortable:true },                
        { key: "LaLoaiMonLa", label:"Là loại món lá" },
        { key: "SoLuongMonCon", label: "Số lượng món con"},
        { key: "Xoa", label:"", formatter: YAHOO.widget.DataTable.formatLink},
        { key: "ChiTiet", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divKq", myColumnDefs, myDataSource, myConfigs);
    // Update totalRecords on the fly with value from server
    // Dành cho phân trang, cập nhật lại tổng số dòng
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
    return myDataTable;
}

function DuyetCayLoaiMon()
{               
    document.body.className += " yui-skin-sam";
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}

function XoaLoaiMon(maLoaiMon)
{
    var ham = new XL_HAM("He phuc vu/XL_LoaiMon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "XoaLoaiMon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("maloaimon", maLoaiMon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {   
             return "";
        }        
        else
        {
            return "Không xóa được do có lỗi phía server";
        }
    }
    else
        return "Lỗi đường truyền"; 
}

// Thêm các event cho table
function AddEvents(myDataTable)
{
    var maLoaiMon;
    var oRecord;
    // Define various event handlers for Dialog
	var handleYes = function() {
	    this.hide();
	    var kq = XoaLoaiMon(maLoaiMon);
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
			   text: "Bạn có muốn xóa loại món này không?",
			   icon: YAHOO.widget.SimpleDialog.ICON_HELP,
			   constraintoviewport: true,
			   buttons: [ { text:"Có", handler:handleYes },
						  { text:"Không",  handler:handleNo, isDefault:true } ]
			 } );
	
	// Render the Dialog
	Deletedialog.render(document.body);
	
    var highlightEditableCell = function(oArgs) {
        var elCell = oArgs.target;
        if(YAHOO.util.Dom.hasClass(elCell, "yui-dt-editable") 
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-Xoa")
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-ChiTiet")) {
            this.highlightCell(elCell);
        }
    };
    // Enable inline cell editing 
    myDataTable.subscribe("cellMouseoverEvent", highlightEditableCell);
    myDataTable.subscribe("cellMouseoutEvent", myDataTable.onEventUnhighlightCell);
    myDataTable.subscribe("cellClickEvent", myDataTable.onEventShowCellEditor);
    
    // Sự kiện click trên link (Xóa tài khoản, Gửi lại mật khẩu)
    myDataTable.subscribe("linkClickEvent", function(oArgs){
        var target = oArgs.target;
        oRecord = this.getRecord(target);
        maLoaiMon = oRecord.getData("MaLoaiMon");
        if (target.id.indexOf("Xoa") != -1) // xóa tài khoản người dùng
        {
            Deletedialog.show();
        }
        
    });
}